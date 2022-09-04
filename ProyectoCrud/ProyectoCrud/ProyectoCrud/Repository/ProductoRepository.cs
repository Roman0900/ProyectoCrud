using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Data;
using ProyectoCrud.Interfaces;
using ProyectoCrud.Models;

namespace ProyectoCrud.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProyectoCrudContext _context;

        public ProductoRepository(ProyectoCrudContext context)
        {
            _context = context;
        }

        
        public async Task<bool> Add(Producto p)
        {
            _context.Productos.Add(p);
            return await Save();
        }

        public async Task<bool> Delete(Producto p)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            var Productos = await _context.Productos.ToListAsync();
            return Productos;
        }


        public async Task<bool> Update(Producto p)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            var Result = await _context.SaveChangesAsync();
            return Result > 0 ? true : false;
        }

        public int MaxID()
        {
            return _context.Productos.Max(i => i.Id);


        }
    }
}
