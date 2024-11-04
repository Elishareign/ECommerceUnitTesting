using NUnit.Framework;

namespace ECommerceUnitTesting.Tests
{
    // Test cases for Integration Testing Class
    [TestFixture]
    public class IntegrationTesting
    {
        // Object instances
        private ShoppingCart _cart;
        private Product _product;

        //To initialize product instance before each test
        [SetUp]
        public void SetUp()
        {
            _cart = new ShoppingCart();
            _product = new Product("Smartphone", 10000.0m, "A mobile phone");
        }
        // Test the functionality of adding a product to cart
        [Test]
        public void TestAddProductToCart()
        {
            _cart.AddProduct(_product);
            var products = _cart.GetProducts();
            Assert.AreEqual(1, products.Count); // Product count is 1 to confirm product was added
            Assert.AreEqual("Smartphone", products[0].Name); // Verifies the correct product
        }
        // Test the functionality of calculating total price including discount and tax
        [Test]
        public void TestCalculateTotalPriceIncludingDiscountAndTax()
        {
            _cart.AddProduct(_product);
            decimal totalWithDiscountAndTax = _cart.CalculateTotalPrice(10, 12); // 10% discount, 12% tax
            Assert.AreEqual(10080.0m, totalWithDiscountAndTax); 
        }
        // Test the functionality of removing a product from a cart
        [Test]
        public void TestRemoveProductFromCart()
        {
            _cart.AddProduct(_product);
            _cart.RemoveProduct(_product);
            Assert.AreEqual(0, _cart.GetProducts().Count);
        }
    }
}
