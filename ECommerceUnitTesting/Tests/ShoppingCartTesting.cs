using NUnit.Framework;

namespace ECommerceUnitTesting.Tests
{   
    // Test cases for ShoppingCart Class
    [TestFixture]
    public class ShoppingCartTesting
    {   // Object instances of ShoppingCart and Product
        private ShoppingCart _cart;
        private Product _product;

        [SetUp]
        public void SetUp()
        {   //Contructor
            _cart = new ShoppingCart();
            _product = new Product("Smartphone", 10000.0m, "A mmobile phone");
        }
        // This test the adding product in shopping cart functionality
        [Test]
        public void TestAddProduct()
        {
            _cart.AddProduct(_product);
            Assert.AreEqual(1, _cart.GetProducts().Count, "The product count should be 1 after adding a product.");
            // Product count should be 1 after adding a product
        }
        // This test the removing product in shopping cart functionality
        [Test]
        public void TestRemoveProduct()
        {
            _cart.AddProduct(_product);
            _cart.RemoveProduct(_product);
            Assert.AreEqual(0, _cart.GetProducts().Count, "The product count should be 0 after removing the product.");
            // Product count should be 0 after removing a product
        }
        // This test evaluates the calculation of the total price when discounts and taxes are applied
        [Test]
        public void TestCalculateTotalPriceWithDiscountAndTax()
        {
            _cart.AddProduct(_product);
            var total = _cart.CalculateTotalPrice(10, 12); // 10% discount and 12% tax
            Assert.AreEqual(10080.0m, total, "The total price should be 10080.0 after applying a 10% discount and 12% tax.");
        }
    }
}
