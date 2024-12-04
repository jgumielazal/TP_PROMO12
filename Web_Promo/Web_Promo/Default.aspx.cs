using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using Negocio;

namespace Web_Promo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherNegocio negocio = new VoucherNegocio();
                int resultado = negocio.ValidarVoucher(txtCodigoVoucher.Text);

                switch (resultado)
                {
                    case 1:
                        Session["CodigoVoucher"] = txtCodigoVoucher.Text;
                        Response.Redirect("Premios.aspx");
                        break;

                    case 2:
                        lblError.Text = "Código ya fue canjeado";
                        lblError.Visible = true;
                        break;

                    case 3:
                        lblError.Text = "Código invalido";
                        lblError.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error validando codigo" +ex.Message);
            }
        }
    }
}
