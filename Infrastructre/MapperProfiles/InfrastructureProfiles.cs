using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructre.MapperProfiles
{
    public class InfrastructureProfiles:Profile
    {
        public InfrastructureProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
