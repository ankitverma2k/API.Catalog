using API.Catalog.Models;
using API.Catalog.Repositories;

namespace API.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            _repository=repository;
        }
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
           return _repository.GetAll();
        }

        public Task<Category?> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Category item)
        {
            return _repository.Insert(item);
        }

        public Task Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
