<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="viewannouncement.aspx.cs" Inherits="ves230325287.viewannouncement" %>
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
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 800px;
            width: 100%;
        }

        .table-container h2 {
            margin-bottom: 20px;
            color: #2c3e50; /* Strong dark color for the title */
            text-align: center;
        }

        .table-container .message {
            margin-bottom: 20px;
            color: #e74c3c; /* Strong red for error messages */
            text-align: center;
        }

        .table-container .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table-container .gridview th,
        .table-container .gridview td {
            padding: 10px;
            border: 1px solid #ced4da;
            text-align: left;
        }

        .table-container .gridview th {
            background-color: #34495e; /* Dark blue-gray for header background */
            font-weight: bold;
            color: #ffffff; /* White for header text */
        }

        .table-container .gridview tr:nth-child(even) {
            background-color: #ecf0f1; /* Light gray for even rows */
        }

        .table-container .gridview th.Description {
            color: #2980b9; /* Strong blue */
        }

        .table-container .gridview th.DatePosted {
            color: #e67e22; /* Strong orange */
        }

        .table-container .gridview th.PostedBy {
            color: #27ae60; /* Strong green */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
        <!-- page title -->
<section class="page-title-section overlay" data-background="images/backgrounds/page-title.jpg">
  <div class="container">
    <div class="row">
      <div class="col-md-8">
        <ul class="list-inline custom-breadcrumb">
          <li class="list-inline-item"><a class="h2 text-primary font-secondary" href="@@page-link">Announcement</a></li>
          <li class="list-inline-item text-white h3 font-secondary @@nasted"></li>
        </ul>
        <p class="text-lighten">Our courses offer a good compromise between the continuous assessment favoured by some universities and the emphasis placed on final exams by others.</p>
      </div>
    </div>
  </div>
</section>
<!-- /page title -->
    <div class="centered-content">
        <div class="table-container">
            <h2>Announcements</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="message"></asp:Label>
            <asp:GridView ID="gvAnnouncements" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Announcement_Id" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-CssClass="Description" />
                    <asp:BoundField DataField="dateposted" HeaderText="Date Posted" DataFormatString="{0:dd-MM-yyyy}" HeaderStyle-CssClass="DatePosted" />
                    <asp:BoundField DataField="TutorName" HeaderText="Posted By" HeaderStyle-CssClass="PostedBy" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
