using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class updatingprofile : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] == null)
            {
                Response.Redirect("~/login.aspx");
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
                string query = "SELECT firstname, lastname, email, imageurl FROM tbltutor WHERE Tutor_Id=@Tutor_Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Tutor_Id", Session["tid"].ToString());

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
            string updateSQL = "UPDATE tbltutor SET firstname=@fn, lastname=@ln, email=@eml WHERE Tutor_Id=@Tutor_Id";
            using (SqlConnection con = new SqlConnection(_conString))
            {
                using (SqlCommand ucmd = new SqlCommand(updateSQL, con))
                {
                    ucmd.Parameters.AddWithValue("@fn", txtFname.Text);
                    ucmd.Parameters.AddWithValue("@ln", txtLname.Text);
                    ucmd.Parameters.AddWithValue("@eml", txtEmail.Text);
                    ucmd.Parameters.AddWithValue("@Tutor_Id", Session["tid"].ToString());

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
