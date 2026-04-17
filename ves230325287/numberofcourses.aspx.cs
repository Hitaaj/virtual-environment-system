using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class numberofcourses : System.Web.UI.Page
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
                GetListCourse();
            }
        }

        private void GetListCourse()
        {
            // Create Connection
            using (SqlConnection con = new SqlConnection(_conString))
            {
                // Create Command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tblCourse";
                cmd.Connection = con;

                // Create DataAdapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Create DataTable
                DataTable dtcourse = new DataTable();

                // Fill DataTable
                da.Fill(dtcourse);

                // Bind DataTable to GridView
                gvs.DataSource = dtcourse;
                gvs.DataBind();

                // Update the course count label
                lblCourseCount.Text = $"Total Number of Courses: {dtcourse.Rows.Count}";
            }
        }

        protected void gvs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvs.PageIndex = e.NewPageIndex;
            GetListCourse();
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
