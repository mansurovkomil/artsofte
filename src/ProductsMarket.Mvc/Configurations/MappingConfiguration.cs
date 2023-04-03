using AutoMapper;
using ProductsMarket.Domain.Entities.Admins;
using ProductsMarket.Domain.Entities.Products;
using ProductsMarket.Domain.Entities.Users;
using ProductsMarket.Service.Dtos.Admins;
using ProductsMarket.Service.ViewModels.ProductViewModels;
using ProductsMarket.Service.ViewModels.StudentViewModels;

namespace ProductsMarket.Mvc.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AdminRegisterDto, Admin>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
