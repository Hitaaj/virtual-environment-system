using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ves230325287
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["aid"] != null)
            {

                lgregis.CssClass = "#";
                lbllgged.CssClass = "btn btn-outline-success text-Black col-4";
                //add the session name 

                btnlgout.Visible = true;
                lbllgged.Text = "Welcome " + Session["email"];
              
            }
        }

        protected void btnlgout_Click(object sender, EventArgs e)
        {
            lgout();
        }

        void lgout()
        {
            if (Session["adminemail"] != null)
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