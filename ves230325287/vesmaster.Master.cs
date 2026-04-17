using System;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class vesmaster : System.Web.UI.MasterPage
    {


        private string _conString =
WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] != null)
            {

                lgregis.CssClass = "#";
                lbllgged.CssClass = "btn btn-outline-success text-Black col-4";
                //add the session name 

                btnlgout.Visible = true;
                lbllgged.Text = "Welcome " + Session["email"];
                pnlcoursestu.Visible = true;
                pnlprofile.Visible = true;
                pnlstuevent.Visible = true;
                pnlprofile.Visible = true;
            }
            if (Session["tid"] != null)
            {

                lgregis.CssClass = "#";
                lbllgged.CssClass = "btn btn-outline-success text-Black col-4";
                btnlgout.Visible = true;
                lbllgged.Text = "Welcome " + Session["email"];
                //add the session name 
                pnlpost.Visible = true;
                pnltuevent.Visible = true;
                pnltuprofile.Visible = true;
            }

        }

        protected void btnlgout_Click(object sender, EventArgs e)
        {
            lgout();

        }


        void lgout()
        {
            if (Session["studentemail"] != null || Session["tutoremail"] != null)
            {
                //Remove all session
                Session.RemoveAll();
                //Destroy all Session objects
                Session.Abandon();
                //Redirect to homepage or login page
                Response.Redirect("~/default");
            }

        }

    }
}
