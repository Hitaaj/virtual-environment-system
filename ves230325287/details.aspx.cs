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
    public partial class details : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getCourselist();
            }
        }
        private void getCourselist()
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);

            int qs = Convert.ToInt32(Request.QueryString["id"]);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM tblCourses where Course_Id = " + qs;
            cmd.Connection = con;


            // Create DataAdapter named dad (Refer to slide 7)
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create DataSet/DataTable named dtMovies
            DataTable dtcourses = new DataTable();
            //Populate the datatable or dataset using the Fill()
            using (da)
            {
                da.Fill(dtcourses);
            }
            //Bind datatable or dataset to gridview
            DetailsView1.DataSource = dtcourses;
            DetailsView1.DataBind();

        }



    }
}