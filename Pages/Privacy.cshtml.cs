using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
using dental_clinic.Models;
using System.Data;

public class PrivacyModel : PageModel
{
    private readonly DataBase db;
    public DataTable dt { get; set; }
    public PrivacyModel(DataBase db)
    {
        this.db=db;
    }
    private readonly ILogger<PrivacyModel> _logger;
    public void OnGet()
    {
        dt = db.returnRecepContacts();
    }
}