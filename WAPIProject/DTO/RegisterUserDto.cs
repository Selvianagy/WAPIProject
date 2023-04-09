using System.ComponentModel.DataAnnotations;

namespace WAPIProject.DTO
{
    public class RegisterUserDto
    {
   
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }


 
    }
}
