using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoCrud.Data;
using ProyectoCrud.Models;
using ProyectoCrud.Models.ViewModels;

namespace ProyectoCrud.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProyectoCrudContext _context;


        public ProductoController(ProyectoCrudContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> List()
        {
            return View(await _context.Productos.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto()
                {
                    Id = _context.Productos.Max(x => x.Id) + 1,
                    Nombre = model.Nombre,
                    Precio = model.Precio,
                    Categoria = model.Categoria
                };

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");



            }
            
            return View(model);
        }




    }



}

