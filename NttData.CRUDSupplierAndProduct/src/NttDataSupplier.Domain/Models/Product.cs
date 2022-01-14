using NttDataSupplier.Domain.Tools;
using System;
using System.Collections.Generic;

namespace NttDataSupplier.Domain.Models
{
    public class Product : Entity
    {
        public Guid CategoryId { get; private set; }
        public Guid SupplierId { get; private set; }

        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public int QuantityStock { get; private set; }
        public bool Active { get; private set; }
        public decimal PriceSales { get; private set; }
        public decimal PricePurchase { get; private set; }

        public Category Category { get; private set; }
        public Supplier Supplier { get; private set; }



        private List<Image> _image = new List<Image>();
        public IReadOnlyCollection<Image> Images => _image;

        protected Product() { }
        public Product(Guid supplierId, Guid categoryId, string name, string barCode, int quantityStock, bool active, decimal priceSales, decimal pricePurchase)
        {
            CategoryId = categoryId;
            SupplierId = supplierId;
            BarCode = barCode;
            Active = active;
            SetName(name);            
            AddQuantity(quantityStock);
            SetPricePurchase(pricePurchase);
            
            SetPriceSales(priceSales);            
        }

        public void AddImage(string path)
        {
            _image.Add(new Image(Id, path));
        }

        public void SetName(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "O nome não pode ser nulo ou vazio");
            Name = value;
        }
        public void AddQuantity(int quantity)
        {
            DomainValidation.ValidateIfTrue(quantity < 0, "A quantidade a ser adicionada não pode ser menor que zero");
            QuantityStock += quantity;
        }
        public void RemoveQuantity(int quantity)
        {
            if (QuantityStock - quantity < 0)
            {
                QuantityStock = 0;
            }
            else
            {
                QuantityStock -= quantity;
            }                    
        }
        public void SetPriceSales(decimal value)
        {
            //O valor de venda sempre deve ser maior que o preço de compra
            DomainValidation.ValidateIfTrue(value <= PricePurchase, "O preço de venda não pode ser menor que o preço de compra");
            PriceSales = value;
        }
        
        public void Enable()
        {
            Active = true;
        }
        public void Disable()
        {
            Active = false;
        }

        private void SetPricePurchase(decimal value)
        {
            //O valor de compra não pode ser menor ou igual que zero
            DomainValidation.ValidateIfTrue(value <= 0, "O preço de compra não pode ser menor ou igual que 0");
            PricePurchase = value;
        }
    }
}
