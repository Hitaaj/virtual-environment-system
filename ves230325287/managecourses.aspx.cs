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

namespace ves230325287
{
    public partial class managecourses : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourseData();
                BindCategory();
                ListItem li = new ListItem("Select Category", "-1");
                ddlcat.Items.Insert(0, li);
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
            ddlcat.DataSource = dtcat;
            //assign the FIELD values to the dropdown 
            ddlcat.DataTextField = "Category_Name";
            ddlcat.DataValueField = "Category_Id";
            ddlcat.DataBind();
        }

        private void BindCourseData()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblCourses";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dtcourses = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dtcourses);
            }

            //Set the DataTable as the DataSource

            gvs.DataSource = dtcourses;
            gvs.DataBind();
        }

        protected void gvs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvs.PageIndex = e.NewPageIndex;
            BindCourseData();
        }

        protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            Image1.Visible = true;
            Image2.Visible = true;
            //Retrieve the Primary Key CourseId from the GridView
            txtCourseId.Text =
(gvs.DataKeys[gvs.SelectedIndex].
Value.ToString());
            //Retrieve the Coursename from the GridView
            txtcoursename.Text =
((Label)gvs.SelectedRow.FindControl("lblCourseName")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the courseid parameter
            cmd.Parameters.AddWithValue("@cid", txtCourseId.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tblCourses where course_id = @cid";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                //retrieving FIELD values and assign the form controls
                ddlcat.SelectedIndex = Convert.ToInt32(dr["category_id"]);
                txtteacher.Text = dr["Teacher"].ToString();
                txtdesc.Text = dr["description"].ToString();
                txtbox.Text = dr["boxofficetotals"].ToString();
                chkstatus.Checked = (Boolean)dr["status"];
                Image1.ImageUrl = "~/images/" + dr["poster"].ToString();
                Image2.ImageUrl = "~/images/" +
                dr["schedule"].ToString().Substring(12);
            }
            con.Close();
            btnAddcourses.Visible = false;
            btnupdate.Visible = true;
            btndelete.Visible = true;
            btncancel.Visible = true;
        }

        private void ResetAll()
        {
            btnAddcourses.Visible = true;
            btncancel.Visible = false;
            btndelete.Visible = false;
            ddlcat.SelectedIndex = 0;
            txtcoursename.Text = "";
            txtteacher.Text = "";
            txtdesc.Text = "";
            txtbox.Text = "";
            chkstatus.Checked = false;
            Image1.ImageUrl = "";
            Image2.ImageUrl = "";
        }

        protected void btnAddcourses_Click(object sender, EventArgs e)
        {
            String filen = "avatar.jpg";
            String fileshe = "avatar2.jpg";
            //check if the fileupload contains a file before uploading
            if (fuposter.HasFile)
            {
                filen = Path.GetFileName(fuposter.PostedFile.FileName);
                fuposter.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }
            //check if the fileupload contains a file before uploading

            if (fuschedule.HasFile)
            {
                fileshe = Path.GetFileName(fuschedule.PostedFile.FileName);
                fuschedule.PostedFile.SaveAs(Server.MapPath("~/images/") +
                fileshe);
            }
            //set the IsAdded flag to false
            Boolean IsAdded = false;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //add INSERT statement to create new course
            cmd.CommandText = "insert into tblcourses (Category_Id, coursename, description, teacher, boxofficetotals, poster, schedule, status, tutor_id) values (@cid, @cname, @desc, @teacer, @box, @poster, @schedule, @status, @tutor)";
            //create Parameterized query to prevent sql injection by
            cmd.Parameters.AddWithValue("@cid", ddlcat.SelectedValue);
            cmd.Parameters.AddWithValue("@cname", txtcoursename.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtdesc.Text.Trim());
            cmd.Parameters.AddWithValue("@teacher", txtteacher.Text.Trim());
            cmd.Parameters.AddWithValue("@box", txtbox.Text.Trim());
            cmd.Parameters.AddWithValue("@poster", filen);
            cmd.Parameters.AddWithValue("@schedule", "../../images/" + fileshe);
            cmd.Parameters.AddWithValue("@status", chkstatus.Checked);
            cmd.Parameters.AddWithValue("@tutor", 1);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = txtcoursename.Text + " course added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindCourseData()

                BindCourseData();
            }
            else
            {
                lblMsg.Text = "Error while adding course " + txtcoursename.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //check whether the coursename textbox is empty 
            if (string.IsNullOrWhiteSpace(txtcoursename.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Boolean IsUpdated = false;
            //get the courseid from the textbox 
            int courseid = Convert.ToInt32(txtCourseId.Text);

            SqlConnection con = new SqlConnection(_conString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add UPDATE statement to update the course 
            cmd.CommandText = "update tblcourses set coursename=@cname, description=@desc, teacher=@teacher, boxofficetotals=@box, poster=@poster, schedule=@schedule, status=@status where course_id=@cid";
            //Create the parameterized queries  
            cmd.Parameters.AddWithValue("@cid", courseid);
            cmd.Parameters.AddWithValue("@cname", txtcoursename.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtdesc.Text.Trim());
            cmd.Parameters.AddWithValue("@teacher", txtteacher.Text.Trim());
            cmd.Parameters.AddWithValue("@box", txtbox.Text.Trim());

            String filen = Image1.ImageUrl.Substring(8);
            String fileshe = Image2.ImageUrl.Substring(8);
            if (fuposter.HasFile)
            {

                filen = Path.GetFileName(fuposter.PostedFile.FileName);
                fuposter.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);

            }

            if (fuschedule.HasFile)
            {

                fileshe = Path.GetFileName(fuschedule.PostedFile.FileName);
                fuschedule.PostedFile.SaveAs(Server.MapPath("~/images/") + fileshe);

            }

            cmd.Parameters.AddWithValue("@poster", filen);
            cmd.Parameters.AddWithValue("@schedule", "../../images/" + fileshe);
            cmd.Parameters.AddWithValue("@status", chkstatus.Checked);

            cmd.Connection = con;
            con.Open();
            //use Command method to execute UPDATE statement and return     
            //boolean if number of records UPDATED is greater than zero 
            IsUpdated = cmd.ExecuteNonQuery() > 0;

            con.Close();

            if (IsUpdated)
            {
                lblMsg.Text = txtcoursename.Text + " course updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindCourseData() 
                BindCourseData();
            }
            else
            {
                lblMsg.Text = "Error while updating course " + txtcoursename.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            //check whether the txtcoursename textbox is empty 
            if (string.IsNullOrWhiteSpace(txtcoursename.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Boolean IsDeleted = false;
            //get the courseid from the textbox 
            int mcourseid = Convert.ToInt32(txtCourseId.Text);

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add DELETE statement to delete the selected course 
            cmd.CommandText = "delete from tblcourses where course_id=@cid";
            //Create a parametererized query  
            cmd.Parameters.AddWithValue("@cid", courseid);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute DELETE statement and return     
            //Boolean True if number of records DELETED is greater than zero 
            IsDeleted = cmd.ExecuteNonQuery() > 0;
            con.Close();

            if (IsDeleted)
            {
                lblMsg.Text = txtcoursename.Text + " course deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindCourseData() 
                BindCourseData();
            }
            else
            {
                lblMsg.Text = "Error while deleting course" + txtcoursename.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
    }
}