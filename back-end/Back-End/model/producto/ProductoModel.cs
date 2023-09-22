namespace Back_End.model.producto
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
        public string Detalle { get; set; }
        public string Imagen { get; set; }
    }

}
