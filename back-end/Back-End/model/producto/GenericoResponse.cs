namespace Back_End.model.producto
{
    using System;
    using System.Collections.Generic;

    public class GenericoResponse
    {
        public string codigoRetorno { get; set; }
        public string mensajeRetorno { get; set; }
        public List<DatosItem> data { get; set; }
    }

    public class DatosItem
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }
        public string detalle { get; set; }
        public string imagen { get; set; }
    }

}
