using AutoMapper;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Category;
using NttDataSupplier.WebApp.Models.Product;
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
            CreateMap<NewOrEditSupplierViewModel, SupplierJuriDical>().ReverseMap();
            CreateMap<NewOrEditSupplierViewModel, SupplierPhysical>().ReverseMap();
            CreateMap<SupplierPhysical, SupplierViewModel>();
            CreateMap<SupplierJuriDical, SupplierViewModel>();

            
            
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<EmailViewModel, Email>().ReverseMap();
            CreateMap<PhoneViewModel, Phone>().ReverseMap();

            CreateMap<PaginationModel<Supplier>, PaginationViewModel<SupplierViewModel>>().ReverseMap();

            
            CreateMap<Product, ProductViewModel>();            
            CreateMap<NewProductViewModel, Product>();
            CreateMap<NewImageViewModel, Image>();            
            CreateMap<Image, ImageViewModel>();

            CreateMap<EditProductViewModel, Product>().ReverseMap();
            CreateMap<EditImageViewModel, Image>().ReverseMap();

            CreateMap<PaginationModel<Product>, PaginationViewModel<ProductViewModel>>().ReverseMap();

           
            
        }
    }
}
