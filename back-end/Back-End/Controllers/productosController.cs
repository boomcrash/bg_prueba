using Back_End.datos;
using Back_End.model.login;
using Back_End.model.producto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Back_End.Controllers
{
    public class productosController : Controller
    {

        private readonly productoDatos _productoDatos;

        public productosController()
        {
            _productoDatos = new productoDatos();
        }


        [HttpPost("productos")]
        public IActionResult ObtenerTodosLosProductos([FromBody] GenericoRequest request)
        {
            // Verificar que el objeto de solicitud tenga la transacción y tipo esperados
            if (request != null && request.transaccion == "generico" && request.tipo == "4")
            {
                // Llamar a la función para obtener todos los productos
                List<ProductoModel> productos = ObtenerTodosLosProductos();

                if (productos != null)
                {
                    // Construir la respuesta
                    var respuesta = new
                    {
                        codigoRetorno = "0001",
                        mensajeRetorno = "Consulta Ok",
                        data = productos
                    };

                    return Ok(respuesta);
                }
            }

            // Si la solicitud es incorrecta, retornar un mensaje de error
            return BadRequest("Solicitud inválida");
        }

        // Función para obtener todos los productos (debe ser proporcionada)
        private List<ProductoModel> ObtenerTodosLosProductos()
        {
            // Debes implementar esta función de acuerdo a tu lógica para obtener productos desde la base de datos
            // Por ejemplo, puedes llamar a tu función existente ObtenerTodosLosProductos aquí.
            // Asumo que la función devuelve una lista de ProductoModel.
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
