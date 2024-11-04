using System.Collections.Generic;
using System;


namespace ECommerceUnitTesting
{
    public class ShoppingCart
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }
            _products.Remove(product);
        }

        public decimal CalculateTotalPrice(decimal discountPercentage, decimal taxPercentage)
        {
            decimal total = 0;

            // Calculate total price with discount applied
            foreach (var product in _products)
            {
                decimal discountedPrice = product.Price - (product.Price * (discountPercentage / 100));
                total += discountedPrice;
            }

            // Apply tax percentage on the discounted total
            total += total * (taxPercentage / 100);

            // Calculate Vatable Sales and VAT
            decimal vatableSales = total / 1.12m;
            decimal vat = vatableSales * 0.12m;

            // Display VAT breakdown
            Console.WriteLine($"Vatable Sales: ${vatableSales:F2}");
            Console.WriteLine($"VAT: ${vat:F2}");

            return total; // Total includes VAT
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(_products); // Return a copy to prevent external modification
        }

        public void ClearCart()
        {
            _products.Clear();
        }
    }

}

