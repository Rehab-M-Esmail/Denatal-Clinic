using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace dental_clinic.Pages;
using System.Data.SqlClient;
using dental_clinic.Models;
using System.Data.SqlClient;
using System.Data;


public class result_page : PageModel
{
    public result_page(DataBase db)
    {
        this.db=db;
    }
     public DataTable dt { get; set; }
     private readonly DataBase db;
     public void OnGet()
     {
         dt = db.ReturnResults("UserAccount");
     }

    
}