using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace dental_clinic.Pages;

public class Appointment : PageModel
{
    public void OnGet()
    {
        
    }

/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace dentalGUI.Pages //howa da
{
    public class AppointmentModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}*/


        // Replace with your actual database connection string
        private const string ConnectionString = "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;";

        // This method is called when the form is submitted
        public IActionResult OnPost(
            [Required] string date,
            [Required] string hour,
            [Required] string patientName,
            [Required] string session,
            [Required] string paymentWay,
            [Required] string dentist)
        {
            // Check if the submitted form data is valid
            if (ModelState.IsValid)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        // Create a command to insert data into the database
                        using (var command = new SqlCommand(
                            "INSERT INTO Appointments (Date, Hour, PatientName, Session, PaymentWay, Dentist) " +
                            "VALUES (@Date, @Hour, @PatientName, @Session, @PaymentWay, @Dentist)", connection))
                        {
                            // Add parameters to the command
                            command.Parameters.AddWithValue("@Date", DateTime.Parse(date));
                            command.Parameters.AddWithValue("@Hour", hour);
                            command.Parameters.AddWithValue("@PatientName", patientName);
                            command.Parameters.AddWithValue("@Session", session);
                            command.Parameters.AddWithValue("@PaymentWay", paymentWay);
                            command.Parameters.AddWithValue("@Dentist", dentist);

                            // Execute the command
                            command.ExecuteNonQuery();
                        }
                    }

                    // Redirect to a success page or return a different view
                    return RedirectToPage("/Success");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, log, or return an error view
                    Console.WriteLine(ex.Message);
                    return Page();
                }
            }

            // If ModelState is not valid, redisplay the page with errors
            return Page();
        }
    }
