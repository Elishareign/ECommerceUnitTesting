using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceUnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  

            Console.WriteLine("Welcome to the Gadgets E-Commerce!");

            // Initialize product catalog 
            List<Product> productCatalog = new List<Product>
            {
                new Product("Laptop", 55999.50m, "High performance laptop"),
                new Product("Smartphone", 27999.00m, "Latest smartphone model"),
                new Product("Headphones", 11199.00m, "Noise-cancelling headphones")
            };

            ShoppingCart cart = new ShoppingCart();

            // Menu
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewProducts(productCatalog);
                        break;
                    case "2":
                        AddProductToCart(productCatalog, cart);
                        break;
                    case "3":
                        ViewCart(cart);
                        break;
                    case "4":
                        Checkout(cart);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        // Display product catalog
        static void ViewProducts(List<Product> products)
        {
            Console.WriteLine("\nProduct Catalog:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name}: ₱{product.Price} - {product.Description}");
            }
        }
        // Add product
        static void AddProductToCart(List<Product> products, ShoppingCart cart)
        {
            bool addingProducts = true;

            while (addingProducts)
            {
                Console.WriteLine("\nAvailable Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Name}: ₱{product.Price} - {product.Description}");
                }

                Console.WriteLine("\nEnter the name of the product you want to add to your cart:");
                string productName = Console.ReadLine();

                Product productToAdd = products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

                if (productToAdd != null)
                {
                    cart.AddProduct(productToAdd);
                    Console.WriteLine($"{productToAdd.Name} has been added to your cart.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }

                Console.WriteLine("\nWould you like to add another product? (yes/no)");
                string response = Console.ReadLine();
                addingProducts = response.Equals("yes", StringComparison.OrdinalIgnoreCase);
            }

            Console.WriteLine("Returning to main menu.");
        }
        // View Cart
        static void ViewCart(ShoppingCart cart)
        {
            var products = cart.GetProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("\nShopping Cart:");
            decimal total = 0;

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name}: ₱{product.Price}");
                total += product.Price;
            }

            Console.WriteLine($"Total: ₱{total}");
        }
        // Checkout product
        static void Checkout(ShoppingCart cart)
        {
            var products = cart.GetProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Add products to your cart before checking out.");
                return;
            }

            Console.WriteLine("Proceeding to checkout...");
            Console.WriteLine("Enter discount percentage (0 if none):");
            if (decimal.TryParse(Console.ReadLine(), out decimal discountPercentage))
            {
                Console.WriteLine("Enter tax percentage (0 if none):");
                if (decimal.TryParse(Console.ReadLine(), out decimal taxPercentage))
                {
                    Console.WriteLine($"Total amount due: ₱{cart.CalculateTotalPrice(discountPercentage, taxPercentage)}");
                    Console.WriteLine("Thank you for your purchase!");
                }
                else
                {
                    Console.WriteLine("Invalid input for tax percentage.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for discount percentage.");
            }

            cart.ClearCart();
        }
    }
}
