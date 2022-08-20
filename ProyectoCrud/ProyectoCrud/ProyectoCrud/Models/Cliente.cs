using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Cliente1 { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Mail { get; set; } = null!;

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
