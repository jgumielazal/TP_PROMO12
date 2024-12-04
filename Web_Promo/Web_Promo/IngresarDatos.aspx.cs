using Dominio;
using negocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Promo
{
    public partial class IngresarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CodigoVoucher"] == null || Session["PremioSeleccionado"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkTermsConds.Checked)
                {
                    lblErrorTerminos.Visible = true;
                    return;
                }
                if (!txtEmail.Text.Contains("@"))
                {
                    lblErrorArroba.Visible = true;

                    return;
                }

                if (validarCampos())
                {
                    //cliente nuevo
                    Cliente cliente = new Cliente();
                    cliente.Documento = txtDNI.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CodPost = int.Parse(txtCodPos.Text);//int en el sql

                    ClienteNegocio clnegocio = new ClienteNegocio();
                    clnegocio.guardar(cliente);

                    VoucherNegocio voucherNegocio = new VoucherNegocio();
                    voucherNegocio.canjearVoucher(Session["CodigoVoucher"].ToString(), cliente.IdCliente, int.Parse(Session["PremioSeleccionado"].ToString()));

                    //lbl de éxito
                    lblResultado.Visible = true;
                    //REDIRECCION A DEFAULT
                    Response.AddHeader("REFRESH", "5;URL=Default.aspx");
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("Error  carga de formulario" + ex);
            }
        }
        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtCiudad.Text) ||
                string.IsNullOrEmpty(txtCodPos.Text))
            {
                lblErrorCampoVacio.Visible = true;
                return false;
            }

            return true;

        }

        protected void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = negocio.buscarXDNI(txtDNI.Text);
            // si trae correctamente cliente ► precarga
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCodPos.Text = cliente.CodPost.ToString();
            }
        }
    }
}