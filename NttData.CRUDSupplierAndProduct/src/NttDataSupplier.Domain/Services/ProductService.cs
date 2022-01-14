using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Models.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;
        public ProductService(INotificationService notificationService, IProductRepository productRepository, IImageService imageService) : base(notificationService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
        }

        public override async Task<PaginationModel<Product>> Pagination(int page, int size, string query)
        {
            if (string.IsNullOrEmpty(query))
                return await _productRepository.Pagination(page, size, null);
            else
                return await _productRepository.Pagination(page, size, x => x.Name.Contains(query));
        }

        public override async Task<Product> FindById(Guid id)
        {
            var result = await _productRepository.Find(x => x.Id == id);

            if (result == null) Notify("produto não localizada");

            return result;
        }

        public async Task Insert(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;
            foreach (var item in product.Images)
                if (!RunValidation(new ImageValidation(), item)) return;

            var result = await _productRepository.Find(x => x.Name.Contains(product.Name) || x.BarCode.Contains(product.BarCode));
            if (result != null)
            {
                if (result.Name == product.Name)
                    Notify($"O nome {product.Name} já esta cadastrado para outro produto");
                if (result.BarCode == product.BarCode)
                    Notify($"O nome {product.BarCode} já esta cadastrado para outro produto");

                return;
            }

            var model = new Product(product.SupplierId, product.CategoryId, product.Name, product.BarCode, product.QuantityStock, product.Active, product.PriceSales, product.PricePurchase);
            product.Images.ToList().ForEach(x => model.AddImage(x.ImagePath));

            await _productRepository.Insert(model);

            if (await _productRepository.SaveChanges() > 0)
                _imageService.MoveTempToFixed(model.Images.Select(x => x.ImagePath).ToList());
        }
    }
}
