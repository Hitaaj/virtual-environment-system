using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using Antlr.Runtime.Tree;
using System.Threading.Tasks;

namespace ves230325287
{
    public partial class login : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtpassword.Text.Trim();

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand
            {
                Connection = con,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM tbltutor WHERE email = @em AND pwd = @pwd AND status = @status"
            };

            cmd.Parameters.AddWithValue("@em", email);
            cmd.Parameters.AddWithValue("@pwd", Encrypt(password));
            cmd.Parameters.AddWithValue("@status", 1);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    Response.Cookies["email"].Value = email;
                    Response.Cookies["pass"].Value = password;

                    // Example: Remember me functionality can be implemented here
                    // if (chkRememberMe.Checked)
                    // {
                    //     Response.Cookies["userun"].Expires = DateTime.Now.AddDays(30);
                    //     Response.Cookies["userpass"].Expires = DateTime.Now.AddDays(30);
                    // }

                    Session["tutoremail"] = email;
                    Session["tid"] = dr["Tutor_Id"];

                    Response.Redirect("~/default");
                }
                con.Close();
            }
            else
            {
                lblMessage.Text = "You are not registered or your account has been suspended!";
            }
        }

        public string Encrypt(string clearText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new
               byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    // encoding using key
                    using (CryptoStream cs = new CryptoStream(ms,
                   encryptor.CreateEncryptor(), CryptoStreamMode.Write))

                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}