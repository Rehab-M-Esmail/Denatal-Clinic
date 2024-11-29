using Microsoft.AspNetCore.Mvc.RazorPages;
using dental_clinic.Models;
namespace dental_clinic.Pages;
using System.Data;

public class Doctors : PageModel
{
    public Doctors(DataBase db)
    {
         this.db=db;
    }
    public DataTable dt { get; set; }
    private readonly DataBase db;
    public void OnGet()
    {
        dt = db.Returndoctors();
    }
}