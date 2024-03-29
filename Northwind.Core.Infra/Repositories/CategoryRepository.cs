﻿using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using Northwind.Core.Infra.Context;

namespace Northwind.Core.Infra.Repositories
{
    public class CategoryRepository : RepositoryGeneric<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext context) : base(context) { }
    }
}
