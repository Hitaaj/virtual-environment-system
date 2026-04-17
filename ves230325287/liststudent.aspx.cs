using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Microsoft.Ajax.Utilities;
using System.Drawing;


namespace ves230325287

{
    public partial class liststudent : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
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
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM tblStudent";
            cmd.Connection = con;

            // Create DataAdapter named dad (Refer to slide 7)
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create DataSet/DataTable named dtMovies
            DataTable dtstudent = new DataTable();
            //Populate the datatable or dataset using the Fill()
            using (da)
            {
                da.Fill(dtstudent);
            }
            //Bind datatable or dataset to gridview
            gvs.DataSource = dtstudent;
            gvs.DataBind();
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
                //This replaces <td> with <th> and adds the scope attribute 
                gvs.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements 
                gvs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}