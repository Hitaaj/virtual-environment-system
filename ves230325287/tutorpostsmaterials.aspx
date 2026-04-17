<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="tutorpostsmaterials.aspx.cs" Inherits="ves230325287.tutorpostsmaterials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
     .txt {
         font-weight: 600;
         font-size: 20px;
     }
     .txt2 {
    font-weight: 200;
    font-size: 10px;
}
 </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
   <div class="container col-4">
            <h2>Tutor Post Materials</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="form-label txt"></asp:Label>
            <br /><br />
             <asp:Label ID="lbltitle" runat="server" CssClass="form-label txt" Text=" Title:"></asp:Label><br />
             <asp:TextBox ID="txttitle" CssClass="form-control txt" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCourse" runat="server" CssClass="form-label txt" Text=" Course:"></asp:Label><br />
            <asp:DropDownList ID="ddlCourse" CssClass="form-control txt2" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblMaterial" runat="server" CssClass="form-label txt" Text="Material :"></asp:Label><br />
            <asp:DropDownList ID="ddlMaterial" CssClass="form-control txt2" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:FileUpload ID="fileUpload" CssClass="form-control txt" runat="server" />
            <br /><br />
            <asp:Button ID="btnUpload" CssClass="btn btn-block btn-outline-info col-3" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>



    <br /><br />
</asp:Content>