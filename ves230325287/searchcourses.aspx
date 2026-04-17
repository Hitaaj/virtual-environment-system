<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="searchcourses.aspx.cs" Inherits="ves230325287.searchcourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .centered-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 80vh;
            background-color: #f4f4f4;
            padding: 20px;
        }

        .search-container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 1000px;
            width: 100%;
            margin: 20px;
            border: 1px solid #ddd;
        }

        .search-container h2 {
            margin-bottom: 20px;
            color: #ff0000; /* Red for the title */
            text-align: center;
            font-size: 28px;
            font-weight: bold;
        }

        .search-container .search-box {
            display: flex;
            justify-content: center;
            margin-bottom: 20px;
        }

        .search-container .search-box input[type="text"] {
            padding: 10px;
            font-size: 16px;
            border-radius: 5px;
            border: 1px solid #ddd;
            margin-right: 10px;
            width: 70%;
        }

        .search-container .search-box input[type="button"] {
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            background-color: #28a745;
            color: #fff;
            cursor: pointer;
        }

        .search-container .search-box input[type="button"]:hover {
            background-color: #218838;
        }

        .search-container .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .search-container .gridview th,
        .search-container .gridview td {
            padding: 12px;
            border: 1px solid #dddddd;
            text-align: left;
            font-size: 16px;
        }

        .search-container .gridview th {
            background-color: #28a745; /* Green for header background */
            color: #ffffff; /* White for header text */
            font-weight: bold;
            text-align: center;
        }

        .search-container .gridview tr:nth-child(even) {
            background-color: #f9f9f9; /* Light gray for even rows */
        }

        .search-container .gridview tr:hover {
            background-color: #e9e9e9; /* Slightly darker gray for hover effect */
        }

        .search-container .gridview img {
            max-width: 100px;
            max-height: 100px;
            border-radius: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br /><br />
    <div class="centered-content">
        <div class="search-container">
            <h2>Search for a Course</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" CssClass="text-center"></asp:Label>
            <div class="search-box">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" />
            </div>
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
