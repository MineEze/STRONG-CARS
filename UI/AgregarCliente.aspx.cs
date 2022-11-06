using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace UI
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "VentasCliente"))
                Response.Redirect("NoEncontrado.aspx");

            OpcionesEmpresa();

            LabelCreacionClienteExito.Visible = false;

            if (!IsPostBack)
            {
                var bllCliente = new BLLCliente();
                RadioButtonListEmpresasExistentes.DataSource = bllCliente.ListarEmpresas();
                RadioButtonListEmpresasExistentes.DataBind();
            }
        }

        public void OpcionesEmpresa()
        {
            var seleccionEmpresa = RadioButtonListEmpresa.SelectedIndex;

            var opcionesEmpresa = new List<string>();
            opcionesEmpresa.Add("No pertenece a una empresa");
            opcionesEmpresa.Add("Pertenece a una empresa nueva");
            opcionesEmpresa.Add("Pertenece a una empresa existente");

            RadioButtonListEmpresa.DataSource = opcionesEmpresa;
            RadioButtonListEmpresa.SelectedIndex = seleccionEmpresa;
            RadioButtonListEmpresa.DataBind();
        }

        protected void ButtonCrearCliente_Click(object sender, EventArgs e)
        {
            if (RadioButtonListEmpresa.SelectedIndex == -1)
            {
                LabelValidacionEmpresa.Visible = true;
                return;
            }
            else
                LabelValidacionEmpresa.Visible = false;

            if (RadioButtonListEmpresa.SelectedIndex == 1 && TextBoxEmpresaNombre.Text == "")
            {
                LabelValidacionEmpresaNombre.Visible = true;
                return;
            }
            else
                LabelValidacionEmpresaNombre.Visible = false;

            if (RadioButtonListEmpresa.SelectedIndex == 2 && RadioButtonListEmpresasExistentes.SelectedIndex == -1)
            {
                LabelValidacionEmpresaSeleccion.Visible = true;
                return;
            }
            else
                LabelValidacionEmpresaSeleccion.Visible = false;

            var cliente = new Cliente
            {
                Nombre = TextBoxNombre.Text,
                Apellido = TextBoxApellido.Text,
                DNI = TextBoxDNI.Text,
                Licencia = TextBoxLicencia.Text,
                Email = TextBoxEmail.Text,
                Direccion = new Direccion
                {
                    Calle = TextBoxCalle.Text,
                    Altura = Convert.ToInt32(TextBoxAltura.Text),
                    Unidad = TextBoxUnidad.Text,
                    CodigoPostal = TextBoxCodigoPostal.Text
                },
                Telefono = new Telefono
                {
                    Caracteristica = TextBoxTelefonoCaracteristica.Text,
                    Numero = TextBoxTelefonoNumero.Text
                }
            };

            var bllCliente = new BLLCliente(Session["Usuario"] as Usuario);

            if (RadioButtonListEmpresa.SelectedIndex == 1)
                cliente.Empresa = new Empresa { Nombre = TextBoxEmpresaNombre.Text };

            if (RadioButtonListEmpresa.SelectedIndex == 2)
                cliente.Empresa = bllCliente.ListarEmpresas().First(em => em.Nombre == RadioButtonListEmpresasExistentes.SelectedValue);

            bllCliente.AltaCliente(cliente);

            TextBoxNombre.Enabled = false;
            TextBoxApellido.Enabled = false;
            TextBoxDNI.Enabled = false;
            TextBoxLicencia.Enabled = false;
            TextBoxEmail.Enabled = false;
            TextBoxCalle.Enabled = false;
            TextBoxAltura.Enabled = false;
            TextBoxUnidad.Enabled = false;
            TextBoxCodigoPostal.Enabled = false;
            TextBoxTelefonoCaracteristica.Enabled = false;
            TextBoxTelefonoNumero.Enabled = false;

            ButtonCrearCliente.Enabled = false;
            ButtonCrearCliente.CssClass = "btn btn-primary";
            LabelCreacionClienteExito.Visible = true;
        }

        protected void RadioButtonListEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListEmpresa.SelectedIndex == 1)
            {
                LabelEmpresaNombre.Visible = true;
                TextBoxEmpresaNombre.Visible = true;
            }
            else
            {
                LabelEmpresaNombre.Visible = false;
                TextBoxEmpresaNombre.Visible = false;
                LabelValidacionEmpresaNombre.Visible = false;
            }

            if (RadioButtonListEmpresa.SelectedIndex == 2)
            {
                LabelEmpresa.Visible = true;
                RadioButtonListEmpresasExistentes.Visible = true;
            }
            else
            {
                LabelEmpresa.Visible = false;
                RadioButtonListEmpresasExistentes.Visible = false;
                LabelValidacionEmpresaSeleccion.Visible = false;
            }
        }
    }
}