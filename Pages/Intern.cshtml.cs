using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace dental_clinic.Pages;
using dental_clinic.Models;
using System.Data;
public class Intern : PageModel
{
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string NationalID { get; set; }
        [BindProperty]
        public string SelectedDoctor { get; set; }

        [BindProperty]
        public string SelectedPracticeField { get; set; }

        public void OnGet()
        {
            Name = HttpContext.Session.GetString("Name");
            NationalID = HttpContext.Session.GetString("NationalID");
            PhoneNumber = HttpContext.Session.GetString("PhoneNumber");
          
        }
        public RedirectToPageResult OnPost()
        {
            var practiceField = SelectedPracticeField;

            
            return RedirectToPage();
        }
    }
    