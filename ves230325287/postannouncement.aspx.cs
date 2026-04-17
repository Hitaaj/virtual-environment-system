using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using Antlr.Runtime.Tree;
using System.Threading.Tasks;

namespace ves230325287
{
    public partial class postannouncement : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the tutor is logged in
            if (Session["tid"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                lblMessage.Text = "Description cannot be empty.";
                return;
            }

            string description = txtDescription.Text;
            DateTime dateposted = DateTime.Now;
            int tutorId = (int)Session["tid"];

            string constr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO tblAnnouncement (description, dateposted, Tutor_Id) VALUES (@description, @dateposted, @Tutor_Id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@dateposted", dateposted);
                    cmd.Parameters.AddWithValue("@Tutor_Id", tutorId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblMessage.Text = "Announcement posted successfully.";
                    txtDescription.Text = string.Empty;
                }
            }
        }
    }
}