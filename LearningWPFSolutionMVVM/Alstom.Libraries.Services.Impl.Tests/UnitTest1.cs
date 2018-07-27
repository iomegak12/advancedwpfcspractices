using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alstom.Libraries.Services.Impl.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var customerService = new CustomerService();
            var searchString = "wind";
            var expectedNoOfCustomers = 4;
            var result = customerService.GetCustomers(searchString);
            var actualNoOfCustomers = result.Count();

            Assert.AreEqual<int>(expectedNoOfCustomers, actualNoOfCustomers);
        }
    }
}
