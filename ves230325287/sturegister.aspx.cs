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
    public partial class sturegister : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string filen = "avatar.png";
            //Check whether the fileupload contains a file
            if (fuppicture.HasFile)
            {
                if (CheckFileType(fuppicture.FileName))
                {
                    filen = Path.GetFileName(fuppicture.PostedFile.FileName);
                    fuppicture.PostedFile.SaveAs(Server.MapPath("~/images/") +
                    filen);
                }
            }
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.Text;
            scmd.Connection = con;
            //create a parameterized query for the username
            scmd.Parameters.AddWithValue("@em", txtemail.Text.Trim());

            //search for username from tbluser
            scmd.CommandText = "select* from tblstudent where email = @em";


            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = scmd.ExecuteReader();
            //Check if username already exists in the DB
            if (dr.HasRows)
            {
                lblmessage.Text = "Username Already Exist, Please Choose Another";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                txtemail.Focus();
            }
            else
            {
                //Ensure the DataReader is closed
                dr.Close();

              
                // Create another Command object for the insert statement
                SqlCommand icmd = new SqlCommand();
                icmd.Connection = con;
                icmd.CommandText = "INSERT INTO tblstudent (firstname, lastname, email, pwd, imageurl,status)  " +
                    "VALUES (@fn, @ln, @email,@pwd, @image, @status)";

                icmd.Parameters.AddWithValue("@fn", txtfn.Text.Trim());
                icmd.Parameters.AddWithValue("@ln", txtln.Text.Trim());
                //retrieve the country dropdown list value
                icmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                icmd.Parameters.AddWithValue("@pwd", Encrypt(txtpass.Text.Trim()));
                icmd.Parameters.AddWithValue("@image", filen);
                
               
                //add a method to encrypt your password
           
                //set the status to active or inactive
                icmd.Parameters.AddWithValue("@status", 1);

                icmd.CommandType = CommandType.Text;
                icmd.ExecuteNonQuery();
                //call the sendemail method
                sendemail();
                con.Close();
                Response.Redirect("~/stulogin");
            }

        }
        bool CheckFileType(string fileName)

        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
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
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (args.Value.Length < 7 || args.Value.Length > 12)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        private void sendemail()
        {
            string filen = "avatar.png";
            //Check whether the fileupload contains a file
            if (fuppicture.HasFile)
            {
                if (CheckFileType(fuppicture.FileName))
                {
                    filen = Path.GetFileName(fuppicture.PostedFile.FileName);
                }
            }
            SmtpSection smtpSection =
           (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");



            using (MailMessage m = new MailMessage(smtpSection.From, txtemail.Text.Trim()))
            {
                SmtpClient sc = new SmtpClient();
                try
                {
                    m.Subject = "This is a Test Mail";
                    m.IsBodyHtml = true;
                    StringBuilder msgBody = new StringBuilder();
                    msgBody.Append("Dear " + txtemail.Text + ", your registration is successful, thank you for signing up...");
                    //msgBody.Append(txtbody.Text.Trim());
                    m.Attachments.Add(new Attachment(Server.MapPath("~/images/") + filen));
                    msgBody.Append("<a href='https://" +
                   HttpContext.Current.Request.Url.Authority + "/stulogin'>Click here to login to...</ a > ");

                    m.Body = msgBody.ToString();
                    sc.Host = smtpSection.Network.Host;
                    sc.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new
                    NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    sc.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    sc.Credentials = networkCred;
                    sc.Port = smtpSection.Network.Port;
                    sc.Send(m);
                    Response.Write("Email Sent successfully");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}