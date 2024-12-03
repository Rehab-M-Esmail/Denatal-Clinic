using System.ComponentModel;
using dental_clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace dental_clinic.Pages;
using System.ComponentModel.DataAnnotations;

public class IndexModel : PageModel
{
    
    [BindProperty]
    [Required]
    [MinLength(3)]
    public string name { get; set; }
    [BindProperty (SupportsGet = true)]
    public string? checkInsertion { get; set; }
    [BindProperty]
    [Required]
    public int nationalID { get; set; }
    [BindProperty]
    public int age { get; set; }
    
    [BindProperty]
    [Required]
    public string Email { get; set; }
    [BindProperty]
    [Required]
    public string password { get; set; }
    
    private readonly DataBase db;
    public IndexModel(DataBase db)
    {
        this.db = db;
    }

    public void OnGet()
    {
    }

    // public IActionResult OnPostRedirect(string category)
    // {
    //     switch (category)
    //     {
    //         case "Patient":
    //             return RedirectToPage("/patient main");
    //         case "Dentist":
    //         case "intern":
    //         case "Reception":
    //         case "Nurse":
    //         case "Administrator":
    //             return RedirectToPage("/temp");
    //     }
    //
    //     return RedirectToPage("/main");
    // }
    public IActionResult OnPost(int category)
    {
        HttpContext.Session.SetString("Email",Email);
        if (ModelState.IsValid)
        {
            switch (category)
            {
                case 1:
                {
                    checkInsertion = db.InsertData(nationalID, name, age, Email, password, "Patient");
                    if (checkInsertion is not null)
                    {
                        //ErrorMSG = "The user Exists";
                        //return Page();
                        return RedirectToPage("Index", new { ErrorMSG = "The user Exists" });
                    }

                    else
                    {
                        return RedirectToPage("/completeInfo", new { NationalID = nationalID });
                    }
                }
                case 2:
                {
                    db.InsertData(nationalID, name, age, Email, password, "Dentist");
                    return RedirectToPage("/Dentist main");   
                }
                case 3:
                {
                    db.InsertData(nationalID, name, age, Email, password, "Receptionist");
                    return RedirectToPage("/Reception");
                }
                case 4:
                {
                    db.InsertData(nationalID, name, age, Email, password, "Nurse"); 
                    return RedirectToPage("/Nurses");
                }
                case 6:
                {
                    db.InsertData(nationalID, name, age, Email, password, "Intern"); 
                    return RedirectToPage("/Intern");
                }

        }
            // if (category == 1)
            // {
            //     checkInsertion=db.InsertData(nationalID, name, age, Email, password,"Patient");
            //     if (checkInsertion is not null)
            //     {
            //         return Page();
            //     }
            //        
            //     else
            //     {
            //         return RedirectToPage("/completeInfo", new { NationalID = nationalID });
            //     }
            //     //db.InsertData();what if we intialize data before the if condition to remove redundancy 
            //     //so insert data will not contain the user type and create another function to insert the type
            // }
            // else if(category==2)
            // {
            //     db.InsertData(nationalID, name, age, Email, password, "Dentist");
            //     return RedirectToPage("/DenstistProfile"); //Just for now 
            // }
            // else if(category==3)
            // {
            //     db.InsertData(nationalID, name, age, Email, password, "Receptionist");
            //     return RedirectToPage("Temp");
            // }
            // else if (category == 4)
            // {
            //     db.InsertData(nationalID, name, age, Email, password, "Nurse");
            //     return RedirectToPage("Temp");
            // }
            // else if (category == 5)
            // {
            //     db.InsertData(nationalID, name, age, Email, password, "Admin");
            //     return RedirectToPage("Temp");
            // }
            // else
            // {
            //     return Page();
            // }
        }
        else
        {
            return Page();
        }

        return Page();
    }
}