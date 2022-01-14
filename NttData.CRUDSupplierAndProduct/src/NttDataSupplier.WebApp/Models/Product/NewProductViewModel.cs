using Microsoft.AspNetCore.Http;
using NttDataSupplier.WebApp.Models.Category;
using NttDataSupplier.WebApp.Models.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NttDataSupplier.WebApp.Models.Product
{
    public class NewProductViewModel
    {
        //Atributos do dominio necessarios para criação do produto.

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo código de barras é obrigatorio")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "O campo código de barras deve conter entre {2} e {1} caracteres")]
        [Display(Name = "Código de barras")]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [Range(0, int.MaxValue)]
        [Display(Name = "Quantidade do estoque")]
        public int QuantityStock { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        [Display(Name = "Preço de venda")]
        [Required(ErrorMessage = "O campo preço de venda é obrigatorio")]
        [Range(0.1, double.MaxValue)]
        public decimal PriceSales { get; set; }

        [Required(ErrorMessage = "O campo preço de compra é obrigatorio")]
        [Range(0.1, double.MaxValue)]
        [Display(Name = "Preço de compra")]
        public decimal PricePurchase { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }

        public Guid SupplierId { get; set; }
        public SupplierViewModel Supplier { get; set; }

        public ICollection<NewImageViewModel> Images { get; set; } = new List<NewImageViewModel>();


        //Daqui para baixo são elementos responsaveis pelo o funcionamento da tela.
        public IEnumerable<SupplierViewModel> ListSupplier { get; set; } = new List<SupplierViewModel>();
        public IEnumerable<CategoryViewModel> ListCategory { get; set; } = new List<CategoryViewModel>();

        public IFormFile ImageOne { get; set; }
        public IFormFile ImageTwo { get; set; }
        public IFormFile ImageTree { get; set; }
        public IFormFile ImageFor { get; set; }
        public IFormFile ImageFive { get; set; }

        public string GetImageOne()
        {
            return Images?.ToList().Count >= 1 ? "temp/" + Images.ToList()?[0].ImagePath : "/image.svg";
        }
        public string GetImageTwo()
        {
            return Images?.ToList().Count >= 2 ? "temp/" + Images.ToList()?[1].ImagePath : "/image.svg";
        }

        public string GetImageTree()
        {
            return Images?.ToList().Count >= 3 ? "temp/" + Images.ToList()?[2].ImagePath : "/image.svg";
        }

        public string GetImageFor()
        {
            return Images?.ToList().Count >= 4 ? "temp/" + Images.ToList()?[3].ImagePath : "/image.svg";
        }

        public string GetImageFive()
        {
            return Images?.ToList().Count >= 5 ? "temp/" + Images.ToList()?[4].ImagePath : "/image.svg";
        }

    }

    public class NewImageViewModel
    {
        public string ImagePath { get; set; }
    }
}
