<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="AppliedJobs.aspx.cs" Inherits="AppliedJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .gradient-custom {
            background: #FB246A;
        }

        .card-registration .select-input.form-control[readonly]:not([disabled]) {
            font-size: 1rem;
            line-height: 2.15;
            padding-left: .75em;
            padding-right: .75em;
        }

        .card-registration .select-arrow {
            top: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div class="card">
                    <h5 class="card-header">Applied Jobs</h5>
                    <div class="card-body">
                        <div class="table-responsive ">
                            <asp:Repeater ID="RepeaterJobs" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col">Job&nbsp;Title</th>
                                                <th scope="col">Qualification</th>
                                                <th scope="col">Experience</th>
                                                <th scope="col">Specialization</th>
                                                <th scope="col">Organisation&nbsp;Name</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("JobTitle")%></td>
                                        <td><%# Eval("Qualification")%></td>
                                        <td><%# Eval("Experience")%></td>
                                        <td><%# Eval("Specialization")%></td>
                                        <td><%# Eval("OrganisationName")%></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                          </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

