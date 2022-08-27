using System.ComponentModel.DataAnnotations;

namespace ProyectoCrud.Models.ViewModels
{
    public class ProductoViewModel
    {

        [Required]
        public int ID { get; set; }

        [Required]
        public String Nombre { get; set; }

        [Required]
        public decimal? Precio { get; set; }

        [Required]
        public string? Categoria { get; set; }



    }
}
