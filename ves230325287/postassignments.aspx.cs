using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class postassignments : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            string connStr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Course_Id, Course_name FROM tblCourse";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlCourses.DataSource = reader;
                ddlCourses.DataTextField = "Course_name";
                ddlCourses.DataValueField = "Course_Id";
                ddlCourses.DataBind();
                reader.Close();
            }
            ddlCourses.Items.Insert(0, new ListItem("Select Course", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Uploads/") + fileName;

                    // Save the file
                    fileUpload.SaveAs(filePath);

                    // Store the file path in the database
                    string documentPath = "~/Uploads/" + fileName;

                    string connStr = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string query = "INSERT INTO tblAssignment (title, description, deadline, Tutor_Id, Course_Id, document) VALUES (@title, @description, @deadline, @Tutor_Id, @Course_Id, @document)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@deadline", DateTime.Parse(txtDeadline.Text));
                        cmd.Parameters.AddWithValue("@Tutor_Id", 1); // Replace with actual Tutor_Id
                        cmd.Parameters.AddWithValue("@Course_Id", ddlCourses.SelectedValue);
                        cmd.Parameters.AddWithValue("@document", documentPath);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    litMessage.Text = "<p>Assignment posted successfully.</p>";
                    ClearForm();
                }
                else
                {
                    litMessage.Text = "<p>Please upload a document.</p>";
                }
            }
        }


        private void ClearForm()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtDeadline.Text = "";
            ddlCourses.SelectedIndex = 0;
            fileUpload.Attributes.Clear(); // Clear the file upload control
        }
    }
}