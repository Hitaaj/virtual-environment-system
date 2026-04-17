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
    public partial class managestudentaccounts : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT Student_Id, firstname, lastname, email, status FROM tblstudent", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvStudents.DataSource = dt;
                        gvStudents.DataBind();
                    }
                }
            }
        }

        protected void gvStudents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Freeze" || e.CommandName == "Unfreeze")
            {
                int studentId = Convert.ToInt32(e.CommandArgument);
                bool freeze = e.CommandName == "Freeze";

                string constr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "UPDATE tblstudent SET status = @status WHERE Student_Id = @Student_Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@status", freeze ? 0 : 1);
                        cmd.Parameters.AddWithValue("@Student_Id", studentId);
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