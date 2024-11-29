using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
using dental_clinic.Models;

public class Forgetpass : PageModel
{
    [BindProperty]
    public string password { get; set; }
    [BindProperty]
    public string email { get; set; }
    
    private DataBase db;
    public Forgetpass(DataBase db)
    {
        this.db = db;
    }
    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
       db.EditPassword(password,email);
       return RedirectToPage("/Index");

    }

}