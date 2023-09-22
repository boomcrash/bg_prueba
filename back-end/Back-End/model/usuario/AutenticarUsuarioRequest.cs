namespace Back_End.model.login
{
    using System;

    public class AutenticarUsuarioRequest
    {
        public string transaccion { get; set; }
        public DatosUsuario datosUsuario { get; set; }
    }

    public class DatosUsuario
    {
        public string email { get; set; }
        public string password { get; set; }
    }

}
