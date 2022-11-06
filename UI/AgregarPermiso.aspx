<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPermiso.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.AgregarPermiso" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <div class="form-group">
            <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Agregar permiso"></asp:Label>
            <br />
            <asp:Label ID="LabelPermisoCreado" runat="server" CssClass="alert alert-success alerta-personalizada" Visible="false" Text="Permiso creado con éxito"></asp:Label>
            <br />
            <asp:Label ID="LabelNombrePermiso" runat="server" CssClass="labelfor" Text="Nombre del nuevo permiso"></asp:Label>            
            <asp:TextBox ID="TextBoxNombrePermiso" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="LabelValidacionNombrePermiso" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false" Text="Por favor ingrese el nombre del nuevo permiso"></asp:Label>
            <br />
            <asp:Label ID="LabelGrupoPermiso" runat="server" CssClass="labelfor" Text="¿Pertenece a otro permiso?"></asp:Label>
            <br />
            <br />
            <asp:RadioButtonList ID="RadioButtonListPermisos" runat="server"></asp:RadioButtonList>
            <br />
            <asp:Button ID="ButtonAgregarPermiso" runat="server" OnClick="ButtonAgregarPermiso_Click" class="btn btn-primary" Text="Agregar permiso" />        
        </div>
    </div>
</asp:Content>
