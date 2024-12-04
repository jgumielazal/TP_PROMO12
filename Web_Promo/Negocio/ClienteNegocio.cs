using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public void guardar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp); SELECT Id FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", cliente.Documento);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@ciudad", cliente.Ciudad);
                datos.setearParametro("@cp", cliente.CodPost);

                datos.ejecutarConsulta();
                datos.Lector.Read();
                cliente.IdCliente = (int)datos.Lector["Id"];
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

        public Cliente buscarXDNI(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @DNI");
                datos.setearParametro("@DNI", dni);
                datos.ejecutarConsulta();

                if (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = (int)datos.Lector["Id"];
                    cliente.Documento = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.CodPost = (int)datos.Lector["CP"];

                    return cliente;
                }
                return null;
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
