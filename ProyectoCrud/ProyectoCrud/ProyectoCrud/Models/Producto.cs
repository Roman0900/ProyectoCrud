using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalleventa = new HashSet<Detalleventum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? Precio { get; set; }
        public string? Categoria { get; set; }

        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
    }
}
