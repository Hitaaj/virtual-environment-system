<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="tutormanagecourse.aspx.cs" Inherits="ves230325287.tutormanagecourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

   
        <br /> <br /> <br /> <br /> <br /> <br /> <br /><br /><br /><br /><br /><br />
    <div class="container col-5">
        <div class="form-horizontal">
            <h5>Manage category</h5>
            <hr />
            <hr />
           
            <div class="form-group row justify-content-center">
                <asp:Label runat="server"
                    CssClass="col-md-2 col-form-label"></asp:Label>

                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCategoryId" Visible="false"
                        CssClass="form-control" />
                </div>
            </div>
            <div class="form-group row justify-content-center">
                <asp:Label runat="server" CssClass="col-md-2 col-form-label">Category name</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCategoryName"
                        CssClass="form-control" />
                </div>
            </div>



           
            <div class="form-group row justify-content-center">
                <div class="offset-md-2 col-md-8">
                    <asp:Button runat="server" OnClick="btnAdd_Click" ID="btnAdd" Text="Add"
                        CssClass="btn btn-block btn-outline-primary col-2" />
                    <asp:Button runat="server" OnClick="btnupdate_Click" ID="btnupdate" Text="Update"
                        Visible="false" CssClass="btn btn-block btn-outline-primary" />
                    <asp:Button runat="server" OnClick="btndelete_Click" ID="btndelete" Text="Delete"
                        Visible="false" CssClass="btn btn-block btn-outline-primary" />
                    <asp:Button runat="server" OnClick="btncancel_Click" ID="btncancel" Text="Cancel"
                        Visible="false" CssClass="btn btn-block btn-outline-primary" />
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <hr />
    <center>   <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="Category_Id" CssClass="border-0"
            ClientIDMode="Static" OnSelectedIndexChanged="gvs_SelectedIndexChanged" PageSize="2" AllowPaging="true" OnPageIndexChanging="gvs_PageIndexChanging" 
            Width="800" runat="server">
            <HeaderStyle BackColor="Black" ForeColor="White" Font-Bold="true"
                Height="30" />

            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" runat="server"
                            CssClass="btn btn-info" CommandName="Select" Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                        <!-- display the movie name -->
                        <asp:Label ID="lblCourseName" Text='<%#Eval("Category_Name")%>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
               

            </Columns>
        </asp:GridView>
        </center> 
        </div>

</asp:Content>