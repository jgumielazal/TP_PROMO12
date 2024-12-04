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
        public List<string> listarPorId(int id)
        {

            List<string> lista = new List<string>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())// lee cada URL y la guarda en la lista
                {
                    Imagen imagen = new Imagen();
                    imagen.IDImagen = (int)accesoDatos.Lector["Id"];
                    imagen.IDArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    imagen.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];

                    lista.Add((string)accesoDatos.Lector["ImagenUrl"]);
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

        public string obtenerSiguienteImagen(int idArticulo, string urlActual)
        {
            List<string> urls = listarPorId(idArticulo);// me trae todas las urls
            int posicionActual = urls.IndexOf(urlActual);// Busca cuál está mostrando

            if (posicionActual == urls.Count - 1)
                return urls[0];//volver al principio
            else
                return urls[posicionActual + 1];
        }


    }
}
