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
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
        }
    }
}
