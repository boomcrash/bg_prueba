namespace Back_End.model.usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int? Plan { get; set; }
        public string Telefono { get; set; }
    }


}
