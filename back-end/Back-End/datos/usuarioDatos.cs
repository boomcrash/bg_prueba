using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Back_End.model.usuario;

namespace Back_End.datos
{
    public class usuarioDatos
    {
        public bool VerificarCredenciales(string email, string password)
        {
            Conexion conexion = new Conexion();
            string query = "sp_crud_login";

            using (DbConnection dbConnection = new SqlConnection(conexion.getCadenaSQL()))
            {
                dbConnection.Open();
                using (DbCommand cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@opcion", 2));
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@password", password));

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string mensaje = dr.GetString(dr.GetOrdinal("mensaje"));
                            return mensaje == "Usuario y contraseña válidos";
                        }
                    }
                }
            }
            return false; 
        }



        public UsuarioModel ObtenerUsuarioPorEmail(string email)
        {
            Conexion conexion = new Conexion();
            string query = "sp_crud_login";

            using (DbConnection dbConnection = new SqlConnection(conexion.getCadenaSQL()))
            {
                dbConnection.Open();
                using (DbCommand cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@opcion", 1));
                    cmd.Parameters.Add(new SqlParameter("@email", email));

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            UsuarioModel usuario = new UsuarioModel();
                            usuario.Id = dr.GetInt32(dr.GetOrdinal("id"));
                            usuario.Email = dr.GetString(dr.GetOrdinal("email"));
                            usuario.Password = dr.GetString(dr.GetOrdinal("password"));
                            usuario.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                            usuario.Plan = dr.IsDBNull(dr.GetOrdinal("plan")) ? (int?)null : dr.GetInt32(dr.GetOrdinal("plan"));
                            usuario.Telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? null : dr.GetString(dr.GetOrdinal("telefono"));
                            return usuario;
                        }
                    }
                }
            }
            return null; 
        }



    }
}
