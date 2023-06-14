using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class login : System.Web.UI.Page
{ 
    #region Global Variable
    string str;
    SqlCommand com;
    SqlConnection CS = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from LoginTable where EmailId='" + txtEmail.Text + "' and Password='" + txtPassword.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["Id"] = dt.Rows[0]["ID"].ToString();
                Session["Email"] = dt.Rows[0]["EmailId"].ToString();
                string Ulevel;
                Ulevel = dt.Rows[0][3].ToString().Trim();

                if (Ulevel == "C")
                {
                    Response.Redirect("~/Company/Dashboard.aspx");
                }
                if (Ulevel == "A")
                {
                    Session["Email"] = txtEmail.Text;
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }
                if (Ulevel =="U")
                {
                    Response.Redirect("~/HomePage.aspx");
                }

            }
            else
            {
                string message = "Invalid Username or Password !";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
    }
}