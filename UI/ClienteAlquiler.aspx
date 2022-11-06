<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteAlquiler.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.ClienteAlquiler" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Nuevo alquiler"></asp:Label>
        <br />
        <div class="form-inline">
            <asp:Label ID="LabelFiltroNombreApellido" CssClass="labelfor" runat="server" Style="margin-top: 5px; min-width: 210px" Text="Filtrar por nombre y/o apellido"></asp:Label>
            <asp:TextBox ID="TextBoxFiltroNombreApellido" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonFiltroNombreApellido" runat="server" Text="Filtrar" class="btn btn-primary" OnClick="ButtonFiltroNombreApellido_Click" Style="margin-left: 10px;" />
        </div>
        <br />
        <div class="form-inline">
            <asp:Label ID="LabelFiltroEmpresa" CssClass="labelfor" runat="server" Style="margin-top: 5px; min-width: 225px" Text="Filtrar por nombre de la empresa"></asp:Label>
            <asp:TextBox ID="TextBoxFiltroEmpresa" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonFiltroEmpresa" runat="server" Text="Button" class="btn btn-primary" OnClick="ButtonFiltroEmpresa_Click" Style="margin-left: 10px;" />
        </div>
        <br />
        <asp:Label ID="LabelClienteSeleccione" runat="server" CssClass="labelfor" Text="Seleccione el cliente"></asp:Label>
        <asp:Label ID="LabelAlquilerCreado" runat="server" CssClass="alert alert-success alerta-personalizada" Visible="false" Text="Alquiler creado con éxito"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor" Text="No se encontraron registros."></asp:Label>
        <asp:GridView ID="GridViewClientes" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="EmpresaNombre" HeaderText="Empresa" />
                <asp:TemplateField ShowHeader="False" HeaderText="Seleccionar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonCrearAlquiler" CssClass="glyphicon glyphicon-ok" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="CrearAlquiler_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
</asp:Content>
