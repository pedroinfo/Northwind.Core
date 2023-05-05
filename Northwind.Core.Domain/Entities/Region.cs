using System;
using System.Collections.Generic;

namespace Northwind.Core.Domain.Entities
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; set; }
    }
}
