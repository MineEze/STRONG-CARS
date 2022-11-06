<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Usuarios" %>

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
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Usuarios"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelValidacionBorrado" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false" Text="No se puede borrar a sí mismo"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
            <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
        </div>
        <div class="form-group">
            <asp:GridView ID="GridViewUsuarios" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="NombreDeUsuario" HeaderText="Usuario" />
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
    </div>
</asp:Content>
