using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class ManageSubscriptions : System.Web.UI.Page
    {
        private string _conString = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] == null)
            {
                Response.Redirect("login.aspx"); // Redirect to login if not logged in
            }

            if (!IsPostBack)
            {
                LoadSubscriptionRequests();
            }
        }

        private void LoadSubscriptionRequests()
        {
            int tutorId = (int)Session["tid"];

            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = @"
                    SELECT s.Student_Id, s.firstname + ' ' + s.lastname AS Student_Name, sc.Studentcourse_Id, sc.Course_Id
                    FROM tblStudentcoursesubscription sc
                    JOIN tblstudent s ON sc.Student_Id = s.Student_Id
                    WHERE sc.Subscription = 0"; // 0 indicates pending subscription requests

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptSubscriptions.DataSource = dt;
                    rptSubscriptions.DataBind();
                }
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int studentcourseId = Convert.ToInt32(btn.CommandArgument);

            UpdateSubscriptionStatus(studentcourseId, 1); // 1 indicates accepted

            // Retrieve student email and send acceptance email
            string studentEmail = GetStudentEmailBySubscriptionId(studentcourseId);
            SendEmail(studentEmail, "Subscription Accepted", "Your subscription request has been accepted.");

            LoadSubscriptionRequests(); // Refresh the list
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int studentcourseId = Convert.ToInt32(btn.CommandArgument);

            UpdateSubscriptionStatus(studentcourseId, 2); // 2 indicates rejected

            // Retrieve student email and send rejection email
            string studentEmail = GetStudentEmailBySubscriptionId(studentcourseId);
            SendEmail(studentEmail, "Subscription Rejected", "Your subscription request has been rejected.");

            LoadSubscriptionRequests(); // Refresh the list
        }

        private void UpdateSubscriptionStatus(int studentcourseId, int status)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "UPDATE tblStudentcoursesubscription SET Subscription = @status WHERE Studentcourse_Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", studentcourseId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string GetStudentEmailBySubscriptionId(int studentcourseId)
        {
            string email = null;

            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = @"
                    SELECT s.email
                    FROM tblStudentcoursesubscription sc
                    JOIN tblstudent s ON sc.Student_Id = s.Student_Id
                    WHERE sc.Studentcourse_Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentcourseId);

                    conn.Open();
                    email = (string)cmd.ExecuteScalar();
                }
            }

            return email;
        }

        private void SendEmail(string toAddress, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Replace with your SMTP server

                mail.From = new MailAddress("joypaultayshi@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                smtpClient.Port = 587; // Set the port number (e.g., 587 for TLS)
                smtpClient.Credentials = new System.Net.NetworkCredential("username", "password"); // SMTP credentials
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log to file, show error message)
                // For simplicity, just write to debug output
                System.Diagnostics.Debug.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
