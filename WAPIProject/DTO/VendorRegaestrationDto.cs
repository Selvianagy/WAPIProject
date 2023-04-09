using System.ComponentModel.DataAnnotations;

namespace WAPIProject.DTO
{
    public class VendorRegaestrationDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreDescription { get; set; }
        public string StoreSpecialty { get; set; }
    }
}
