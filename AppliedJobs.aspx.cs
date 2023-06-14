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

public partial class AppliedJobs : System.Web.UI.Page
{
    SqlCommand com;
    string str;
    String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select JobsTable.JobTitle As JobTitle,JobsTable.Qualification  As Qualification,JobsTable.Experience As Experience,JobsTable.Specialization As Specialization,CompanyRegisterTable.OrganisationName As OrganisationName from ApplyJobTable inner join JobsTable on ApplyJobTable.JobId = JobsTable.Id inner join CompanyRegisterTable on CompanyRegisterTable.OrganisationMail = JobsTable.EmailId Where ApplyJobTable.UserEmail = '" + Session["Email"].ToString() + "' order By ApplyJobTable.Id asc", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    RepeaterJobs.DataSource = dtBrands;
                    RepeaterJobs.DataBind();
                }
            }
        }
    }

}