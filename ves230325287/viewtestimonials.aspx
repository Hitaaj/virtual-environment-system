<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="viewtestimonials.aspx.cs" Inherits="ves230325287.ViewTestimonials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7f9; /* Light background for the whole page */
            color: #333; /* Dark gray text color */
        }

        .testimonial-list {
            margin: 40px auto;
            max-width: 900px;
            background-color: #ffffff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden; /* Clear floats inside */
        }

        .testimonial-item {
            border-bottom: 1px solid #e0e0e0;
            padding: 20px 0;
            position: relative; /* Ensure positioning of pseudo-elements works */
        }

        .testimonial-item:last-child {
            border-bottom: none;
        }

        .testimonial-title {
            font-size: 22px;
            color: #0056b3; /* Deep blue for title */
            margin-bottom: 10px;
            font-weight: 700; /* Bold title */
        }

        .testimonial-message {
            font-size: 16px;
            color: #555; /* Medium gray for message */
            line-height: 1.6; /* Improve readability with line-height */
        }

        .testimonial-item:before {
            content: "“"; /* Quotation mark before the message */
            font-size: 50px;
            color: #007bff; /* Primary blue for quotation mark */
            position: absolute;
            left: 20px;
            top: -10px;
        }

        .testimonial-item:after {
            content: "”"; /* Quotation mark after the message */
            font-size: 50px;
            color: #007bff; /* Primary blue for quotation mark */
            position: absolute;
            right: 20px;
            bottom: -10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <br /><br /><br /><br />
    <div class="testimonial-list">
        <asp:Repeater ID="rptTestimonials" runat="server">
            <ItemTemplate>
                <div class="testimonial-item">
                    <div class="testimonial-title"><%# Eval("title") %></div>
                    <div class="testimonial-message"><%# Eval("message") %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
