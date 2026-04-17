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
    public partial class viewannouncement : System.Web.UI.Page
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
                BindAnnouncements();
            }
        }

        private void BindAnnouncements()
        {
            string constr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT a.Announcement_Id, a.description, a.dateposted, t.firstname + ' ' + t.lastname AS TutorName FROM tblAnnouncement a JOIN tbltutor t ON a.Tutor_Id = t.Tutor_Id ORDER BY a.dateposted DESC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvAnnouncements.DataSource = dt;
                        gvAnnouncements.DataBind();
                    }
                }
            }
        }
    }
}