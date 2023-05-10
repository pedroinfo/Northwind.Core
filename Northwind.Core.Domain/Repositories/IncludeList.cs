using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Domain.Repositories
{
    public class IncludeList<T> : List<Expression<Func<T, object>>>
    {
        public IncludeList(params Expression<Func<T, object>>[] expressions)
        {
            AddRange(expressions);
        }
    }
}
