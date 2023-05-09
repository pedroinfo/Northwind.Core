using AutoMapper;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Web.ViewModels;

namespace Northwind.Core.Web.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
