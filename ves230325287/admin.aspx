<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ves230325287.admin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #f9f9f9;
        }

        .form-container h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-group button {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 18px;
        }

        .form-group button:hover {
            background-color: #0056b3;
        }

        .form-group .error {
            color: red;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br /><br /><br />
    <div class="modal-body">
        <div class="form-container">
            <h3 style="color:darkblue;"><center>Admin Login</center></h3><br /><br />
            <div class="login">
                <asp:Panel runat="server">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
                    <div class="form-group">
                        <asp:Label runat="server" Text="Email" AssociatedControlID="txtEmail" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" placeholder="Email" TextMode="Email" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Password" AssociatedControlID="txtPassword" />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3" placeholder="Password" TextMode="Password" />
                    </div>
                    <div class="form-check mb-3"> 
                        <asp:CheckBox runat="server" ID="RememberMe" CssClass="form-check-input" />
                        <asp:Label runat="server" CssClass="form-check-label" AssociatedControlID="RememberMe">Remember me?</asp:Label> 
                    </div> 
                    <div class="form-group">
                        <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

