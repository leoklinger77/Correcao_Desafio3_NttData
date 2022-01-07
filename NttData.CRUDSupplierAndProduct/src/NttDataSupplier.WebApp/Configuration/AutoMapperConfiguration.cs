using AutoMapper;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Category;
using NttDataSupplier.WebApp.Models.Supplier;

namespace NttDataSupplier.WebApp.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<NewCategoryViewModel, Category>();
            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, DetailsCategoryViewModel>();
            CreateMap<Category, DeleteCategoryViewModel>();

            CreateMap<PaginationModel<Category>, PaginationViewModel<CategoryViewModel>>();


            CreateMap<SupplierJuriDical, DeleteCategoryViewModel>();
            CreateMap<SupplierPhysical, DeleteCategoryViewModel>();
            CreateMap<NewSupplierViewModel, SupplierJuriDical>();
            CreateMap<NewSupplierViewModel, SupplierPhysical>();

            CreateMap<PaginationModel<Supplier>, PaginationViewModel<SupplierViewModel>>();
        }
    }
}
