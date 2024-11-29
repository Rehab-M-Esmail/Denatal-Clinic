using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
public class Nurses : PageModel
{
       public Nurse nurse { get; set; }
        public List<TreatmentRecord> TreatmentRecords { get; set; }

        public void OnGet()
        {
            nurse = new Nurse
            {
                Name = HttpContext.Session.GetString("Name"),
                PhoneNumber = HttpContext.Session.GetString("PhoneNumber")
            };

            TreatmentRecords = new List<TreatmentRecord>
            {
                new TreatmentRecord { Treatment = "Dental Checkup", TreatmentTime = "10:00 AM", ProcedureMaterial = "Toothbrush" },
                new TreatmentRecord { Treatment = "Root Canal", TreatmentTime = "2:30 PM", ProcedureMaterial = "Dental Drill" }
            };
        }
    
    public class Nurse
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class TreatmentRecord
    {
        public string Treatment { get; set; }
        public string TreatmentTime { get; set; }
        public string ProcedureMaterial { get; set; }
    }
}



