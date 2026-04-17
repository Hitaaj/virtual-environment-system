using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class posttestimonial : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure the user is logged in and has a student ID in session
            if (Session["sid"] == null)
            {
                Response.Redirect("stulogin.aspx"); // Redirect to login if not logged in
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string message = txtMessage.Text.Trim();
            int studentId = (int)Session["sid"]; // Retrieve student ID from session

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                lblMessage.Text = "Title and Message are required.";
                return;
            }

            // Connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tbltestimonial (message, title, Student_Id) VALUES (@message, @title, @Student_Id)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@Student_Id", studentId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Testimonial posted successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}