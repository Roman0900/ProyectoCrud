using ProyectoCrud.Models;

namespace ProyectoCrud.Interfaces
{
    public interface IProductoRepository
    {

        Task<IEnumerable<Producto>> GetAll();

        Task<bool> Add(Producto p);

        Task<bool> Update(Producto p);

        Task<bool> Delete(Producto p);

        Task<bool> Save();

        int MaxID();







    }
}
