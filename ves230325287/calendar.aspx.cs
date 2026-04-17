using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ves230325287
{
    public partial class calendar : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "Select a date to view available time slots.";
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            Label1.Text = "Selected Date: " + selectedDate.ToShortDateString();
            LoadAvailableSlots(selectedDate);
        }

        private void LoadAvailableSlots(DateTime selectedDate)
        {
            // Fetch available slots from the database
            string connString = ConfigurationManager.ConnectionStrings["vesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM tbltutorschedule WHERE Tutor_Id = @TutorId AND AvailableDate = @Date";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TutorId", 1); // Example tutor ID
                cmd.Parameters.AddWithValue("@Date", selectedDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}