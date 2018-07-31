using System;
using System.Diagnostics;
using System.Linq;
using Alstom.Libraries.DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alstom.Libraries.DAL.Impl.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                using (var context = new CustomersContext())
                {
                    var expectedTotalNumberOfCustomers = 8;
                    var actualNoOfCustomers = context.Customers.Count();

                    Assert.AreEqual<int>(expectedTotalNumberOfCustomers, actualNoOfCustomers);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
    }
}
