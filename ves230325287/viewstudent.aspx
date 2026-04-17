<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="viewstudent.aspx.cs" Inherits="ves230325287.viewstudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #121212; /* Dark background for the entire page */
            margin: 0;
            padding: 0;
            color: #ffffff;
        }
        .grid {
            max-width: 800px;
            margin: 50px auto;
            background-color: #333333; /* Dark gray background for the grid */
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.5);
            overflow: hidden;
            padding: 20px;
            border: 1px solid #444444; /* Slightly lighter border */
        }
        .grid h3 {
            color: #ffffff;
            font-size: 1.5em;
            margin: 0;
            padding-bottom: 10px;
            border-bottom: 2px solid #444444;
        }
        .grid h5 {
            margin: 0;
            padding: 15px;
            font-size: 1em;
            color: #ff4d4d; /* Red color for names */
            border-bottom: 1px solid #444444;
            transition: background-color 0.3s;
        }
        .grid h5:hover {
            background-color: #444444; /* Slightly lighter on hover */
        }
        .grid h5:last-child {
            border-bottom: none;
        }
        .grid center {
            margin-bottom: 20px;
        }
        .grid .aspNetPager {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }
        .grid .aspNetPager a, .grid .aspNetPager span {
            margin: 0 5px;
            padding: 5px 10px;
            color: #007bff;
            text-decoration: none;
            border: 1px solid #007bff;
            border-radius: 5px;
            transition: all 0.3s;
        }
        .grid .aspNetPager a:hover {
            background-color: #007bff;
            color: #ffffff;
        }
        .grid .aspNetPager span {
            background-color: #007bff;
            color: #ffffff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br /><br />
    <div class="grid">
        <center><h3>Tutor Views Students</h3></center>
        <center>
            <asp:GridView
                ID="gvs"
                CellPadding="20"
                OnPreRender="gvs_PreRender"
                ClientIDMode="Static"
                AutoGenerateColumns="false"
                OnPageIndexChanging="gvs_PageIndexChanging"
                AllowPaging="true"
                PageSize="5"
                runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Student Name">
                        <ItemTemplate>
                            <h5><%# Eval("firstname") %> <%# Eval("lastname") %></h5>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </center>
    </div>
</asp:Content>
