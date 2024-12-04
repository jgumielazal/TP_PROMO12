using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using negocio;
namespace Negocio
{
    public class VoucherNegocio
    {
        public int ValidarVoucher(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT * FROM VOUCHERS WHERE CodigoVoucher = @CODIGO");
                datos.setearParametro("@CODIGO", codigo);
                datos.ejecutarConsulta();

                if (datos.Lector.Read())
                {
                    if (datos.Lector["FechaCanje"] == DBNull.Value)
                        return 1; //correcto
                    else
                        return 2; //canjeado / tarde
                }
                return 3; //no existe
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

        public void canjearVoucher(string codigo, int IDCliente, int IDArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE VOUCHERS SET IdCliente = @IDCliente, IdArticulo = @IDArticulo, FechaCanje = GETDATE() WHERE CodigoVoucher = @CODIGO");
                datos.setearParametro("@CODIGO", codigo);
                datos.setearParametro("@IDCliente", IDCliente);
                datos.setearParametro("@IDArticulo", IDArticulo);
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
    }
}