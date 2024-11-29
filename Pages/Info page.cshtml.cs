using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace dental_clinic.Pages;
using dental_clinic.Models;
using System.Data;


public class InfoPage : PageModel
{
    [BindProperty]
    public string? newname { get; set; }
    [BindProperty]
    public string? newEmail { get; set; }
    [BindProperty]
    public int newAge { get; set; }
    [BindProperty]
    public int? rate { get; set; }
    [BindProperty]
    public string? review { set; get; }

    public InfoPage(DataBase db)
    {
        this.db = db;
    }
    [BindProperty]
    public string Email { get; set; }
    public int id { get; set; }
    public DataTable dt { get; set; }
    public DataTable dt2 { get; set; }
    public DataTable dt3 { get; set; }
    public DataTable dt4 { get; set; }
    private readonly DataBase db;

    public void OnGet()
    {
        Email = HttpContext.Session.GetString("Email");
        dt = db.Returninfo(Email);
        id = db.ReturnID(Email);
        dt2 = db.ReturnextraData(id);
        dt3 = db.ReturnHistory(id);
        dt4 = db.returnContact(id);
    }

    // public void OnPostNameEdit(string oldname, string newname)
    // {
    //     int? answer=db.EditName(oldname, newname);
    // }
    //
    // public void OnPostEmailEdit(string oldEmail, string newEmail)
    // {
    //     db.EditEmail(oldEmail, newEmail);
    // }
    //
    // public IActionResult OnPostAgeEdit(int newAge, string Email)
    // {
    //     db.EditAge(newAge, Email);
    //     return Page();
    // }
    //
    // public void OnPostPassEdit(string newPassword, string Email)
    // {
    //     db.EditPassword(newPassword, Email);
    // }

    public IActionResult OnPost(string ID)
    {
        switch (ID)
        {
            case "1":
                int? answer= db.EditName(Email,newname);
                return Page();
            case "2":
                db.EditEmail(Email,newEmail);
                return Page();
            case "3":
                db.EditAge(newAge,Email);
                return Page();
            default:
                return Page();
        }
    }
    
}
//     public IActionResult INFO()
//     {
//      
//     }
// }