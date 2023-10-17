using Northwind.Core.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Core.Domain.Services
{
    public interface ICategoryService 
    {
         Task Add(Category category);

         Task Update(Category category);

         Task Delete(Category category);

         Task<Category> GetById(int id);

         Task<IList<Category>> GetAll();

    }
}
