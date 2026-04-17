<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="numberofcourses.aspx.cs" Inherits="ves230325287.numberofcourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .course-count {
            font-weight: bold;
            font-size: 1.25rem;
            color: #ff5722; /* Vibrant color for visibility */
            margin-bottom: 15px;
            display: block;
        }

        .table-dark-mode {
            background-color: #001f3f; /* Very dark blue background */
            color: #ffffff; /* White text for contrast */
        }

        .table-dark-mode th, .table-dark-mode td {
            border-color: #001f3f; /* Darker blue border for visibility */
            color: #ffffff; /* White text for readability */
        }

        .table-dark-mode thead th {
            background-color: saddlebrown; /* Dark blue for header background */
            color: #ffffff; /* White text for headers */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>Number of Courses</h3>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblCourseCount" runat="server" CssClass="course-count"></asp:Label>
                        <asp:GridView
                            ID="gvs"
                            runat="server"
                            CssClass="table table-striped table-bordered table-dark-mode"
                            OnPreRender="gvs_PreRender"
                            AutoGenerateColumns="false"
                            OnPageIndexChanging="gvs_PageIndexChanging"
                            AllowPaging="true"
                            PageSize="5">

                            <Columns>
                                <asp:TemplateField HeaderText="Course Name">
                                    <ItemTemplate>
                                        <span><%# Eval("Course_name") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <span><%# Eval("description") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <span><%# Eval("start_date", "{0:MM/dd/yyyy}") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date">
                                    <ItemTemplate>
                                        <span><%# Eval("end_date", "{0:MM/dd/yyyy}") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <span><%# Eval("status") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
