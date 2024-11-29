using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace dental_clinic.Pages
{
    public class DentistProfileModel : PageModel
    {
        public DentistProfile DentistProfile { get; set; }
        public void OnGet()
        {
           
            DentistProfile = new DentistProfile
            {
                name = "Dr. John Doe",
                pictureurl = "/images/doctor.jpg",
                nationalid = "123456789",
                phonenumber = "+1 123 456 7890",
                specialization = "Dentistry",
                email = "john.doe@example.com",
                age = 35,
                id = "D123"
            };
        }
    }

    public class DentistProfile
    {
        public string name { get; set; }
        public string pictureurl { get; set; }
        public string nationalid { get; set; }
        public string phonenumber { get; set; }
        public string specialization { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string id { get; set; }
    }
}