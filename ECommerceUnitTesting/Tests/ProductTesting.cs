    using NUnit.Framework;


    namespace ECommerceUnitTesting.Tests
    {
        /* This marks this class as a test fixture which means it contains various
        test cases to be executed by NUnit framework*/
        [TestFixture]
        public class ProductTesting
        {
            // Object instance of the Product Class 
            private Product _product;

            //To initialize product instance before each test
            [SetUp]
            public void SetUp()
            {    //Constructor having the name, 10000.0m as a price, description of the product.
                _product = new Product("Smartphone", 10000.0m, "A mobile phone");
            }
            // This test the verifies the name of the product "Smartphone"
            [Test]
            public void TestProductName()
            {
                Assert.AreEqual("Smartphone", _product.Name);
            }
            //This test checks the price of the product
            [Test]
            public void TestProductPrice()
            {
                Assert.AreEqual(10000.0m, _product.Price);
            }
            //This test validates the description of the product
            [Test]
            public void TestProductDescription()
            {
                Assert.AreEqual("A mobile phone", _product.Description);
            }
            //This test checks if the discounted calculation is correct
            [Test]
            public void TestCalculateDiscount()
            {
                var discountedPrice = _product.CalculateDiscount(10);
                Assert.AreEqual(9000.0m, discountedPrice);
            }
            //This test checks if the tax calculation is correct
            [Test]
            public void TestCalculateTax()
            {
                // Calculate discounted price (10% discount on 10000.0m)
                decimal discountedPrice = _product.CalculateDiscount(10); 

                // Calculate tax on the discounted price (12% tax on 9000.0m)
                decimal taxOnDiscountedPrice = discountedPrice * 0.12m; 

                Assert.AreEqual(1080.0m, taxOnDiscountedPrice, "Price should be 1080.0m after applying discount.");
            }

        }
    }
