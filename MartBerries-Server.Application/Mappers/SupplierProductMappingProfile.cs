using AutoMapper;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Mappers
{
    public class SupplierProductMappingProfile : Profile
    {
        public SupplierProductMappingProfile()
        {
            CreateMap<CreateSupplierProductCommand, SupplierProduct>().ReverseMap();
            CreateMap<SupplierProduct, Product>()
                .ForMember(x => x.Price, m => m.MapFrom(a => a.Price))
                .ForMember(x => x.Name, m => m.MapFrom(a => a.Name));
        }
    }
}
