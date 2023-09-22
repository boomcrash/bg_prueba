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
            if (request != null && request.transaccion == "generico" && request.tipo == "4")
            {
                GenericoResponse productos = ObtenerTodosLosProductos();

                if (productos != null)
                {
                    return Ok(productos);
                }
            }

            return BadRequest("Solicitud inválida");
        }

        private GenericoResponse ObtenerTodosLosProductos()
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

                    cmd.Parameters.Add(new SqlParameter("@opcion", 2)); 
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        List<DatosItem> productos = new List<DatosItem>();

                        while (dr.Read())
                        {
                            DatosItem producto = new DatosItem();
                            producto.id = dr.GetInt32(dr.GetOrdinal("id"));
                            producto.descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                            producto.precio = dr.GetDecimal(dr.GetOrdinal("precio"));
                            producto.estado = dr.GetBoolean(dr.GetOrdinal("estado"));
                            producto.detalle = dr.GetString(dr.GetOrdinal("detalle"));
                            producto.imagen = dr.GetString(dr.GetOrdinal("imagen"));
                            productos.Add(producto);
                        }

                        GenericoResponse response = new GenericoResponse();
                        response.codigoRetorno = "0001";
                        response.mensajeRetorno = "Consulta Ok";
                        response.data = productos;
                        return response;
                    }
                }
            }
        }
    }




}
