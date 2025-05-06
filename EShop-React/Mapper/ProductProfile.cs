using AutoMapper;
using EShop_React.Command;
using EShop_React.Commands;
using EShop_React.Models;

namespace EShop_React.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<AddProductCommand, Product>();
        }
    }
}
