using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Back_End.model.producto;

namespace Back_End.datos
{
    public class productoDatos
    {
        public List<ProductoModel> ObtenerTodosLosProductos()
        {
            Conexion conexion = new Conexion();
            string query = "sp_crud_producto";

            using (DbConnection dbConnection = new SqlConnection(conexion.getCadenaSQL()))
            {
                dbConnection.Open();
                using (DbCommand cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@opcion", 2)); // Opción 2 para obtener todos los productos

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        List<ProductoModel> productos = new List<ProductoModel>();

                        while (dr.Read())
                        {
                            ProductoModel producto = new ProductoModel();
                            producto.Id = dr.GetInt32(dr.GetOrdinal("id"));
                            producto.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                            producto.Precio = dr.GetDecimal(dr.GetOrdinal("precio"));
                            producto.Estado = dr.GetBoolean(dr.GetOrdinal("estado"));
                            producto.Detalle = dr.GetString(dr.GetOrdinal("detalle"));
                            producto.Imagen = dr.GetString(dr.GetOrdinal("imagen"));
                            productos.Add(producto);
                        }

                        return productos;
                    }
                }
            }
        }

    }
}
