using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? Precio { get; set; }
        public string? Categoria { get; set; }

        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
