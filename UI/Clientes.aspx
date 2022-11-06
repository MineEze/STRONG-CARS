<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <script>
        function confirmacion() {
            return confirm("¿Está seguro?");
        }
    </script>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Clientes"></asp:Label>
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
            <asp:Button ID="ButtonFiltroEmpresa" runat="server" Text="Filtrar" class="btn btn-primary" OnClick="ButtonFiltroEmpresa_Click" Style="margin-left: 10px;" />
        </div>
        <br />
        <br />
        <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor" Text="No se encontraron registros"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
            <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
        </div>
        <asp:GridView ID="GridViewClientes" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="EmpresaNombre" HeaderText="Nombre de la empresa" />
                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEditar" CssClass="glyphicon glyphicon-pencil" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Editar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="Borrar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonBorrar" CssClass="glyphicon glyphicon-remove" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClientClick="if(!confirmacion()) return false;" OnClick="Borrar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
</asp:Content>
