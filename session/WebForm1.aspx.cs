using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration; 

namespace session
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHRUVIN\source\repos\session\session\App_Data\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/WebForm1.aspx");
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            string dhr = "select count(*) from Dhruvindbase where user_name='" + txtuser.Text + "'and password_='" + txtpassword.Text + "'";
            SqlCommand cmd = new SqlCommand(dhr, con);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1" )
            {
                Session["User"] = txtuser.Text;
                Response.Redirect("~/Welcome.aspx");
            }
            else
            {
                Response.Write("your username or password is incorrect");
            }
        }
    }
}