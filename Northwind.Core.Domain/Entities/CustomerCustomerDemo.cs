using System;
using System.Collections.Generic;

namespace Northwind.Core.Domain.Entities
{
    public class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public Customers Customer { get; set; }
        public CustomerDemographics CustomerType { get; set; }
    }
}
