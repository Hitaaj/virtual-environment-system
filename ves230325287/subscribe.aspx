<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="subscribe.aspx.cs" Inherits="ves230325287.subscribe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            color: #333;
        }
        .container {
            max-width: 900px;
            margin: 40px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            color: #003366; /* Dark blue title color */
            margin-bottom: 20px;
            font-size: 28px;
        }
        .btn {
            background-color: #dc3545; /* Red button color */
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            text-align: center;
            display: inline-block;
            transition: background-color 0.3s ease;
        }
        .btn:hover {
            background-color: #c82333;
        }
        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .table th, .table td {
            padding: 15px;
            border: 1px solid #ddd;
            text-align: left;
        }
        .table th {
            background-color: #003366; /* Dark blue table header */
            color: #ffffff;
        }
        .table-striped tbody tr:nth-of-type(odd) {
            background-color: #f2f2f2;
        }
        .message {
            text-align: center;
            font-size: 18px;
            margin-top: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div class="container">
        <h2>Subscribe to a Course</h2>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="Course_Name" HeaderText="Course Name" />
                <asp:BoundField DataField="Tutor_Name" HeaderText="Tutor Name" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnbsub" runat="server" Text="Subscribe" CommandArgument='<%# Eval("Course_Id") %>' OnClick="lnbsub_Click" CssClass="btn"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="message"/>
    </div>
</asp:Content>
