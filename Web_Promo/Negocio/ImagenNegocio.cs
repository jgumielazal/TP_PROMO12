using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listarPorId(int id)
        {

            List<Imagen> lista = new List<Imagen>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("select i.Id,i.IdArticulo,i.ImagenUrl from IMAGENES as i inner join ARTICULOS as a on i.IdArticulo=a.Id where a.id =@idArticulo");
                accesoDatos.setearParametro("@IdArticulo", id);
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.IDImagen = (int)accesoDatos.Lector["Id"];
                    imagen.IDArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    imagen.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];

                    lista.Add(imagen);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }


    }
}
