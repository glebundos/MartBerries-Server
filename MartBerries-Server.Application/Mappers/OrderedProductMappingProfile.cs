using AutoMapper;
using MartBerries_Server.Application.Responses;
using MartBerries_Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Application.Commands.CreateNewOrderCommand;

namespace MartBerries_Server.Application.Mappers
{
    public class OrderedProductMappingProfile : Profile
    {
        public OrderedProductMappingProfile()
        {
            CreateMap<OrderedProductModel, OrderedProduct>().ReverseMap();
            CreateMap<OrderedProduct, OrderedProductResponse>()
                .ForMember(x => x.Name, m => m.MapFrom(a => a.Product.Name))
                .ForMember(x => x.Id, m => m.MapFrom(a => a.Product.Id))
                .ForMember(x => x.Amount, m => m.MapFrom(a => a.Amount))
                .ForMember(x => x.Price, m => m.MapFrom(a => a.Product.Price));
        }
    }
}
