using Northwind.Core.Domain;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using Northwind.Core.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Infra.Repositories
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        public ProductRepository(NorthwindContext context) : base(context) { }

    }
}
