using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
using System.Data;
using dental_clinic.Models;
using System.ComponentModel.DataAnnotations;

public class completeInfo : PageModel
{
    private readonly DataBase db;
    [BindProperty]
    [Required]
    public int phone { get; set; }
    [BindProperty]
    public string city { get; set; }
    [BindProperty]
    public string street { get; set; }
    [BindProperty]
    public string gender { get; set; }
    [BindProperty(SupportsGet = true)]
    public int NationalID { get; set; }
    [BindProperty(SupportsGet = true)]
    public string mail { get; set; }
    public int ID { set; get; }
    public completeInfo(DataBase db)
    {
        this.db = db;
    }
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        string answer=null;
        mail = HttpContext.Session.GetString("Email");
       db.AddPatient(gender,city,street,NationalID);
       ID = db.ReturnID(mail);
       answer= db.InsertContacts(ID,phone);
       return RedirectToPage("/patient main");
    }
}