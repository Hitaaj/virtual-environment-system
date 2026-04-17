<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="postannouncement.aspx.cs" Inherits="ves230325287.postannouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .centered-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 80vh;
        }

        .form-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 500px;
            width: 100%;
            text-align: center;
        }

        .form-container h2 {
            margin-bottom: 20px;
            color: #343a40;
        }

        .form-container label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #495057;
        }

        .form-container .textbox {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ced4da;
            margin-bottom: 20px;
            font-size: 14px;
            box-sizing: border-box;
        }

        .form-container .button {
            background-color: #28a745;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        .form-container .button:hover {
            background-color: #218838;
        }

        .form-container .message {
            margin-top: 20px;
            color: #dc3545;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="centered-content">
        <div class="form-container">
            <h2>Post Announcement</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="message"></asp:Label>
            <div>
                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" CssClass="textbox"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnPost" runat="server" Text="Post Announcement" OnClick="btnPost_Click" CssClass="button" />
            </div>
        </div>
    </div>
</asp:Content>
