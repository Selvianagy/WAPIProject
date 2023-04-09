using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using System.Reflection;
using WAPIProject.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUnitOfWorkRepository unitOfWorkRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config,
               IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.userManager = userManager;
            this.config = config;
        }
        [HttpPost("register")]//api/account/register
        public async Task<IActionResult> Register(RegisterUserDto userDTO)
        {
            if (ModelState.IsValid)
            {
                //create  ==>add user db
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = userDTO.Email;
                userModel.UserName = userDTO.UserName;
                userModel.PhoneNumber = userDTO.PhoneNumber;
                IdentityResult result = await userManager.CreateAsync(userModel, userDTO.Password);
                if (result.Succeeded)
                {
                    Customer customer = new Customer();
                    customer.ApplicationUserId = userModel.Id;
                    unitOfWorkRepository.Customer.Add(customer);
                    return Ok("Created Success");
                }
                else
                    return BadRequest(result.Errors.First());
            }
            return BadRequest(ModelState);
        }

        [HttpPost("vendorRegister")]
        public async Task<IActionResult> VendorRegestration(VendorRegaestrationDto vendorRegester)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                Store store = new Store();
                Vendor vendor = new Vendor();

                userModel.UserName = vendorRegester.UserName;

                if (vendorRegester.Gender == "Male")
                {
                    userModel.gender = Gender.Male;
                }
                else
                {
                    userModel.gender = Gender.Female;
                }


                userModel.PasswordHash =  vendorRegester.Password;
                userModel.Email        = vendorRegester.Email;
                userModel.PhoneNumber  = vendorRegester.PhoneNumber;
                userModel.City         = vendorRegester.City;
                userModel.Country      = vendorRegester.Country;
                userModel.IsDeleted = false;


                store.Name = vendorRegester.StoreName;
                store.Street = vendorRegester.StoreAddress;
                store.Description = vendorRegester.StoreDescription;
                store.Country = vendorRegester.Country;
                store.City = vendorRegester.City;
                store.IsConfermed = false;

                IdentityResult result = await userManager.CreateAsync(userModel, vendorRegester.Password);

                if (result.Succeeded)
                {

                    vendor.ApplicationUserId = userModel.Id;

                    unitOfWorkRepository.Store.Add(store);

                    vendor.StoreId = store.Id;


                    store.VendorId = userModel.Id;

                    unitOfWorkRepository.Vendor.Add(vendor);

                    unitOfWorkRepository.Store.Update(store);

                    return Ok("Created Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }

    }







}

