using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace dental_clinic.Models
{
    public class DataBase
    {
        public SqlConnection con = new SqlConnection();

        public DataBase()
        {
            string conSTR = " Data Source=localhost;Initial Catalog=dentalclinic; User id=sa ;Password=Rehab123;";
            con = new SqlConnection(conSTR);
        }

        public DataTable Returninfo(string Email)
        {
            DataTable dt = new DataTable();
            string Query = $"SELECT User_Name, Age,NationalId,Email FROM UserAccount where Email= '{Email}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                dt.Load(cmd.ExecuteReader());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;

        }

        public DataTable ReturnextraData(int patientId)
        {
            DataTable dt = new DataTable();
            string Query = $"SELECT Gender,City,Street from Pat where PatientId = {patientId}";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                dt.Load(cmd.ExecuteReader());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;

        }

        public DataTable Returndoctors()
        {
            DataTable dt = new DataTable();
            string Query = "SELECT User_Name, Email FROM UserAccount where User_Type='dentist'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public DataTable ReturnResults(string tableName)
        {
            DataTable dt = new DataTable();
            string query = "Select User_Name,Email, from " + tableName;//Write the query
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
               con.Close(); 
            }
            return dt;

        }
        

        public int? EditName(string Email, string newName)
        {
            int answer;
            string query = $"UPDATE UserAccount SET User_Name ='{newName}' where Email='{Email}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                answer = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close(); 
            }
            return answer;
        }
        public void EditEmail(string oldEmail, string newEmail)
        {
            string query = $"UPDATE UserAccount SET Email ='{oldEmail}' where Email='{newEmail}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close(); 
            }
            
        }
        public void EditAge(int newAge, string Email)
        {
            string query = $"UPDATE UserAccount SET Age ={newAge} where Email='{Email}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close(); 
            }
            
        }
        public void EditPassword(string newPass, string Email)
        {
            string query = $"UPDATE UserAccount SET User_PassWord ='{newPass}' where Email='{Email}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close(); 
            }
            
        }
        public DataTable returnRecepContacts()
        {
            DataTable dt = new DataTable();
            string query =
                "select UserAccount.User_Name,Phone_number from Reception inner join Staff on Reception_ID=clinic_id " +
                "inner join UserAccount on Staf_N_ID=NationalId";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public int ReturnID(string Email)
        {
            int Dscalar;
            string query = $"SELECT PatientId from Pat where PatientNationalId=(select NationalId from UserAccount where Email='{Email}')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                Dscalar= (int)cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close(); 
            }

            return Dscalar;

        }
        public DataTable ReturnHistory(int patientID)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT dentist_id,day#,Hour#,payment,Rating,Review from Appointments where patient_ID={patientID}";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        public string? InsertData(int nId,string name,int age, string email,string password,string type)
        {
            string answer=null;
            string query ="INSERT INTO UserAccount(NationalId,User_Name,Age,Email,User_Password,User_Type) VALUES(@NID,@Name,@Age,@Email,@Pass,@type)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NID", nId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                answer = e.Message;
            }
            finally
            {
                con.Close();
            }
            return answer;
        }

        public void AddPatient(String Gender, string city, string street, int nationalID)
        {
            string query =
                $"INSERT INTO Pat(Gender,City,Street,PatientNationalId,PatientId) VALUES(@gender,@city,@street,@NID,(select count(*) from Pat)+1)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gender", Gender);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@NID", nationalID);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public string? InsertContacts(int patientID, int phone)
        {
            string answer=null;
            string query = $"INSERT INTO Patient_Contact(PatientId,Contact) VALUES(@ID,@phonenum)";
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", patientID);
                cmd.Parameters.AddWithValue("@phonenum", phone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                answer = e.Message;
            }
            finally
            {
                con.Close();
            }
            return answer;
        }

        public void AddReview(int patientID,int ID,string review,string Date)
        {
            string query = $"UPDATE Appointments SET Review='{review}' WHERE patient_id={patientID} and dentist_id={ID} and day#='{Date}'\r\n";
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public string checklogin(string email, string password)
        {
            string answer;
            string query = $"SELECT User_Type from UserAccount where Email='{email}' and User_PassWord ='{password}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                answer = (string)cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return answer;

        }

        public DataTable services()
        {
            DataTable dt = new DataTable();
            string query = $"select UserAccount.User_Name,ServiceName from Dentist inner join Staff on ClinicID=clinic_id inner join UserAccount on Staf_N_ID=NationalId";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public DataTable returnContact(int patientID)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT Contact from Patient_Contact where PatientId={patientID}";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
    }
}