using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using Northwind.Core.Domain.Services;

namespace Northwind.Core.Service.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IRepositoryGeneric<Category> repository) : base(repository)
        {
        }
    }
}