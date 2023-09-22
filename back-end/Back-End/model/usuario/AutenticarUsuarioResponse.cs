namespace Back_End.model.login
{
    using System;

    public class AutenticarUsuarioResponse
    {
        public string codigoRetorno { get; set; }
        public string mensajeRetorno { get; set; }
        public Usuario usuario { get; set; }
    }

    public class Usuario
    {
        public string email { get; set; }
        public string nombre { get; set; }
        public int? plan { get; set; }
        public string telefono { get; set; }
    }

}
