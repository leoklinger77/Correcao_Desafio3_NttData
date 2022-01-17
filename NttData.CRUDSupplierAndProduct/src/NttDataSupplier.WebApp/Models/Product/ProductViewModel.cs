using Microsoft.AspNetCore.Http;
using NttDataSupplier.WebApp.Models.Category;
using NttDataSupplier.WebApp.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NttDataSupplier.WebApp.Models.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }

        public string Name { get; set; }
        public string BarCode { get; set; }
        public int QuantityStock { get; set; }
        public bool Active { get; set; }
        public decimal PriceSales { get; set; }
        public decimal PricePurchase { get; set; }

        public CategoryViewModel Category { get; set; }
        public SupplierViewModel Supplier { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }

        public DateTime InsertDate { get; set; }

        //Daqui para baixo são elementos responsaveis pelo o funcionamento da tela.        

        public string GetImageOne()
        {
            return Images?.ToList().Count >= 1 ? "product/" + Images.ToList()?[0].ImagePath : "/image.svg";
        }
        public string GetImageTwo()
        {
            return Images?.ToList().Count >= 2 ? "product/" + Images.ToList()?[1].ImagePath : "/image.svg";
        }

        public string GetImageTree()
        {
            return Images?.ToList().Count >= 3 ? "product/" + Images.ToList()?[2].ImagePath : "/image.svg";
        }

        public string GetImageFor()
        {
            return Images?.ToList().Count >= 4 ? "product/" + Images.ToList()?[3].ImagePath : "/image.svg";
        }

        public string GetImageFive()
        {
            return Images?.ToList().Count >= 5 ? "product/" + Images.ToList()?[4].ImagePath : "/image.svg";
        }
    }

    public class ImageViewModel
    {
        public string ImagePath { get; set; }
    }
}
