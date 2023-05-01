using Artsofte.Domain.Entities;
using Artsofte.Service.Dtos.Accounts;
using Artsofte.Service.ViewModels.AccountViewModels;
using Artsofte.Service.ViewModels.DepartmentViewModels;
using Artsofte.Service.ViewModels.LanguageViewModels;
using AutoMapper;

namespace Artsofte.Mvc.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AccountCreateDto, Human>().ReverseMap();
            CreateMap<AccountViewModel, Human>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
            CreateMap<LanguageViewModel, Language>().ReverseMap();
        }
    }
}
