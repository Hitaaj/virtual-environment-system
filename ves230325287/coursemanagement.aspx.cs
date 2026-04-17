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
    public partial class coursemanagement : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["tid"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!Page.IsPostBack)
            {
                BindCourse();
                BindCategory();
                ListItem li = new ListItem("Select Category", "-1");
                ddlCategory.Items.Insert(0, li);
            }
        }

        private void BindCategory()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblCategory";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dtcat = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dtcat);
            }
            //Set the DataTable as the DataSource
            ddlCategory.DataSource = dtcat;
            //assign the FIELD values to the dropdown 
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "Category_Id";
            ddlCategory.DataBind();
        }
        private void BindCourse()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblCourse";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dtcourse = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dtcourse);
            }

            //Set the DataTable as the DataSource

            gvs.DataSource = dtcourse;
            gvs.DataBind();
        }
        protected void btnAddcourse_Click(object sender, EventArgs e)
        {
            string strDate = txtStartdate.Text;
            DateTime dt = Convert.ToDateTime(strDate);
            String filen = "avatar.jpg";

            //check if the fileupload contains a file before uploading
            if (fuimage.HasFile)
            {
                filen = Path.GetFileName(fuimage.PostedFile.FileName);
                fuimage.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }
            //check if the fileupload contains a file before uploading

            //set the IsAdded flag to false
            Boolean IsAdded = false;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //add INSERT statement to create new movie
            cmd.CommandText = "insert into tblCourse(Category_Id, COurse_Name, description, aims, start_date, end_date, image, Tutor_Id) " +
                "values (@cid, @coursename, @desc, @aims, @startdate, @enddate, @image, @tutor)";
            //create Parameterized query to prevent sql injection by
            cmd.Parameters.AddWithValue("@cid", ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@coursename", txtCourseName.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtDesc.Text.Trim());
            cmd.Parameters.AddWithValue("@aims", txtAim.Text.Trim());
            cmd.Parameters.AddWithValue("@startdate", dt);
            cmd.Parameters.AddWithValue("@enddate", dt);

            cmd.Parameters.AddWithValue("@image", filen);

            cmd.Parameters.AddWithValue("@tutor", Session["tid"]);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = txtCourseName.Text + " course added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()

                BindCourse();
            }
            else
            {
                lblMsg.Text = "Error while adding course " + txtCourseName.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Boolean IsUpdated = false;
            //get the movieid from the textbox 
            int courseid = Convert.ToInt32(txtCourseId.Text);

            SqlConnection con = new SqlConnection(_conString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add UPDATE statement to update the movie 
            cmd.CommandText = "update tblCourse set Course_Name=@coursename, description=@desc, aims=@aims, image=@image where Course_Id=@crsid";
            //Create the parameterized queries  
            cmd.Parameters.AddWithValue("@crsid", courseid);
            cmd.Parameters.AddWithValue("@coursename", txtCourseName.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtDesc.Text.Trim());
            cmd.Parameters.AddWithValue("@aims", txtAim.Text.Trim());




            string filen = string.Empty;

            if (!string.IsNullOrEmpty(Image1.ImageUrl) && Image1.ImageUrl.Length > 8)
            {
                filen = Image1.ImageUrl.Substring(8);
            }
            else
            {
                filen = "default.jpg"; // or any default image file you prefer
            }


            if (fuimage.HasFile)
            {

                filen = Path.GetFileName(fuimage.PostedFile.FileName);
                fuimage.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);

            }


            cmd.Parameters.AddWithValue("@image", filen);


            cmd.Connection = con;
            con.Open();
            //use Command method to execute UPDATE statement and return     
            //boolean if number of records UPDATED is greater than zero 
            IsUpdated = cmd.ExecuteNonQuery() > 0;

            con.Close();

            if (IsUpdated)
            {
                lblMsg.Text = txtCourseName.Text + " Course updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData() 
                BindCourse();
            }
            else
            {
                lblMsg.Text = "Error while updating course " + txtCourseName.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                lblMsg.Text = "Please select a course to delete.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int courseId = Convert.ToInt32(txtCourseId.Text);
            bool isDeleted = false;

            using (SqlConnection con = new SqlConnection(_conString))
            {
                con.Open();

                // Check for associated records in tblmaterial table
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblmaterial WHERE Course_Id = @courseid", con);
                checkCmd.Parameters.AddWithValue("@courseid", courseId);
                int materialCount = (int)checkCmd.ExecuteScalar();

                // Delete associated materials first
                if (materialCount > 0)
                {
                    SqlCommand deleteMaterialsCmd = new SqlCommand("DELETE FROM tblmaterial WHERE Course_Id = @courseid", con);
                    deleteMaterialsCmd.Parameters.AddWithValue("@courseid", courseId);
                    deleteMaterialsCmd.ExecuteNonQuery();
                }

                // Proceed with deleting the course
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM tblcourse WHERE Course_Id = @courseid", con);
                deleteCmd.Parameters.AddWithValue("@courseid", courseId);

                isDeleted = deleteCmd.ExecuteNonQuery() > 0;
            }

            if (isDeleted)
            {
                lblMsg.Text = txtCourseName.Text + " course deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindCourse();
            }
            else
            {
                lblMsg.Text = "Error deleting course " + txtCourseName.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            ResetAll();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            Image1.Visible = true;

            //Retrieve the Primary Key MovieId from the GridView
            txtCourseId.Text =
(gvs.DataKeys[gvs.SelectedIndex].
Value.ToString());
            //Retrieve the Moviename from the GridView
            txtCourseName.Text =
((Label)gvs.SelectedRow.FindControl("lblCourseName")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@cid", txtCourseId.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tblcategory where Category_Id = @cid";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                //retrieving FIELD values and assign the form controls
                ddlCategory.SelectedIndex = Convert.ToInt32(dr["Category_Id"]);

                txtDesc.Text = dr["description"].ToString();
                txtAim.Text = dr["aims"].ToString();

                Image1.ImageUrl = "~/images/" + dr["image"].ToString();

            }
            con.Close();
            btnAddcourse.Visible = false;
            btnupdate.Visible = true;
            btndelete.Visible = true;
            btncancel.Visible = true;
        }

        private void ResetAll()
        {
            btnAddcourse.Visible = true;
            btncancel.Visible = false;
            btndelete.Visible = false;
            ddlCategory.SelectedIndex = 0;
            txtCourseName.Text = "";

            txtDesc.Text = "";
            txtAim.Text = "";

            Image1.ImageUrl = "";

        }
        protected void gvs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvs.PageIndex = e.NewPageIndex;
            BindCourse();
        }
    }
}