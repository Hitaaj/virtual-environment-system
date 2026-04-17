using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ves230325287;

namespace ves230325287
{
    public partial class tutorpostsmaterials : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["tid"] == null)
            {
                Response.Redirect("~/login");
            }

            if (!IsPostBack)
            {
                BindMaterialType();
                BindCourses();
                ListItem li = new ListItem("Select Course", "-1");
                ddlCourse.Items.Insert(0, li);
                ListItem li2 = new ListItem("Select Material Type", "-1");
                ddlMaterial.Items.Insert(0, li2);
            }
        }

        private void BindMaterialType()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblmaterialtype", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlMaterial.DataSource = dt;
                ddlMaterial.DataTextField = "type_name";
                ddlMaterial.DataValueField = "Type_Id";
                ddlMaterial.DataBind();
            }
        }

        private void BindCourses()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCourse", con);
                // Use the actual tutor_id from the session or another source
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlCourse.DataSource = dt;
                ddlCourse.DataTextField = "Course_name";
                ddlCourse.DataValueField = "Course_Id";
                ddlCourse.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                if (CheckFileType(fileUpload.FileName))
                {
                    string customfolder = "~/uploads/" + Session["tid"] + "/doc/";
                    string folderPath = Server.MapPath(customfolder);

                    using (SqlConnection con = new SqlConnection(_conString))
                    {
                        SqlCommand cmd = new SqlCommand
                        {
                            Connection = con,
                            CommandType = CommandType.Text,
                            CommandText = "SELECT title FROM tblmaterial WHERE title = @title"
                        };

                        cmd.Parameters.AddWithValue("@title", txttitle.Text.Trim());

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            lblMessage.Text = "Choose Another Filename";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            reader.Close();

                            Directory.CreateDirectory(folderPath);
                            string filePath = Path.Combine(folderPath, fileUpload.FileName);
                            fileUpload.SaveAs(filePath);

                            SqlCommand cmd1 = new SqlCommand
                            {
                                Connection = con,
                                CommandType = CommandType.Text,
                                CommandText = "INSERT INTO tblmaterial (Type_Id, Course_Id, document, title, status, Tutor_Id) " +
                                              "VALUES (@type_id, @crs_id, @document, @title,@sts, @tutor)"
                            };

                            cmd1.Parameters.AddWithValue("@type_id", ddlMaterial.SelectedValue);
                            cmd1.Parameters.AddWithValue("@crs_id", ddlCourse.SelectedValue);
                            cmd1.Parameters.AddWithValue("@document", customfolder + fileUpload.FileName);
                            cmd1.Parameters.AddWithValue("@title", txttitle.Text.Trim());
                            cmd1.Parameters.AddWithValue("@sts", 1);
                            cmd1.Parameters.AddWithValue("@tutor", Session["tid"]);

                            cmd1.ExecuteNonQuery();
                            lblMessage.Text = "File has been successfully uploaded!";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid file type!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please select a file to upload!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            ResetAll();
        }

        private bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".doc":
                case ".docx":
                case ".pdf":
                case ".txt":
                case ".csv":
                    return true;
                default:
                    return false;
            }
        }
        private void ResetAll()
        {
            ddlCourse.SelectedIndex = 0;
            ddlMaterial.SelectedIndex = 0;
            lblMaterial.Text = "";

        }
    }
}