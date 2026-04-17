using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class ViewTestimonials : System.Web.UI.Page
    {
        private string _conString = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTestimonials();
            }
        }

        private void BindTestimonials()
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                // Updated query to fetch all testimonials
                string query = "SELECT title, message FROM tblTestimonial";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        rptTestimonials.DataSource = reader;
                        rptTestimonials.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}

