<%@ Page Title="Manage Subscriptions" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="ManageSubscriptions.aspx.cs" Inherits="ves230325287.ManageSubscriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .subscription-list {
            margin: 20px auto;
            max-width: 800px;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .subscription-item {
            border-bottom: 1px solid #ddd;
            padding: 10px 0;
        }

        .subscription-item:last-child {
            border-bottom: none;
        }

        .subscription-title {
            font-size: 18px;
            color: #0056b3;
            margin-bottom: 5px;
        }

        .subscription-details {
            font-size: 16px;
            color: #333;
            margin-bottom: 10px;
        }

        .btn-accept, .btn-reject {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            color: white;
            cursor: pointer;
        }

        .btn-accept {
            background-color: #28a745;
        }

        .btn-reject {
            background-color: #dc3545;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br />
    <div class="subscription-list">
        <asp:Repeater ID="rptSubscriptions" runat="server">
            <ItemTemplate>
                <div class="subscription-item">
                    <div class="subscription-title">Course ID: <%# Eval("Course_Id") %></div>
                    <div class="subscription-details">Student: <%# Eval("Student_Name") %></div>
                    <asp:Button ID="btnAccept" runat="server" Text="Accept" CommandArgument='<%# Eval("Studentcourse_Id") %>' OnClick="btnAccept_Click" CssClass="btn-accept" />
                    <asp:Button ID="btnReject" runat="server" Text="Reject" CommandArgument='<%# Eval("Studentcourse_Id") %>' OnClick="btnReject_Click" CssClass="btn-reject" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
