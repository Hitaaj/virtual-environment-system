using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace ves230325287
{
    public partial class admin1 : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.Cookies["email"] != null && Request.Cookies["pass"] != null)
                {
                    txtEmail.Text = Request.Cookies["email"].Value;
                    txtPassword.Text = Response.Cookies["pass"].Value;

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection con = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM tbladmin WHERE email = @em AND password = @pwd";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@pwd", password);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    Response.Cookies["email"].Value = email;
                    Response.Cookies["pass"].Value = password;

                    if (RememberMe.Checked)
                    {
                        Response.Cookies["email"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-1);
                    }

                    Session["adminemail"] = email;
                    Session["aid"] = dr["id"];
                    Response.Redirect("~/admindefault");
                }
                else
                {
                    lblMessage.Text = "You are not registered or your account has been suspended!";
                }
                con.Close();
            }
        }
    }
}
