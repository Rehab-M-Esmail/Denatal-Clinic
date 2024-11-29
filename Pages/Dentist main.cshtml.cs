using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dental_clinic.Pages;
using System.ComponentModel.DataAnnotations;

public class Dentist_main : PageModel
{
        public DateTime SelectedDate { get; set; } = DateTime.Today;

       
        public List<Appointment> Appointments { get; set; } = new List<Appointment>
        {
            new Appointment
            {
                PatientName = "John Doe",
                Hour = "10:00 AM",
                SessionType = "Routine Checkup",
                PreviousAppointments = new List<string>{"2023-01-10", "2022-11-15"}
            },
            new Appointment
            {
                PatientName = "Jane Smith",
                Hour = "02:30 PM",
                SessionType = "Tooth Extraction",
                PreviousAppointments = new List<string>{"2022-09-05", "2022-06-20"}
            },
         
        };

        public class Appointment
        {
            public string PatientName { get; set; }
            public string Hour { get; set; }
            public string SessionType { get; set; }
            public List<string> PreviousAppointments { get; set; }
        }

        public void OnGet()
        {
           
        }
    }


