<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.LogIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="form my-5 mx-5">
        <div class="container">
            <div class="row no-gutters" id="login">
                <div class="col-lg-5">
                    <!--img id="login" src="Content/images/login-feed.jpg" class="img-fluid" alt=""-->
                </div>
                <div class="col-lg-7 px-5 pt-5">
                    <div class="col-lg-7">
                        <!--img id="login" src="Content/images/login-logo.png" class="img-fluid" alt=""-->
                    </div>
                    <div class="form-row">
                        <div class="col-lg-7">
                            <asp:TextBox ID="TextBoxUsuario" CssClass="form-control" placeholder="Usuario" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-lg-7">
                            <asp:TextBox ID="TextBoxPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-lg-7">
                            <asp:Button ID="ButtonLogIn" runat="server" OnClick="ButtonLogIn_Click" CssClass="btnLogin" Text="Ingresar" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-lg-7">
                            <asp:Button ID="ButtonRegistrarse" runat="server" OnClick="ButtonRegistrarse_Click" CssClass="btnLogin" Text="Registrarse" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-lg-7">
                            <asp:Label ID="LabelLogInError" runat="server" CssClass="alert alert-danger alertas" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-lg-7">
                            <asp:Label ID="LabelUsuarioBloqueado" runat="server" CssClass="alert alert-danger alertas" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

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
