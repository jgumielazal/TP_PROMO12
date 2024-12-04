using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
namespace negocio
{
    public class ArticuloNegocio
    {
        public void modificar(Articulo articulo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca , IdCategoria=@IdCategoria ,Precio=@Precio where Id=@Id");

                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.IDMarca);
                datos.setearParametro("@IdCategoria", articulo.Categoria.IDCategoria);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.IDArticulo);

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
        public void eliminar(int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("delete from ARTICULOS where id=@id");
                datos.setearParametro("@id", id);
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

        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS VALUES (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.IDMarca);
                datos.setearParametro("IdCategoria",articulo.Categoria.IDCategoria);
                datos.setearParametro("@Precio", articulo.Precio);
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

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select a.Id,a.Codigo,a.Nombre,a.Descripcion, m.Descripcion as marcaDescripcion,m.Id as marcaId,c.Descripcion as categoriaDescripcion,c.Id as categoriaId ,a.Precio from ARTICULOS as a left join MARCAS AS m on a.IdMarca =m.Id left JOIN CATEGORIAS as c on a.IdCategoria = c.Id");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();

                    articulo.IDArticulo = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["marcaDescripcion"] is DBNull))
                    {
                        articulo.Marca= new Marca();
                        articulo.Marca.Nombre = (string)datos.Lector["marcaDescripcion"];
                        articulo.Marca.IDMarca = (int)datos.Lector["marcaId"];
                    }

                    if (!(datos.Lector["categoriaDescripcion"] is DBNull))
                    {   
                        articulo.Categoria= new Categoria();
                        articulo.Categoria.Nombre = (string)datos.Lector["categoriaDescripcion"];
                        articulo.Categoria.IDCategoria = (int)datos.Lector["categoriaId"];
                    }
                        
                 
                    
                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);

                    ImagenNegocio negocioImg= new ImagenNegocio();
                    articulo.Imagenes = negocioImg.listarPorId(articulo.IDArticulo);


                    lista.Add(articulo);

               
                }
                return lista;


            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List <Articulo> lista= new List<Articulo>();
            AccesoDatos datos=new AccesoDatos();
            string consulta = "select a.Id,a.Codigo,a.Nombre,a.Descripcion, m.Descripcion as marcaDescripcion,m.Id as marcaId,c.Descripcion as categoriaDescripcion,c.Id as categoriaId ,a.Precio from ARTICULOS as a left join MARCAS AS m on a.IdMarca =m.Id left JOIN CATEGORIAS as c on a.IdCategoria = c.Id where ";
            try
            {
                switch (campo)
                {
                    case "Id":

                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "a.Id > "+filtro;
                                break;

                            case "Menor a":
                                consulta += "a.Id < " + filtro;
                                break;

                            case "Igual a":
                                consulta += "a.Id = " + filtro;
                                break;


                        }

                        break;

                    case "Codigo":
                        switch (criterio)
                        {
                            case "Termina en":
                                consulta += "a.Codigo like '%" + filtro + "'";
                                break;

                            case "Comienza con":
                                consulta += "a.Codigo like '" + filtro + "%'";
                                break;

                            case "Contiene":
                                consulta += "a.Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Termina en":
                                consulta += "a.Nombre like '%" + filtro + "'";
                                break;

                            case "Comienza con":
                                consulta += "a.Nombre like '" + filtro + "%'";
                                break;

                            case "Contiene":
                                consulta += "a.Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Termina en":
                                consulta += "a.Descripcion like '%" + filtro + "'";
                                break;

                            case "Comienza con":
                                consulta += "a.Descripcion like '" + filtro + "%'";
                                break;

                            case "Contiene":
                                consulta += "a.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Marca":
                        switch (criterio)
                        {
                            case "Termina en":
                                consulta += "m.Descripcion like '%" + filtro + "'";
                                break;

                            case "Comienza con":
                                consulta += "m.Descripcion like '" + filtro + "%'";
                                break;

                            case "Contiene":
                                consulta += "m.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Categoria":
                        switch (criterio)
                        {
                            case "Termina en":
                                consulta += "c.Descripcion like '%" + filtro + "'";
                                break;

                            case "Comienza con":
                                consulta += "c.Descripcion like '" + filtro + "%'";
                                break;

                            case "Contiene":
                                consulta += "c.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Precio":

                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "a.Precio > " + filtro;
                                break;

                            case "Menor a":
                                consulta += "a.Precio < " + filtro;
                                break;

                            case "Igual a":
                                consulta += "a.Precio = " + filtro;
                                break;


                        }

                        break;




                }

                datos.setearConsulta(consulta);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();

                    articulo.IDArticulo = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["marcaDescripcion"] is DBNull))
                    {
                        articulo.Marca = new Marca();
                        articulo.Marca.Nombre = (string)datos.Lector["marcaDescripcion"];
                        articulo.Marca.IDMarca = (int)datos.Lector["marcaId"];
                    }

                    if (!(datos.Lector["categoriaDescripcion"] is DBNull))
                    {
                        articulo.Categoria = new Categoria();
                        articulo.Categoria.Nombre = (string)datos.Lector["categoriaDescripcion"];
                        articulo.Categoria.IDCategoria = (int)datos.Lector["categoriaId"];
                    }



                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);


                    lista.Add(articulo);


                }




                return lista;
            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool existeArticulo(string nombre,int idActual = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE Nombre = @nombre");
                datos.setearParametro("@nombre",nombre);
                datos.setearParametro("@id", idActual);
                datos.ejecutarConsulta();

                if (datos.Lector.Read()&& (int)datos.Lector[0]>0)
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
