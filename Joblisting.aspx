<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Joblisting.aspx.cs" Inherits="Joblisting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="slider-area ">
        <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="assets/img/hero/about.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="hero-cap text-center">
                            <h2>Get your job</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="job-listing-area pt-120 pb-120">
        <div class="container">
            <div class="row">
                <div class="col-xl-3 col-lg-3 col-md-4">
                    <div class="row">
                        <div class="col-12">
                            <div class="small-section-tittle2 mb-45">
                                <div class="ion">
                                    <svg
                                        xmlns="http://www.w3.org/2000/svg"
                                        xmlns:xlink="http://www.w3.org/1999/xlink"
                                        width="20px" height="12px">
                                        <path fill-rule="evenodd" fill="rgb(27, 207, 107)"
                                            d="M7.778,12.000 L12.222,12.000 L12.222,10.000 L7.778,10.000 L7.778,12.000 ZM-0.000,-0.000 L-0.000,2.000 L20.000,2.000 L20.000,-0.000 L-0.000,-0.000 ZM3.333,7.000 L16.667,7.000 L16.667,5.000 L3.333,5.000 L3.333,7.000 Z" />
                                    </svg>
                                </div>
                                <h4>Filter Jobs</h4>
                            </div>
                        </div>
                    </div>

                    <div class="job-category-listing mb-50">

                        <div class="single-listing">
                            <div class="select-Categories pt-80 pb-50">
                                <div class="small-section-tittle2">
                                    <h4>Job Type</h4>
                                </div>
                                <div class="select-job-items2">
                                    <asp:DropDownList ID="ddlJobType" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="single-listing">
                            <div class="select-Categories pt-80 pb-50">
                                <div class="small-section-tittle2">
                                    <h4>Experience</h4>
                                </div>
                                <div class="select-job-items2">
                                    <asp:DropDownList ID="ddlExperience" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlExperience_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-xl-9 col-lg-9 col-md-8">
                    <section class="featured-job-area">

                        <div class="container">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="count-job mb-35">
                                        <span>Jobs</span>
                                    </div>
                                </div>
                            </div>
                            <asp:Repeater ID="rptrProducts" runat="server">
                                <ItemTemplate>
                                    <div class="single-job-items mb-30">
                                        <div class="job-items">
                                            <div class="company-img">
                                                <a href="#">
                                                    <img src='data:<%#Eval("ContentType")%>;base64,<%# Eval("OrganisationLogo") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("OrganisationLogo")) : string.Empty %>' class="img-fluid"  width="50" height="50"></a>
                                            </div>
                                            <div class="job-tittle job-tittle2">
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
                                        <div class="items-link items-link2 f-right">
                                            <a href="JobDetails.aspx?Id=<%#Eval("Id") %>"><%#Eval("JobType")%></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

