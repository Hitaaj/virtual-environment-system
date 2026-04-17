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
    public partial class managetutoraccounts : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the admin is logged in
            if (Session["aid"] == null)
            {
                Response.Redirect("admin.aspx");
            }

            if (!IsPostBack)
            {
                BindStudentAccounts();
            }
        }

        private void BindStudentAccounts()
        {
            string constr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Tutor_Id, firstname, lastname, email, status FROM tbltutor", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvs.DataSource = dt;
                        gvs.DataBind();
                    }
                }
            }
        }

        protected void gvs_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Freeze" || e.CommandName == "Unfreeze")
            {
                int TutorId = Convert.ToInt32(e.CommandArgument);
                bool freeze = e.CommandName == "Freeze";

                string constr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "UPDATE tbltutor SET status = @status WHERE Tutor_Id = @Tutor_Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@status", freeze ? 0 : 1);
                        cmd.Parameters.AddWithValue("@Tutor_Id", TutorId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                BindStudentAccounts();
            }
        }
    }
}