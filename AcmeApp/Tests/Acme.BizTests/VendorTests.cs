using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Common;
using System;


namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlaceOrderTest()
        {
            //arrange
            var vendor = new Vendor();
            var product = new Product(1, "Book", "LOTR");
            var expected = new OperationResult(true,"Order from Acme, Inc\r\nProduct: Book\r\nQuantity: 3");

            //act
            var actual = vendor.PlaceOrder(product, 3);

            //assert
            Assert.AreEqual(expected.Success,actual.Success);
            Assert.AreEqual(expected.Message,actual.Message);
        }

        [TestMethod]
        public void PlaceOrder_3Parameters()
        {
            //arrange
            var vendor = new Vendor();
            var product = new Product(1, "Book", "LOTR");
            var expected = new OperationResult(true, "Order from Acme, Inc\r\nProduct: Book\r\nQuantity: 3"+"\r\nDeliver By: 30.05.2018");

            //act
            var actual = vendor.PlaceOrder(product, 3, new DateTimeOffset(2018,5,30, 0,0,0,new TimeSpan(-7,0,0)));

            //assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            //arrange
            var vendor = new Vendor();

            //act
            var actual = vendor.PlaceOrder(null, 5);

            //assert
            //expected exception
        }
    }
}