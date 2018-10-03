using Northwind.Core.Domain;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Infra.Repositories
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
