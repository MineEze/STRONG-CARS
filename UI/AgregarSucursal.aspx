<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.AgregarSucursal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .escondido {
            display: none;
        }

        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <script src="Scripts/validaciones.js"></script>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Agregar sucursal"></asp:Label>
        <br />
        <asp:Label ID="LabelCreacionSucursalExito" runat="server" CssClass="alert alert-success  alerta-personalizada" Text="Sucursal creada con éxito."></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelCalle" CssClass="labelfor" runat="server" Text="Calle"></asp:Label> <asp:TextBox ID="TextBoxCalle" runat="server" CssClass="form-control"></asp:TextBox>            
            <asp:Label ID="LabelValidacionCalle" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe ingresar una calle"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelAltura" CssClass="labelfor" runat="server" Text="Altura"></asp:Label>
            <asp:TextBox ID="TextBoxAltura" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionAltura" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese la altura"></asp:Label>
            <asp:Label ID="LabelValidacionAlturaNumerica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La altura debe ser numérica"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelUnidad" runat="server" CssClass="labelfor" Text="Unidad"></asp:Label>
            <asp:TextBox ID="TextBoxUnidad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelCodigoPostal" runat="server" CssClass="labelfor" Text="Código postal"></asp:Label>
            <asp:TextBox ID="TextBoxCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionCodigoPostal" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe ingresar un código postal válido"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelGerente" CssClass="labelfor" runat="server" Text="Gerente"></asp:Label>
            <asp:DropDownList ID="DropDownListGerente" runat="server" CssClass="ddl form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-6">
                    <asp:GridView ID="GridViewSucursalesRecargos" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnDataBound="GridViewSucursalesRecargos_DataBound">
                        <Columns>
                            <asp:BoundField DataField="NombreSucursal" HeaderText="Nombre" />
                            <asp:TemplateField ShowHeader="True" HeaderText="Recargo">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="TextBoxRecargo" Text='0' Style="width: 70px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:Label ID="LabelValidacionRecargosNumericos" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Los recargos deben ser numéricos"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelTelefonos" runat="server" CssClass="labelfor" Text="Teléfonos"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelTelefonoCaracteristica" CssClass="labelfor" runat="server" Text="Caracteristica"></asp:Label>
            <asp:TextBox ID="TextBoxTelefonoCaracteristica" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionTelefonoCaracteristica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La característica debe tener al menos 2 dígitos"></asp:Label>
            <br />
            <asp:Label ID="LabelTelefonoNumero" CssClass="labelfor" runat="server" Text="Número"></asp:Label>
            <asp:TextBox ID="TextBoxTelefonoNumero" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionTelefonoCaracteristicaNumerica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La característica debe ser numérica"></asp:Label>
            <asp:Label ID="LabelValidacionTelefonoNumero" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El número debe tener al menos 7 dígitos"></asp:Label>
            <asp:Label ID="LabelValidacionTelefonoNumeroNumerico" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El número debe ser numérico"></asp:Label>
            <asp:Label ID="LabelValidacionTelefonoRepetido" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false" Text="El número ya está en la lista"></asp:Label>
            <br />
            <asp:Button ID="ButtonAgregarTelefono" runat="server" OnClientClick="return validarAgregarTelefono();" OnClick="ButtonAgregarTelefono_Click" class="btn btn-primary" Text="Agregar teléfono" />
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-4">
                    <asp:GridView ID="GridViewTelefonos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                        <Columns>
                            <asp:BoundField DataField="Caracteristica" HeaderText="Caracteristica" />
                            <asp:BoundField DataField="Numero" HeaderText="Número" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonBorrar" CssClass="glyphicon glyphicon-remove" class="linkGrilla" runat="server" OnClick="BorrarTelefono_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:Label ID="LabelValidacionCantidadTelefonos" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La sucursal debe tener al menos un teléfono"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonCrearSucursal" runat="server" OnClientClick="return validarFormSucursal();" OnClick="ButtonCrearSucursal_Click" class="btn btn-primary" Text="Agregar sucursal" />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
