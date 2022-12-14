<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.LogIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    
    <div class="container">
        <div class="form-signin">
            <div class="loginImagen">
                <img src="Content/images/login-logo.png" alt="" width="280" height="150" />
            </div>
            <br />
            <asp:TextBox ID="TextBoxUsuario" class="form-control" placeholder="Usuario" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBoxPassword" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                
            <br />
            <asp:Button ID="ButtonLogIn" runat="server" OnClick="ButtonLogIn_Click" CssClass="btn btn-lg btn-block btn-primary" Text="Ingresar" />
            <br />
            <asp:Button ID="ButtonRegistrarse" runat="server" OnClick="ButtonRegistrarse_Click" CssClass="btn btn-lg btn-block btn-primary" Text="Registrarse" />
            <br />
            <asp:Label ID="LabelLogInError" runat="server" CssClass="alert alert-danger alertas" Visible="False" Text="Usuario y/o contraseña incorrectos"></asp:Label>
            <asp:Label ID="LabelUsuarioBloqueado" runat="server" CssClass="alert alert-danger alertas" Visible="False" Text="Usuario bloqueado. Contacte al administrador"></asp:Label>
        </div>
    </div>
    <script type="text/javascript">
        function controlEnter(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 13) {
                document.getElementById('MainContent_ButtonLogIn').click();
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>


