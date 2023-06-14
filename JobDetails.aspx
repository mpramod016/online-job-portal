<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="JobDetails.aspx.cs" Inherits="JobDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="slider-area ">
        <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="assets/img/hero/about.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="hero-cap text-center">
                            <h2>Job Details</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="job-post-company pt-120 pb-120">
        <div class="container">
            <asp:Repeater ID="rptrProducts" runat="server">
                <ItemTemplate>
                    <div class="row justify-content-between">
                        <!-- Left Content -->
                        <div class="col-xl-7 col-lg-8">
                            <!-- job single -->
                            <div class="single-job-items mb-50">
                                <div class="job-items">
                                    <div class="company-img company-img-details">
                                        <a href="#">
                                            <img src='data:<%#Eval("ContentType")%>;base64,<%# Eval("OrganisationLogo") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("OrganisationLogo")) : string.Empty %>' class="img-fluid" width="50" height="50"></a>
                                    </div>
                                    <div class="job-tittle">
                                        <a href="#">
                                            <h4><%#Eval("OrganisationName")%></h4>
                                        </a>
                                        <ul>
                                            <li><%#Eval("JobTitle")%></li>
                                            <li><i class="fas fa-map-marker-alt"></i><%#Eval("City")%>, <%#Eval("State")%></li>
                                            <li><%#Eval("Salary")%></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <!-- job single End -->

                            <div class="job-post-details">
                                <div class="post-details1 mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Job Description</h4>
                                    </div>
                                    <p><%#Eval("Description")%></p>
                                </div>
                            </div>

                        </div>
                        <!-- Right Content -->
                        <div class="col-xl-4 col-lg-4">
                            <div class="post-details3  mb-50">
                                <!-- Small Section Tittle -->
                                <div class="small-section-tittle">
                                    <h4>Job Overview</h4>
                                </div>
                                <ul>
                                    <li>Qualification : <span><%# Eval("Qualification")%></span></li>
                                    <li>Experience : <span><%# Eval("Experience")%></span></li>
                                    <li>Specialization : <span><%# Eval("Specialization")%></span></li>
                                    <li>Vacancy : <span><%# Eval("NumberofPost")%></span></li>
                                    <li>Job Type : <span><%# Eval("JobType")%></span></li>
                                    <li>Salary :  <span><%# Eval("Salary")%></span></li>
                                    <li>Application date : <span><%# Eval("LastDateApply","{0:MM/dd/yyyy}")%></span></li>
                                </ul>

                            </div>
                            <div class="post-details4  mb-50">
                                <!-- Small Section Tittle -->
                                <div class="small-section-tittle">
                                    <h4>Company Information</h4>
                                </div>
                                <span><%# Eval("LastDateApply","{0:MM/dd/yyyy}")%></span>
                                <p><%# Eval("OrganisationAddress")%></p>
                                <ul>
                                    <li>Name: <span><%# Eval("OrganisationName")%> </span></li>
                                    <li>Web : <span><%# Eval("OrganisationWebsite")%></span></li>
                                    <li>Email: <span><%# Eval("OrganisationMail")%></span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-xl-7 col-lg-8">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <div class="form-outline">
                                        <label class="form-label" for="form3Example1m">Upload Resume</label>
                                          <asp:FileUpload ID="fpUploadResume" runat="server" CssClass="form-control" />
                                    </div>
                                </div> 
                            </div>
                            <div class="apply-btn2">
                                <asp:Button ID="btnApply" runat="server" Text="Apply Now" CssClass="btn" OnClick="btnApply_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

