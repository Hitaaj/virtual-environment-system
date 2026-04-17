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
    public partial class numberofstudents : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("~/admin.aspx");
            }

            if (!Page.IsPostBack)
            {
                getliststudent();
            }
        }

        private void getliststudent()
        {
            // Create Connection
            using (SqlConnection con = new SqlConnection(_conString))
            {
                // Create Command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tblStudent";
                cmd.Connection = con;

                // Create DataAdapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Create DataTable
                DataTable dtstudent = new DataTable();

                // Fill DataTable
                da.Fill(dtstudent);

                // Bind DataTable to GridView
                gvs.DataSource = dtstudent;
                gvs.DataBind();

                // Update the student count label
                lblStudentCount.Text = $"Total Number of Students: {dtstudent.Rows.Count}";
            }
        }

        protected void gvs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvs.PageIndex = e.NewPageIndex;
            getliststudent();
        }

        protected void gvs_PreRender(object sender, EventArgs e)
        {
            if (gvs.Rows.Count > 0)
            {
                // This replaces <td> with <th> and adds the scope attribute 
                gvs.UseAccessibleHeader = true;

                // This will add the <thead> and <tbody> elements 
                gvs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}