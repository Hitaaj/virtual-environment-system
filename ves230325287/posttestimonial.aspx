<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="posttestimonial.aspx.cs" Inherits="ves230325287.posttestimonial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .testimonial-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 80vh;
            padding: 20px;
            background-color: #e9ecef; /* Light gray background */
        }

        .testimonial-form {
            background-color: #ffffff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            width: 100%;
            text-align: center; /* Centering text inside the form */
        }

        .testimonial-form h2 {
            color: #0056b3; /* Deep blue color for the title */
            margin-bottom: 20px;
            font-size: 28px; /* Slightly larger title */
            font-weight: 600; /* Semi-bold title */
        }

        .testimonial-form label {
            display: block;
            margin-bottom: 10px;
            font-weight: 500; /* Medium weight for labels */
            color: #333; /* Dark gray for labels */
        }

        .testimonial-form input[type="text"],
        .testimonial-form textarea {
            width: calc(100% - 20px);
            padding: 12px;
            margin-bottom: 20px;
            border: 1px solid #ced4da;
            border-radius: 8px;
            box-sizing: border-box;
        }

        .testimonial-form button {
            display: inline-block;
            width: 100%;
            padding: 12px;
            border: none;
            border-radius: 8px;
            background-color: #28a745; /* Green for success */
            color: white;
            font-size: 18px;
            cursor: pointer;
            font-weight: 600; /* Bold font */
        }

        .testimonial-form button:hover {
            background-color: #218838; /* Darker green on hover */
        }

        .error-message {
            color: #dc3545; /* Red for error message */
            margin-bottom: 20px;
            font-size: 16px;
            font-weight: 500; /* Medium weight for error message */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br />
    <div class="testimonial-container">
        <div class="testimonial-form">
            <h2>Post a Testimonial</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
            <asp:Label ID="lblTitle" runat="server" Text="Title:" AssociatedControlID="txtTitle"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Message:" AssociatedControlID="txtMessage"></asp:Label>
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>
