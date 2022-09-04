using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoCrud.Data;
using ProyectoCrud.Interfaces;
using ProyectoCrud.Models;
using ProyectoCrud.Models.ViewModels;

namespace ProyectoCrud.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository ProductoRepository)
        {
            _productoRepository = ProductoRepository;
        }

        ///Vistas

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


        ///Funciones

        public async Task<IActionResult> List()
        {
            return View(await _productoRepository.GetAll());
        }


      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto()
                {
                    Id = _productoRepository.MaxID() + 1,
                    Nombre = model.Nombre,
                    Precio = model.Precio,
                    Categoria = model.Categoria
                };

              var a =  await _productoRepository.Add(producto);

                return RedirectToAction("List");
            }
            
            return View(model);
        }




    }



}

