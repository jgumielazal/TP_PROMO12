using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
namespace negocio
{
    public class MarcaNegocio
    {
        public void eliminar(int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("delete from MARCAS where id=@IDMarca");
                datos.setearParametro("@IDMarca", id);
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
        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO MARCAS  VALUES (@descripcion)");
                // datos.setearParametro("@id", marca.IDMarca);
                datos.setearParametro("@Descripcion", marca.Nombre);
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
        public void modificar(Marca marca)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET Descripcion=@Descripcion where Id = @id");
                datos.setearParametro("@Descripcion", marca.Nombre);
                datos.setearParametro("@id", marca.IDMarca);
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

        public List<Marca> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> lista = new List<Marca>();
            try
            {
                datos.setearConsulta("SELECT Id,Descripcion from MARCAS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.IDMarca = (int)datos.Lector["Id"];
                    marca.Nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(marca);
                }

                return lista;


            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public bool existeMarca(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE Descripcion  = @nombre");
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarConsulta();

                if (datos.Lector.Read() && (int)datos.Lector[0] > 0)
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
