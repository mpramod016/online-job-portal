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
using System.Security.Cryptography;
using System.Text;
public partial class Register : System.Web.UI.Page
{
    SqlCommand com;
    string str;
    String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlConnection con1 = new SqlConnection(CS);
            con1.Open();
            str = "select count(*) from RegisterTable where EmailId='" + txtEmailId.Text + "'";
            com = new SqlCommand(str, con1);
            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                string message = "Email Id already register";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                txtEmailId.Text = "";
                return;
            }
            else
            {
                string strQuery = "insert into RegisterTable(FirstName,LastName,MotherName,FatherName,Address,Gender,State,City,DOB,Pincode,EmailId,Password) values (@FirstName,@LastName,@MotherName,@FatherName,@Address,@Gender,@State,@City,@DOB,@Pincode,@EmailId,@Password)";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text;
                cmd.Parameters.Add("@MotherName", SqlDbType.NVarChar).Value = txtMotherName.Text;
                cmd.Parameters.Add("@FatherName", SqlDbType.NVarChar).Value = txtFatherName.Text;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = ddlGender.Text;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = txtState.Text;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = txtDOB.Text;
                cmd.Parameters.Add("@Pincode", SqlDbType.NVarChar).Value = txtPincode.Text;
                cmd.Parameters.Add("@EmailId", SqlDbType.NVarChar).Value = txtEmailId.Text;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text;
                InsertUpdateData(cmd);
                string message = "Your registration successfully!!";
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

    private void Clear()
    {
        txtAddress.Text = "";
        txtCity.Text = "";
        txtDOB.Text = "";
        txtEmailId.Text = "";
    }
    private Boolean InsertUpdateData(SqlCommand cmd)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("insert into LoginTable (EmailId,Password,UserType) Values ('" + txtEmailId.Text + "','" + txtPassword.Text + "','U')", con);
            cmd1.ExecuteNonQuery();
            //Response.Redirect("Login.aspx");
            return true;
        }
        catch (Exception ex)
        {
            string formatError = ex.Message;
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(formatError);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
            return false;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}