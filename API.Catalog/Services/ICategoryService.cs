using API.Catalog.Models;

namespace API.Catalog.Services
{
    public interface ICategoryService
    {
        Task Delete(string id);
        Task<Category?> GetById(string id);
        Task<IEnumerable<Category>> GetAll();
        Task Insert(Category item);
        Task Update(Category item);
    }
}
