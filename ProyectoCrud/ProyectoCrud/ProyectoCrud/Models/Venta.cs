using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateOnly? Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
