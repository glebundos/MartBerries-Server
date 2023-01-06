using AutoMapper;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Models;
using MartBerries_Server.Core.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Mappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateNewOrderCommand, Order>().ReverseMap();
            CreateMap<Order, OrderResponse>()
                .ForMember(x => x.OrderedProducts, m => m.MapFrom(a => a.Products)).ReverseMap();
        }
    }
}
