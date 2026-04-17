using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class viewcourses : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the student is logged in
            if (Session["sid"] == null)
            {
                Response.Redirect("stulogin.aspx");
            }

            if (!IsPostBack)
            {
                BindCourses();
            }
        }

        private void BindCourses()
        {
            string constr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = @"
                SELECT 
                    Course_Id, 
                    Course_name, 
                    description, 
                    start_date, 
                    end_date, 
                    aims, 
                    image 
                FROM tblCourse 
                WHERE status = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvCourses.DataSource = dt;
                        gvCourses.DataBind();
                    }
                }
            }
        }
    }
}
