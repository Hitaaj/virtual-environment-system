<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="viewcourses.aspx.cs" Inherits="ves230325287.viewcourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .centered-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 80vh;
        }

        .table-container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            max-width: 900px;
            width: 100%;
        }

        .table-container h2 {
            margin-bottom: 20px;
            color: #ff0000; /* Red for the title */
            text-align: center;
            font-size: 24px;
            font-weight: bold;
        }

        .table-container .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table-container .gridview th,
        .table-container .gridview td {
            padding: 12px;
            border: 1px solid #dddddd;
            text-align: left;
        }

        .table-container .gridview th {
            background-color: #28a745; /* Green for header background */
            font-weight: bold;
            color: #ffffff; /* White for header text */
            text-align: center;
        }

        .table-container .gridview tr:nth-child(even) {
            background-color: #f9f9f9; /* Light gray for even rows */
        }

        .table-container .gridview tr:hover {
            background-color: #f1f1f1; /* Light gray for hover effect */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="centered-content">
        <div class="table-container">
            <h2>Available Courses</h2>
            <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Course_Id" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Course_name" HeaderText="Course Name" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="start_date" HeaderText="Start Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="end_date" HeaderText="End Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="aims" HeaderText="Aims" />
                    <asp:ImageField DataImageUrlField="image" HeaderText="Image" ControlStyle-Width="100px" ControlStyle-Height="100px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>