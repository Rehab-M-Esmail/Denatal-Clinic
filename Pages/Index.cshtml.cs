
namespace dental_clinic.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using dental_clinic.Models;

public class Index : PageModel
{
    public void OnGet()
    {
    }
    [BindProperty (SupportsGet = true)]
    public string ErrorMSG { set; get; }
    [BindProperty]
    public string email { get; set; }
    [BindProperty]
    public string password { get; set; }

    private readonly DataBase db;

    public Index(DataBase db)
    {
        this.db = db;
    }
    public IActionResult OnPost()
    {
        string answer;
        answer = db.checklogin(email, password);
        HttpContext.Session.SetString("Email",email);
        switch (answer)
        {
            case "patient":
            case "Patient":
                return RedirectToPage("patient main");
            case "Dentist": 
            case "dentist":
                return RedirectToPage("/Dentist main");  
            case "Nurse":
            case"nurse":
                return RedirectToPage("/Nurses");
            case "Receptionist":
                return RedirectToPage("/Reception");
                        
            default: //will be edited in the integration
                return RedirectToPage("Signin");
        }
    }
}

