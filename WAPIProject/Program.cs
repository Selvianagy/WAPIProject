
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reprository.Core;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF;
using Reprository.EF.Repositories;

namespace WAPIProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"),
                b=>b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

         
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>();

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            builder.Services.Configure<SmsVerification>(builder.Configuration.GetSection("SMS"));   
            builder.Services.AddTransient<ISmsSender,SmsSenderRepository>();    

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}