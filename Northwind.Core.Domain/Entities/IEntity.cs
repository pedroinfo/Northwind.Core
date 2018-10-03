using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Domain.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
