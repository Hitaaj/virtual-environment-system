<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="coursemanagement.aspx.cs" Inherits="ves230325287.coursemanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        .container {
            margin-top: 50px;
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .form-group label {
            font-weight: bold;
            color: #333;
        }
        .btn {
            border-radius: 20px;
        }
        .btn-outline-primary {
            color: #007bff;
            border-color: #007bff;
        }
        .btn-outline-primary:hover {
            background-color: #007bff;
            color: white;
        }
        .grid-view {
            margin-top: 30px;
        }
        .grid-view th {
            background-color: #343a40;
            color: white;
            font-weight: bold;
        }
        .grid-view td {
            background-color: #ffffff;
        }
        .grid-view .row:hover {
            background-color: #f1f1f1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container col-md-8">
        <div class="form-horizontal">
            <h5 class="text-center">Manage Course</h5>
            <hr />
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">Select a Category</asp:Label>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label"></asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="txtCourseId" Visible="false" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">Course Name</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="txtCourseName" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">Description</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">Aims</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="txtAim" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">Start Date</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="txtStartdate" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">End Date</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="txtEnddate" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" CssClass="col-md-3 col-form-label">Image</asp:Label>
                <div class="col-md-9">
                    <asp:FileUpload ID="fuimage" runat="server" CssClass="form-control-file" />
                    <asp:Image ID="Image1" runat="server" Visible="false" Width="75" Height="100" />
                </div>
            </div>
            <div class="form-group row">
                <div class="offset-md-3 col-md-9">
                    <asp:Button runat="server" OnClick="btnAddcourse_Click" ID="btnAddcourse" Text="Add" CssClass="btn btn-outline-primary" />
                    <asp:Button runat="server" OnClick="btnupdate_Click" ID="btnupdate" Text="Update" Visible="false" CssClass="btn btn-outline-primary" />
                    <asp:Button runat="server" OnClick="btndelete_Click" ID="btndelete" Text="Delete" Visible="false" CssClass="btn btn-outline-primary" />
                    <asp:Button runat="server" OnClick="btncancel_Click" ID="btncancel" Text="Cancel" Visible="false" CssClass="btn btn-outline-primary" />
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
        <hr />
        <div class="grid-view">
            <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="Course_Id" CssClass="table table-striped table-bordered"
                ClientIDMode="Static" OnSelectedIndexChanged="gvs_SelectedIndexChanged" PageSize="2" AllowPaging="true" OnPageIndexChanging="gvs_PageIndexChanging" Width="100%" runat="server">
                <HeaderStyle BackColor="#343a40" ForeColor="White" Font-Bold="true" Height="30" />
                <AlternatingRowStyle BackColor="#f5f5f5" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnSelect" runat="server" CssClass="btn btn-info" CommandName="Select" Text="Select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseName" Text='<%#Eval("Course_Name")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataImageUrlField="image" DataImageUrlFormatString="~/images/{0}" HeaderText="Image" ControlStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
