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

public partial class Joblisting : System.Web.UI.Page
{
    #region Global Variable
    string str;
    SqlConnection CS = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BusType();
            Experience();
            BindProductRptr();
        }
    }
    private void BusType()
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from JobTypeTable", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlJobType.DataSource = dt;
                ddlJobType.DataTextField = "JobTypeName";
                ddlJobType.DataValueField = "JobTypeName";
                ddlJobType.DataBind();
                ddlJobType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }

    private void Experience()
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select distinct(Experience) From JobsTable ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlExperience.DataSource = dt;
                ddlExperience.DataTextField = "Experience";
                ddlExperience.DataValueField = "Experience";
                ddlExperience.DataBind();
                ddlExperience.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }

    private void BindProductRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from JobsTable inner join CompanyRegisterTable on CompanyRegisterTable.OrganisationMail = JobsTable.EmailId order By JobsTable.Id  asc", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrProducts.DataSource = dtBrands;
                    rptrProducts.DataBind();
                }

            }
        }
    }
    protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from JobsTable inner join CompanyRegisterTable on CompanyRegisterTable.OrganisationMail = JobsTable.EmailId Where JobType='" + ddlJobType.Text + "' order By JobsTable.Id  asc", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrProducts.DataSource = dtBrands;
                    rptrProducts.DataBind();
                }

            }
        }
    }
    protected void ddlExperience_SelectedIndexChanged(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from JobsTable inner join CompanyRegisterTable on CompanyRegisterTable.OrganisationMail = JobsTable.EmailId Where Experience='" + ddlExperience.Text + "' order By JobsTable.Id  asc", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrProducts.DataSource = dtBrands;
                    rptrProducts.DataBind();
                }

            }
        }
    }
}