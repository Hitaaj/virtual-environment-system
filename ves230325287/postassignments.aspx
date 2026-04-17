<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="postassignments.aspx.cs" Inherits="ves230325287.postassignments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #e9ecef;
            margin: 0;
            padding: 20px;
        }
        .form-container {
            max-width: 700px;
            margin: 0 auto;
            padding: 30px;
            border: 1px solid #ced4da;
            border-radius: 10px;
            background-color: #ffffff;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
        .form-container h2 {
            margin-bottom: 20px;
            color: #343a40;
            font-size: 24px;
            font-weight: bold;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #495057;
        }
        .form-group input, .form-group textarea, .form-group select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 16px;
        }
        .form-group textarea {
            resize: vertical;
            height: 120px;
        }
        .form-group button {
            padding: 12px 20px;
            background-color: #007bff;
            border: none;
            color: #ffffff;
            cursor: pointer;
            border-radius: 5px;
            font-size: 16px;
            transition: background-color 0.3s ease;
        }
        .form-group button:hover {
            background-color: #0056b3;
        }
        .form-group .file-upload-container {
            position: relative;
            display: inline-block;
        }
        .form-group .file-upload-container input[type="file"] {
            position: absolute;
            opacity: 0;
            width: 100%;
            height: 100%;
            cursor: pointer;
        }
        .form-group .file-upload-label {
            padding: 10px;
            background-color: #f8f9fa;
            border: 1px solid #ced4da;
            border-radius: 5px;
            display: inline-block;
            width: 100%;
            text-align: center;
        }
        .form-group .file-upload-label:hover {
            background-color: #e2e6ea;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="form-container">
        <h2>Post New Assignment</h2>
        <asp:Literal ID="litMessage" runat="server" EnableViewState="false" />
        <div class="form-group">
            <label for="txtTitle">Title:</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-group" />
        </div>
        <div class="form-group">
            <label for="txtDescription">Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-group" />
        </div>
        <div class="form-group">
            <label for="txtDeadline">Deadline:</label>
            <asp:TextBox ID="txtDeadline" runat="server" CssClass="form-group" />
        </div>
        <div class="form-group">
            <label for="ddlCourses">Course:</label>
            <asp:DropDownList ID="ddlCourses" runat="server" CssClass="form-group">
                <asp:ListItem Text="Select Course" Value="" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="fileUpload">Document:</label>
            <div class="file-upload-container">
                <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-group" />
                <label for="fileUpload" class="file-upload-label">Choose file...</label>
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="form-group" />
        </div>
    </div>
</asp:Content>
