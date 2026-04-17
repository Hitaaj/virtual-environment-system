<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="managetutoraccounts.aspx.cs" Inherits="ves230325287.managetutoraccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 80vh;
            background-color: #f4f7f9; /* Light background for the entire page */
            padding: 20px;
        }

        .table-container {
            background-color: #ffffff; /* White background for the content area */
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 1200px;
        }

        .table-container h2 {
            margin-bottom: 20px;
            color: #003366; /* Deep blue for the title */
            text-align: center;
            font-size: 26px;
            font-weight: 600;
        }

        .table-container .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table-container .gridview th,
        .table-container .gridview td {
            padding: 12px;
            border: 1px solid #dee2e6; /* Light gray border for the table */
            text-align: left;
            font-size: 16px;
            color: #333333; /* Dark gray text for table cells */
        }

        .table-container .gridview th {
            background-color: #003366; /* Deep blue for header background */
            color: #ffffff; /* White for header text */
            font-weight: 600;
            text-align: center;
        }

        .table-container .gridview tr:nth-child(even) {
            background-color: #f9f9f9; /* Very light gray for even rows */
        }

        .table-container .gridview tr:hover {
            background-color: #e2e6ea; /* Light gray for hover effect */
        }

        .table-container .gridview .btn {
            padding: 8px 14px;
            border-radius: 4px;
            border: none;
            color: #ffffff;
            cursor: pointer;
            font-size: 14px;
            margin: 0 5px;
            transition: background-color 0.3s;
        }

        .table-container .gridview .btnFreeze {
            background-color: #dc3545; /* Red for Freeze */
        }

        .table-container .gridview .btnUnfreeze {
            background-color: #007bff; /* Blue for Unfreeze */
        }

        .table-container .gridview .btnFreeze:hover {
            background-color: #c82333; /* Darker red for hover effect */
        }

        .table-container .gridview .btnUnfreeze:hover {
            background-color: #0056b3; /* Darker blue for hover effect */
        }

        .message {
            color: #dc3545; /* Red for error messages */
            text-align: center;
            font-size: 16px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container">
        <div class="table-container">
            <h2>Manage Tutor Accounts</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <asp:GridView ID="gvs" runat="server" AutoGenerateColumns="False" OnRowCommand="gvs_RowCommand" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Tutor_Id" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="firstname" HeaderText="First Name" />
                    <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="status" HeaderText="Status" DataFormatString="{0}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnFreeze" runat="server" Text="Freeze" CommandName="Freeze" CommandArgument='<%# Eval("Tutor_Id") %>' CssClass="btn btnFreeze" Visible='<%# Eval("status").ToString() == "True" %>' />
                            <asp:Button ID="btnUnfreeze" runat="server" Text="Unfreeze" CommandName="Unfreeze" CommandArgument='<%# Eval("Tutor_Id") %>' CssClass="btn btnUnfreeze" Visible='<%# Eval("status").ToString() == "False" %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
