<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="managecourses.aspx.cs" Inherits="ves230325287.managecourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
   
    <div class="form-horizontal">
        <h5>CRUD Operations to manage courses</h5>
        <hr />
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Select 
a Category</asp:Label>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlcat" runat="server"
                    CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtCourseId" Visible="false"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Course
name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtcoursename"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Teacher</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtteacher"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Box 
Office Totals</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtbox"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Description</asp:Label>

            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtdesc" TextMode="Multiline"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Poster</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="fuposter" runat="server" CssClass="" />
                <asp:Image ID="Image1" runat="server" Visible="false" Width="75"
                    Height="100" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Schedule</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="fuschedule" runat="server" CssClass="" />
                <asp:Image ID="Image2" runat="server" Visible="false" Width="75"
                    Height="100" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <div class="form-check-inline">
                    <asp:CheckBox runat="server" ID="chkstatus"
                        CssClass="form-check-input" />
                    <asp:Label runat="server"
                        CssClass="form-check-label">Status</asp:Label>
                </div>
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <div class="offset-md-2 col-md-8">
                <asp:Button runat="server" OnClick="btnAddcourses_Click" ID="btnAddcourses" Text="Add Course"
                    CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" OnClick="btnupdate_Click" ID="btnupdate" Text="Update Course"
                    Visible="false"  CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" OnClick="btndelete_Click" ID="btndelete" Text="Delete Course"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" OnClick="btncancel_Click" ID="btncancel" Text="Cancel"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
            </div>
        </div>
    </div>
    <hr />
    <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="Course_Id" CssClass="border-0"
        ClientIDMode="Static" OnSelectedIndexChanged="gvs_SelectedIndexChanged" PageSize="2" AllowPaging="true" OnPageIndexChanging="gvs_PageIndexChanging" Width="800" runat="server">
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
            <asp:TemplateField HeaderText="Course Name">
                <ItemTemplate>
                    <!-- display the course name -->
                    <asp:Label ID="lblCourseName" Text='<%#Eval("Coursename")%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <%-- add an imagefield here to display the poster--%>
                        <asp:ImageField 
                    DataImageUrlField="Poster"
DataImageUrlFormatString="~/images/{0}"
HeaderText="Poster" SortExpression="Poster" 
                    ControlStyle-Width="100" />
        
        </Columns>
    </asp:GridView>


</asp:Content>