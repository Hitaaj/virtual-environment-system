<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="ves230325287.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <asp:DetailsView ID="DetailsView1" AutoGenerateRows="false" runat="server"  Width="425px">
        <Fields>
             <asp:ImageField DataImageUrlField="Poster"
     DataImageUrlFormatString="~/images/{0}"
     HeaderText="Poster" SortExpression="Poster" ControlStyle-Width="100" />


 <asp:TemplateField HeaderText="Title & Desc">
     <ItemTemplate>
         <strong><em>
             <%# Eval("Coursename") %>
         </strong></em>
          <%# Eval("description") %>
     </ItemTemplate>
 </asp:TemplateField>

<asp:CheckBoxField DataField="Status" />


            <asp:ButtonField Text="Subscribe" ControlStyle-CssClass="btn btn-warning" />

            <asp:CommandField
ControlStyle-CssClass="btn btn-success fa-pull-right m-1"
ShowDeleteButton="True" ShowEditButton="True"
ShowInsertButton="True">
</asp:CommandField>

        </Fields>

    </asp:DetailsView>
</asp:Content>
