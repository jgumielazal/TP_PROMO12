using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listar()
        {

            List<Categoria> lista = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Id,Descripcion from CATEGORIAS");
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IDCategoria = (int)accesoDatos.Lector["Id"];
                    categoria.Nombre = (string)accesoDatos.Lector["Descripcion"];

                    lista.Add(categoria);
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

        public void agregar(Categoria nuevaCategoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion) VALUES (@descripcion)");
                datos.setearParametro("@descripcion", nuevaCategoria.Nombre);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @id");
                datos.setearParametro("@descripcion", categoria.Nombre);
                datos.setearParametro("@id", categoria.IDCategoria);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("DELETE FROM CATEGORIAS WHERE Id = @id");
                datos.setearParametro("@id", idCategoria);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool existeCategoria(string nombre)
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CATEGORIAS WHERE Descripcion = @nombre");
                datos.setearParametro("@nombre",nombre);
                datos.ejecutarConsulta();

                if (datos.Lector.Read()&& (int)datos.Lector[0]>0) //LEE linea x linea y si encuentra otro nombre que coincida suma +1.// mayor a cero = ya estaba en lista
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }

}



