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
    public partial class tutormanagecourse : System.Web.UI.Page
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
              
                BindCategory();
               
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
            DataTable dtcategory = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dtcategory);
            }
            //Set the DataTable as the DataSource
            gvs.DataSource = dtcategory;
            gvs.DataBind();
        }
       
       
        protected void btnupdate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMsg.Text = "Please select a record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            bool IsUpdated = false;
            // Get the category ID from the textbox 
            int categoryid = Convert.ToInt32(txtCategoryId.Text);

            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                // Add UPDATE statement to update the category 
                cmd.CommandText = "UPDATE tblCategory SET Category_Name = @cname WHERE Category_Id = @cid";
                // Create the parameterized queries  
                cmd.Parameters.AddWithValue("@cid", categoryid);
                cmd.Parameters.AddWithValue("@cname", txtCategoryName.Text.Trim());

                cmd.Connection = con;
                con.Open();
                // Use Command method to execute UPDATE statement and return     
                // boolean if number of records UPDATED is greater than zero 
                IsUpdated = cmd.ExecuteNonQuery() > 0;
            }

            if (IsUpdated)
            {
                lblMsg.Text = txtCategoryName.Text + " Category updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                // Refresh the GridView by calling the BindCategory() 
                BindCategory();
            }
            else
            {
                lblMsg.Text = "Error while updating category " + txtCategoryName.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMsg.Text = "Please select a category to delete.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int categoryid = Convert.ToInt32(txtCategoryId.Text);

            using (SqlConnection con = new SqlConnection(_conString))
            {
                con.Open();

                // Check if the category is referenced in tblCourse
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblCourse WHERE Category_Id = @cid", con);
                checkCmd.Parameters.AddWithValue("@cid", categoryid);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    lblMsg.Text = "Cannot delete this category because it is referenced in one or more courses.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Proceed with deletion if no references found
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM tblCategory WHERE Category_Id = @cid", con);
                deleteCmd.Parameters.AddWithValue("@cid", categoryid);

                bool isDeleted = deleteCmd.ExecuteNonQuery() > 0;

                if (isDeleted)
                {
                    lblMsg.Text = txtCategoryName.Text + " category deleted successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    BindCategory();
                }
                else
                {
                    lblMsg.Text = "Error while deleting category " + txtCategoryName.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
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
         

            //Retrieve the Primary Key MovieId from the GridView
            txtCategoryId.Text =
(gvs.DataKeys[gvs.SelectedIndex].
Value.ToString());
            //Retrieve the Moviename from the GridView
            txtCategoryName.Text =
((Label)gvs.SelectedRow.FindControl("lblCourseName")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@cid", txtCategoryId.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tblCategory where Category_Id = @cid";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                //retrieving FIELD values and assign the form controls
                txtCategoryName.Text = dr["Category_Name"].ToString();


            }
            con.Close();
            btnAdd.Visible = false;
            btnupdate.Visible = true;
            btndelete.Visible = true;
            btncancel.Visible = true;
        }

        private void ResetAll()
        {
            btnAdd.Visible = true;
            btncancel.Visible = false;
            btndelete.Visible = false;
           
            txtCategoryName.Text = "";


        }
        protected void gvs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvs.PageIndex = e.NewPageIndex;
            BindCategory();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //set the IsAdded flag to false
            Boolean IsAdded = false;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //add INSERT statement to create new movie
            cmd.CommandText = "insert into tblCategory(Category_Name) " +
                "values (@cname)";
            //create Parameterized query to prevent sql injection by

            cmd.Parameters.AddWithValue("@cname", txtCategoryName.Text.Trim());

            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = txtCategoryName.Text + " category added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()

                BindCategory();
            }
            else
            {
                lblMsg.Text = "Error while adding category " + txtCategoryName.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();

        }
    }
}