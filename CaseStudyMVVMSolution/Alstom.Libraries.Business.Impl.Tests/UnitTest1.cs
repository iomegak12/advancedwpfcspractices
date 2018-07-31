using System;
using System.Linq;
using Alstom.Libraries.DAL.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alstom.Libraries.Business.Impl.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var customersContext = new CustomersContext())
            using (var customerService = new CustomerService(customersContext))
            {
                var searchString = "wind";
                var expectedNoOfCustomers = 4;
                var actualNoOfCustomers = customerService.SearchCustomers(searchString).Count();

                Assert.AreEqual<int>(expectedNoOfCustomers, actualNoOfCustomers);
            }
        }
    }
}
