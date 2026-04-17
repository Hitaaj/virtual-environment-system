using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class subscribe : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT c.Course_Id, c.Course_Name, t.firstname + ' ' + t.lastname AS Tutor_Name FROM tblCourse c JOIN tbltutor t ON c.Tutor_Id = t.Tutor_Id", con);
                con.Open();
                gvCourses.DataSource = cmd.ExecuteReader();
                gvCourses.DataBind();
            }
        }

        protected void lnbsub_Click(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Response.Redirect("~/stulogin.aspx");
            }
            else
            {
                LinkButton btn = (LinkButton)sender;
                int cid = Convert.ToInt32(btn.CommandArgument.ToString());
                if (chkexist(cid))
                {
                    lblmsg.Text = "Already sent request for this course!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    btn.Text = "Request sent";
                }
                else
                {
                    SqlConnection con = new SqlConnection(_conString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into tblStudentcoursesubscription(Student_Id, Course_Id, Subscription) values (@sid, @cid, @status)";
                    cmd.Parameters.AddWithValue("@sid", Session["sid"]);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    string ownerEmail = GetEmail(cid);
                    SendEmail(ownerEmail);

                    btn.Text = "Request sent";
                    lblmsg.Text = "Request sent!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private bool chkexist(int x)
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("select * from tblStudentcoursesubscription where Course_Id=@cid and Student_Id=@sid", con);
                cmd.Parameters.AddWithValue("@sid", Session["sid"]);
                cmd.Parameters.AddWithValue("@cid", x);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr.HasRows;
            }
        }

        private string GetEmail(int courseId)
        {
            string ownerEmail = "";
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT email FROM tbltutor WHERE Tutor_Id = (SELECT Tutor_Id FROM tblCourse WHERE Course_Id = @courseId)", con);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    ownerEmail = result.ToString();
                }
            }
            return ownerEmail;
        }

        private void SendEmail(string ownerEmail)
        {
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(smtpSection.From);
                mailMessage.To.Add(new MailAddress(ownerEmail));
                mailMessage.Subject = "Access Request for Your Course";
                mailMessage.Body = "Dear course owner, <br /><br /> You have received an access request for your course.";
                mailMessage.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = smtpSection.Network.Host;
                    smtpClient.Port = smtpSection.Network.Port;
                    smtpClient.EnableSsl = smtpSection.Network.EnableSsl;
                    smtpClient.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    smtpClient.Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);

                    try
                    {
                        smtpClient.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        throw ex;
                    }
                }
            }
        }
    }
}
