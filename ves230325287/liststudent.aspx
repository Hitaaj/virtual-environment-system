<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="liststudent.aspx.cs" Inherits="ves230325287.liststudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Add any head content here -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>List of Students</h3>
                    </div>
                    <div class="card-body">
                        <asp:GridView
                            ID="gvs"
                            runat="server"
                            CssClass="table table-striped table-bordered"
                            OnPreRender="gvs_PreRender"
                            AutoGenerateColumns="false"
                            OnPageIndexChanging="gvs_PageIndexChanging"
                            AllowPaging="true"
                            PageSize="5">

                            <Columns>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <span><%# Eval("firstname") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <span><%# Eval("lastname") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <span><%# Eval("email") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <span><%# Eval("status") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>