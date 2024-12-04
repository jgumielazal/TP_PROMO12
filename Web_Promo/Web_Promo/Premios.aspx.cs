using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Promo
{
    public partial class Premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["CodigoVoucher"] == null)
                {
                    Response.Redirect("Default.aspx");
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                rptArticulos.DataSource = negocio.listar();
                rptArticulos.DataBind();
            }

        }

        
        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//procesa los items y los alternados
            { 
                Articulo articulo = (Articulo)e.Item.DataItem;

                ((Label)e.Item.FindControl("lblNombre")).Text = articulo.Nombre;
                ((Label)e.Item.FindControl("lblDescripcion")).Text = articulo.Descripcion;
                ((Button)e.Item.FindControl("btnElegir")).CommandArgument = articulo.IDArticulo.ToString(); /// Guarda el ID del artículo en los botones
                ((Button)e.Item.FindControl("btnSiguiente")).CommandArgument = articulo.IDArticulo.ToString();

                Image img = (Image)e.Item.FindControl("imgArticulo");
                ImagenNegocio imgNegocio = new ImagenNegocio();
                img.ImageUrl = imgNegocio.listarPorId(articulo.IDArticulo)[0];//// obtiene primera imagen
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;  // botón que hice click
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;//obtiene el contenedor (la card)
            Image img = (Image)item.FindControl("imgArticulo");// encuentra la imagen
            int articuloId = Convert.ToInt32(btn.CommandArgument);// consigue el ID guardado antes

            ImagenNegocio negocio = new ImagenNegocio();
            img.ImageUrl = negocio.obtenerSiguienteImagen(articuloId, img.ImageUrl);// trae la siguiente imagen basado en la URL actual
        }
        protected void btnElegir_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["PremioSeleccionado"] = btn.CommandArgument;
            Response.Redirect("IngresarDatos.aspx");
        }
    }
}