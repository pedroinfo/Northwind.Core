using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using Northwind.Core.Domain.Services;
using System.Threading.Tasks;

namespace Northwind.Core.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryGeneric<Category> _categoryRepository;
        public CategoryService(IRepositoryGeneric<Category> repository) 
        {
            _categoryRepository = repository;
        }

        public async Task Add(Category category) 
        { 
             await _categoryRepository.InsertAsync(category);
        }


        public async Task Remove()
    }
}