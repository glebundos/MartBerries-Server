using AutoMapper;
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
        }
    }
}
