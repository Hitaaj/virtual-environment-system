using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ves230325287
{
    public partial class updateprofile : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Response.Redirect("~/stulogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadProfileData();
                }
            }
        }

        private void LoadProfileData()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                string query = "SELECT firstname, lastname, email, imageurl FROM tblstudent WHERE Student_Id=@Student_Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Student_Id", Session["sid"].ToString());

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFname.Text = reader["firstname"].ToString();
                            txtLname.Text = reader["lastname"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            string imageUrl = reader["imageurl"].ToString();

                            // Assuming you want to display the image
                            rptimg.DataSource = new DataTable(); // Clear previous data
                            rptimg.DataBind(); // Bind data
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string updateSQL = "UPDATE tblstudent SET firstname=@fn, lastname=@ln, email=@eml WHERE Student_Id=@Student_Id";
            using (SqlConnection con = new SqlConnection(_conString))
            {
                using (SqlCommand ucmd = new SqlCommand(updateSQL, con))
                {
                    ucmd.Parameters.AddWithValue("@fn", txtFname.Text);
                    ucmd.Parameters.AddWithValue("@ln", txtLname.Text);
                    ucmd.Parameters.AddWithValue("@eml", txtEmail.Text);
                    ucmd.Parameters.AddWithValue("@Student_Id", Session["sid"].ToString());

                    try
                    {
                        con.Open();
                        int updated = ucmd.ExecuteNonQuery();
                        lblmsg.Text = $"{updated} record(s) updated.";
                    }
                    catch (Exception ex)
                    {
                        lblmsg.Text = "Error updating: " + ex.Message;
                    }
                }
            }
        }
    }
}
