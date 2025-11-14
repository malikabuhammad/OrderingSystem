using OrderingSystem.Domain.Common;
using System;
using System.Collections.Generic;
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
            Sku = sku;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public string Name { get; private set; }
        public string Sku { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool IsActive { get; private set; }

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
                throw new DomainException($"Insufficient stock for product SKU {Sku}.");

            StockQuantity -= qty;

        }

        public void IncreaseStock(int qty)
        {
            if (qty <= 0)
                throw new DomainException("Quantity must be greater than 0.");

            StockQuantity += qty;

        }
    }
}
