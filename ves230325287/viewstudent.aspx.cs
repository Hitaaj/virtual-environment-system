using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ves230325287
{
    public partial class viewstudent : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

            if (!Page.IsPostBack)
            {
                getviewstudent();
            }
        }

        private void getviewstudent()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblstudent", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtstudent = new DataTable();
                da.Fill(dtstudent);
                gvs.DataSource = dtstudent;
                gvs.DataBind();
            }
        }

        protected void gvs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvs.PageIndex = e.NewPageIndex;
            getviewstudent();
        }

        protected void gvs_PreRender(object sender, EventArgs e)
        {
            if (gvs.Rows.Count > 0)
            {
                gvs.UseAccessibleHeader = true;
                gvs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}
