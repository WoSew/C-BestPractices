using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();

            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            companyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            var actal = currentProduct.SayHello();


            //Assert
            Assert.AreEqual(expected, actal);
        }

        [TestMethod()]
        public void SayHello_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SayHello_ObjectInitializer()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ConvertMetersToInchesTest()
        {
            //Arrange
            var expected = 78.74;

            //Act
            var actual = 2 * Product.InchesPerMEter;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPriceTest_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPriceTest_Game()
        {
            //Arrange
            var currentProduct = new Product(1, "GameOfThrone", "cooming soon");
            var expected = 9.99m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductName_Format()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "    Steel Hammer  ";
            var expected = "Steel Hammer";

            //act
            var actual = currentProduct.ProductName;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductNameSet_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";

            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters.";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMassage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductNameSet_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "abcefghijklmnoprstuwxyz";

            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters.";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMassage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductNameSet_Good()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Whisky";

            string expected = "Whisky";
            string expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMassage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void Cetegory_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            var expected = "Tools";

            //act
            var actual = currentProduct.Category;

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Cetegory_NewValue()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";
            var expected = "Garden";

            //act
            var actual = currentProduct.Category;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sequence_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            var expected = 1;

            //act
            var actual = currentProduct.SequenceNumber;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sequence_NewValue()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 2;
            var expected = 2;

            //act
            var actual = currentProduct.SequenceNumber;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCode_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            var expected = "Tools-1";

            //act
            var actual = currentProduct.ProductCode;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "Description");
            currentProduct.Cost = 50m;
            var expected = 55m;

            //Act
            var actual = currentProduct.CalculateSuggestedPrice(10);

            //Assert
            Assert.AreEqual(expected,actual);

        }
    }
}