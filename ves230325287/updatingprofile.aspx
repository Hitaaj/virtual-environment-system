<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="updatingprofile.aspx.cs" Inherits="ves230325287.updatingprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* General container styling */
        .container {
            max-width: 900px;
            margin: 0 auto;
        }

        /* Card styling */
        .profile-card {
            background-color: #ffffff;
            border: 1px solid #e0e0e0;
            border-radius: 10px;
        }

        /* Shadow and rounded corners for the card */
        .card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        /* Fieldset styling */
        .fieldset {
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
        }

        /* Legend styling */
        .legend {
            font-size: 1.5rem;
            font-weight: bold;
            color: #333;
            padding: 0 10px;
        }

        /* Profile image styling */
        .profile-image {
            border-radius: 8px;
            border: 1px solid #ddd;
            margin-bottom: 1rem;
        }

        /* Form group styling */
        .form-group {
            margin-bottom: 1.5rem;
        }

        /* Form label styling */
        .form-label {
            display: block;
            font-weight: 600;
            margin-bottom: 0.5rem;
            color: #555;
        }

        /* Form control styling */
        .form-control {
            border: 1px solid #ccc;
            border-radius: 0.25rem;
            padding: 0.75rem;
            font-size: 1rem;
        }

        /* Error message styling */
        .error {
            font-size: 0.875rem;
            color: #dc3545;
        }

        /* Button styling */
        .btn-primary {
            background-color: #28a745; /* Updated button color */
            border-color: #28a745; /* Updated button color */
            color: #ffffff;
            font-size: 1rem;
            padding: 0.75rem 1.5rem;
            border-radius: 0.25rem;
            transition: background-color 0.3s, border-color 0.3s;
        }

        .btn-primary:hover {
            background-color: #218838; /* Darker shade on hover */
            border-color: #1e7e34; /* Darker shade on hover */
        }

        /* Check box styling */
        .form-check-input {
            margin: 0;
        }

        /* Check box label styling */
        .form-check-label {
            font-size: 1rem;
            color: #333;
        }

        /* Alert message styling */
        .message {
            margin-bottom: 1rem;
            font-size: 1rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br /><br />
    <div class="container mt-5">
        <asp:Label ID="lblmsg" runat="server" CssClass="message alert alert-info mb-4"></asp:Label>
        
        <div class="card profile-card shadow-lg p-4 rounded">
            <fieldset class="fieldset">
                <legend class="legend">Profile Details</legend>
                
                <!-- Profile Image -->
                <asp:Repeater ID="rptimg" runat="server">
                    <ItemTemplate>
                        <asp:Image ID="ImageButton1" runat="server" Width="193px" Height="195px" CssClass="profile-image"
                            ImageUrl='<%# Eval("imageurl", "~/images/{0}")%>' />
                    </ItemTemplate>
                </asp:Repeater>
                
                <!-- First Name -->
                <div class="form-group mb-4">
                    <asp:Label ID="lblFname" runat="server" Text="First Name:" AssociatedControlID="txtFname" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFname" ControlToValidate="txtFname" runat="server" ErrorMessage="First Name is required" CssClass="error text-danger"></asp:RequiredFieldValidator>
                </div>
                
                <!-- Last Name -->
                <div class="form-group mb-4">
                    <asp:Label ID="lblLname" runat="server" Text="Last Name:" AssociatedControlID="txtLname" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtLname" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqLname" ControlToValidate="txtLname" runat="server" ErrorMessage="Last Name is required" CssClass="error text-danger"></asp:RequiredFieldValidator>
                </div>
                
                <!-- Email -->
                <div class="form-group mb-4">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email is required" CssClass="error text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Invalid email format" CssClass="error text-danger"></asp:RegularExpressionValidator>
                </div>
                
                <!-- Profile Image Upload -->
                <div class="form-group mb-4">
                    <asp:Label ID="lblImageUpload" runat="server" Text="Upload Profile Image:" CssClass="form-label"></asp:Label>
                    <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
                </div>
                
                <!-- Status -->
                <div class="form-group mb-4">
                    <asp:Label ID="lblStatus" runat="server" Text="Active:" CssClass="form-check-label ms-2"></asp:Label><br />
                         <asp:CheckBox ID="chkStatus" runat="server"  CssClass="form-check-input" />
                </div>
                
                <!-- Submit Button -->
                <div class="form-group">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Update Profile" CssClass="btn btn-primary w-100" />
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>