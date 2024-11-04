using System.Collections.Generic;

namespace ECommerceUnitTesting
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Description { get; }

        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public decimal CalculateDiscount(decimal discountPercentage)
        {
            return Price - (Price * discountPercentage / 100);
        }

        public decimal CalculateTax(decimal taxPercentage)
        {
            return Price * taxPercentage / 100;
        }
    }
}