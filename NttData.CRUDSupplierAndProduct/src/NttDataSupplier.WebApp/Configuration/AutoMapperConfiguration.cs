using AutoMapper;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Category;

namespace NttDataSupplier.WebApp.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {            
            CreateMap<NewCategoryViewModel, Category>();
            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>();
            
            CreateMap<PaginationModel<Category>, PaginationViewModel<CategoryViewModel>>();
        }
    }
}
