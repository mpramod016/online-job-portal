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

public partial class CompanyRegister : System.Web.UI.Page
{
    #region Global Variable
    string str;
    SqlCommand com;
    SqlConnection CS = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void Clear()
    {
        txtAddress.Text = "";
        txtCity.Text = "";
        txtCompany.Text = "";
        txtCompanyEmail.Text = "";
        txtCompanyWebsite.Text = "";
        txtPassword.Text = "";
        txtPincode.Text = "";
        txtState.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string filePath = FileUpload1.PostedFile.FileName;
        string filePath1 = FileUpload2.PostedFile.FileName;
        string filePath2 = fpImage.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string filename1 = Path.GetFileName(filePath1);
        string filename2 = Path.GetFileName(filePath2);
        string ext = Path.GetExtension(filename);
        string ext1 = Path.GetExtension(filename1);
        string ext2 = Path.GetExtension(filename2);
        string contenttype = String.Empty;
        string contenttype1 = String.Empty;
        string contenttype2 = String.Empty;
        switch (ext)
        {
            case ".pdf":
                contenttype = "file/pdf";
                break;
        }
        switch (ext1)
        {
            case ".pdf":
                contenttype1 = "file/pdf";
                break;
        }
        switch (ext2)
        {
            case ".jpg":
                contenttype2 = "image/jpg";
                break;
            case ".png":
                contenttype2 = "image/png";
                break;
        }
        if (contenttype != String.Empty && contenttype1 != String.Empty && contenttype2 != String.Empty)
        {
            String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlConnection con1 = new SqlConnection(CS);
                con1.Open(); 
                str = "select count(*) from LoginTable where EmailId='" + txtCompanyEmail.Text + "' And UserType='C'";
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
                    txtCompanyEmail.Text = "";
                    return;
                }
                else
                {

                    Stream fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    Stream fs1 = FileUpload2.PostedFile.InputStream;
                    BinaryReader br1 = new BinaryReader(fs1);
                    Byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);

                    Stream fs2 = fpImage.PostedFile.InputStream;
                    BinaryReader br2 = new BinaryReader(fs2);
                    Byte[] bytes2 = br2.ReadBytes((Int32)fs2.Length);

                    string strQuery = "insert into CompanyRegisterTable(OrganisationName,OrganisationWebsite,OrganisationMail,OrganisationAddress,State,City,Pincode,Password,OrganisationLogo,ContentType,CertificateCopporation,ContentTypeCC,OrganisationPAN,ContentTypeOP) values (@OrganisationName,@OrganisationWebsite,@OrganisationMail,@OrganisationAddress,@State,@City,@Pincode,@Password,@OrganisationLogo,@ContentType,@CertificateCopporation,@ContentTypeCC,@OrganisationPAN,@ContentTypeOP)";
                    SqlCommand cmd = new SqlCommand(strQuery);
                    cmd.Parameters.Add("@OrganisationName", SqlDbType.VarChar).Value = txtCompany.Text;
                    cmd.Parameters.Add("@OrganisationWebsite", SqlDbType.VarChar).Value = txtCompanyWebsite.Text;
                    cmd.Parameters.Add("@OrganisationMail", SqlDbType.VarChar).Value = txtCompanyEmail.Text;
                    cmd.Parameters.Add("@OrganisationAddress", SqlDbType.VarChar).Value = txtAddress.Text;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = txtState.Text;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Text;
                    cmd.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = txtPincode.Text;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;
                    cmd.Parameters.Add("@OrganisationLogo", SqlDbType.Binary).Value = bytes2;
                    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype2;
                    cmd.Parameters.Add("@CertificateCopporation", SqlDbType.Binary).Value = bytes;
                    cmd.Parameters.Add("@ContentTypeCC", SqlDbType.VarChar).Value = contenttype;
                    cmd.Parameters.Add("@CertificateCopporationFile", SqlDbType.VarChar).Value = filename;
                    cmd.Parameters.Add("@OrganisationPAN", SqlDbType.Binary).Value = bytes1;
                    cmd.Parameters.Add("@ContentTypeOP", SqlDbType.VarChar).Value = contenttype1;
                    cmd.Parameters.Add("@OrganisationPANFile", SqlDbType.VarChar).Value = filename2;
                    InsertUpdateData(cmd);
                    Clear();
                    string message = "Company registration data successfully!!!";
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
        
        string formatError = "File format not recognised. Upload Image formats";
        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
        sb1.Append("<script type = 'text/javascript'>");
        sb1.Append("window.onload=function(){");
        sb1.Append("alert('");
        sb1.Append(formatError);
        sb1.Append("')};");
        sb1.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
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
            SqlCommand cmd1 = new SqlCommand("insert into LoginTable (EmailId,Password,UserType) Values ('" + txtCompanyEmail.Text + "','" + txtPassword.Text + "','C')", con);
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