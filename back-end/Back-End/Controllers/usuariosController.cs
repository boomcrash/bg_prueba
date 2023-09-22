using Back_End.datos;
using Back_End.model.login;
using Back_End.model.usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    public class usuariosController : Controller
    {

        private readonly usuarioDatos _usuarioDatos;

        public usuariosController()
        {
            _usuarioDatos = new usuarioDatos();
        }

        [HttpPost("usuarios")]
        public IActionResult VerificarCredenciales([FromBody] AutenticarUsuarioRequest request)
        {

            // Verificar las credenciales (usuario y contraseña)
            bool credencialesValidas = _usuarioDatos.VerificarCredenciales(request.datosUsuario.email, request.datosUsuario.password);

            if (credencialesValidas)
            {
                UsuarioModel usuario = _usuarioDatos.ObtenerUsuarioPorEmail(request.datosUsuario.email);
                AutenticarUsuarioResponse response = new AutenticarUsuarioResponse();
                response.codigoRetorno = "0001";
                response.mensajeRetorno = "consulta correcta";

                Usuario userRepsonse= new Usuario();
                userRepsonse.plan = usuario.Plan;
                userRepsonse.email = usuario.Email;
                userRepsonse.nombre = usuario.Nombre;
                userRepsonse.telefono = usuario.Telefono;

                response.usuario = userRepsonse;
                    return Ok(response);
            }

            return Unauthorized(new AutenticarUsuarioResponse());
        }
    }
}
