using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
using dental_clinic.Models;
using System.Data;

public class ShowServices : PageModel
{
    public DataTable dt { get; set; }
  
    public void OnGet()
    {
        dt= db.services();
    }
    private readonly DataBase db;
    public ShowServices(DataBase db)
    {
        this.db=db;
    }
}