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

public partial class MyProfile : System.Web.UI.Page
{
    SqlCommand com;
    string str;
    SqlCommand cmd;
    String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlDataReader rdr;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Email"] != null)
        {
            if (!IsPostBack)
            {
                BindProfilePage();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        } 
    }

    private void BindProfilePage()
    {
        con.Open();
        string myquery = null;
        myquery = "select * from RegisterTable where EmailId='" + Session["Email"].ToString() + "'";
        SqlDataAdapter da = new SqlDataAdapter(myquery, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
        txtLastName.Text = dt.Rows[0]["LastName"].ToString();
        txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
        txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
        txtAddress.Text = dt.Rows[0]["Address"].ToString();
        ddlGender.Text = dt.Rows[0]["Gender"].ToString();
        txtState.Text = dt.Rows[0]["State"].ToString();
        txtCity.Text = dt.Rows[0]["City"].ToString();
        txtDOB.Text = dt.Rows[0]["DOB"].ToString();
        txtPincode.Text = dt.Rows[0]["Pincode"].ToString();
        txtEmailId.Text = dt.Rows[0]["EmailId"].ToString();
        txtPassword.Text = dt.Rows[0]["Password"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            string strQuery = "Update RegisterTable Set FirstName=@FirstName,LastName=@LastName,MotherName=@MotherName,FatherName=@FatherName,Address=@Address,Gender=@Gender,State=@State,City=@City,DOB=@DOB,Pincode=@Pincode,Password=@Password  Where EmailId='" + Session["Email"].ToString() + "' ";
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
            string message = "Update successfully!!";
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
            SqlCommand cmd1 = new SqlCommand("Update LoginTable Set Password ='" + txtPassword.Text + "' where UserType='U' And EmailId='" + Session["Email"].ToString() + "' ", con);
            cmd1.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return false;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}