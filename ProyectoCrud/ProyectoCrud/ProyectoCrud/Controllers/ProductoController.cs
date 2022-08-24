using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Data;

namespace ProyectoCrud.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProyectoCrudContext _context;


        public ProductoController(ProyectoCrudContext context)
        {
            _context = context;
        }





        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }
    }
}
