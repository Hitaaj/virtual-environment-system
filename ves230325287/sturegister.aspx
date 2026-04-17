<%@ Page Title="" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="sturegister.aspx.cs" Inherits="ves230325287.sturegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .form-container {
        max-width: 400px;
        margin: 50px auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        background-color: #fff;
    }

    .form-group {
        margin-bottom: 15px;
    }

    .form-group label {
        display: block;
        margin-bottom: 5px;
        font-weight: bold;
    }

    .form-group input {
        width: 100%;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    .form-group button {
        width: 100%;
        padding: 10px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 16px;
    }

    .form-group button:hover {
        background-color: #0056b3;
    }

    .modal-body {
        padding: 30px;
    }

    .login {
        text-align: center;
    }
</style>
  <script>

      function valPass_ClientValidate(source, args) {
          if (args.Value.length < 7 || args.Value.length > 12) {
              args.IsValid = false;
          }
          else {
              args.IsValid = true;
          }
      }

  </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
   <br /><br /><br /><br /><br /><br /><br />
    

            <!-- Validation summary -->
            <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText="Errors in the form are:"
                DisplayMode="BulletList"
                ForeColor="DarkBlue"
                ShowSummary="true"
                ShowMessageBox="true"
                runat="server" />


    <div class="modal-body">
        <div class="form-container">
            <fieldset>
<h3 style="color:darkblue;"><center>Student  Registration 📝</h3><br /><br />
            <div class="mb-3">
    <asp:Label runat="server"
        CssClass="form-label">First name</asp:Label>
    <asp:TextBox runat="server" ID="txtfn"
        CssClass="form-control txtcolor" />
    <asp:RequiredFieldValidator 
        ID="rfvfname" 
        runat="server" 
        Display="Dynamic" 
        ControlToValidate="txtfn" 
        ForeColor="Red" 
        Text="Required!"></asp:RequiredFieldValidator>

</div>


             <div class="mb-3">
     <asp:Label runat="server"
         CssClass="form-label">Last name</asp:Label>
     <asp:TextBox runat="server" ID="txtln"
         CssClass="form-control txtcolor" />
     <asp:RequiredFieldValidator ID="rfvlname" runat="server" SetFocusOnError="true" ErrorMessage="Last name is mandatory" ControlToValidate="txtln" ForeColor="Red" Text="Required!"></asp:RequiredFieldValidator>
 </div>


            <div class="mb-3">
    <asp:Label runat="server"
        CssClass="form-label">Email</asp:Label>
    <asp:TextBox runat="server" ID="txtemail"
        CssClass="form-control" />

    <asp:RegularExpressionValidator ID="rvemail"
        runat="server"
        ForeColor="Red"
        ControlToValidate="txtemail"
        ErrorMessage="RegularExpressionValidator"
        ValidationExpression="^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$"></asp:RegularExpressionValidator>

</div>

             <div class="mb-3">
     <asp:Label runat="server"
         CssClass="form-label">Password</asp:Label>
     <asp:TextBox runat="server"
         ID="txtpass"
         TextMode="Password"
         CssClass="form-control" />

     <asp:CustomValidator ID="CustomValidator1"
         ControlToValidate="txtpass"
         ForeColor="Red"
         ValidateEmptyText="true"
         OnServerValidate="CustomValidator1_ServerValidate"
         runat="server"
         ClientValidationFunction="valPass_ClientValidate"
         ErrorMessage="Password to be 7 to 12 characters"></asp:CustomValidator>

 </div>

            <div class="mb-3">
    <asp:Label runat="server"
        CssClass="form-label">Confirm Password</asp:Label>
    <asp:TextBox runat="server" ID="txtcpass"
        TextMode="Password"
        CssClass="form-control" />

    <asp:CompareValidator ID="cvcpass"
        runat="server"
        ControlToCompare="txtpass"
        Operator="Equal"
        ForeColor="Red"
        ControlToValidate="txtcpass"></asp:CompareValidator>


</div>

            
                <div class="mb-3">
                    <asp:Label runat="server"
                        CssClass="form-label">Upload your profile picture</asp:Label>
                    <asp:FileUpload ID="fuppicture"
                        runat="server"
                        CssClass="form-control" />
                </div>

                    <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" CssClass="btn 
btn-outline-primary btn-block"
                        Text="Register" />
             <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
            </fieldset>
            </div>
        </div>
</asp:Content>
