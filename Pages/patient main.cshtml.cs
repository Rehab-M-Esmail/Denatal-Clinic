using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
using System.Data.SqlClient;
using dental_clinic.Models;
public class patient_main : PageModel
{
    public string category { get; set; }
    private readonly DataBase db;
    public patient_main(DataBase db)
    {
        this.db=db;
    }
    [BindProperty (SupportsGet = true)]
    
    public string service { get; set; }
    public void OnGet()
    {
        
    }
    public IActionResult OnPost()
    {
        return RedirectToPage("/Appointment");
    }

}