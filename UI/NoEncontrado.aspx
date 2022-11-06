<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoEncontrado.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.NoEncontrado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="jumbotron">
        <h3><asp:Label ID="LabelNoEncontrado" runat="server" Text="La página a la que quiere acceder no fue encontrada o usted no tiene permisos suficientes."></asp:Label></h3>
    </div>
    <br />
    <br />
    <asp:Button ID="ButtonCerrarSesionNoEncontrado" runat="server" OnClick="ButtonCerrarSesionNoEncontrado_Click" CssClass="btn btn-primary" Text="Cerrar sesión" />
</asp:Content>
