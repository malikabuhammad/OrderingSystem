using OrderingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Domain.DbModels
{
    public class Products
    {

        private Products() { }

        public Products(string name, string sku, decimal price, int stockQuantity)
        {
            Name = name;
            SKU = sku;
            Price = price;
            StockQuantity = stockQuantity;
        }
        [Key]

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string SKU { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Update(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void DecreaseStock(int qty)
        {
            if (qty <= 0)
                throw new DomainException("Quantity must be greater than 0.");

            if (StockQuantity < qty)
                throw new DomainException($"Insufficient stock for product SKU {SKU}.");

            StockQuantity -= qty;

        }

        public void IncreaseStock(int qty)
        {
            if (qty <= 0)
                throw new DomainException("Quantity must be greater than 0.");

            StockQuantity += qty;

        }
        public void MarkDeleted()
        {
            IsDeleted = true;
        }

        
        public static Products CreateFromDb(
         int id,
         string name,
         string sku,
         decimal price,
         int stockQuantity,
         DateTime createdAt,
         bool isDeleted,
         bool isActive)
        {
            return new Products
            {
                Id = id,
                Name = name,
                SKU = sku,
                Price = price,
                StockQuantity = stockQuantity,
                CreatedAt = createdAt,
                IsDeleted = isDeleted,
                IsActive = isActive
            };

        }
    }
}
    
