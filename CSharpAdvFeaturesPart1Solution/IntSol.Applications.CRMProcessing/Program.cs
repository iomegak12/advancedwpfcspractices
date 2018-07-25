using IntSol.Libraries.Models.Extensibility;
using IntSol.Libraries.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IntSol.Applications.CRMProcessing
{
    class Program
    {
        const int PREMIUM_CREDIT = 49500;

        static void Main(string[] args)
        {
            try
            {
                var fileName = @"C:\00 WPF\Demonstrations\Data\customers.csv";

                using (var customerService = new CustomerService(fileName))
                {
                    var customersList = customerService.GetCustomers();

                    var premiumCustomers =
                        from customer in customersList
                        where customer.Credit >= PREMIUM_CREDIT
                        orderby customer.Credit descending
                        select new
                        {
                            Customer = customer,
                            LicenseKey = customer.GetLicenseKey()
                        };

                    ForegroundColor = ConsoleColor.Green;

                    foreach (var premiumCustomer in premiumCustomers)
                    {
                        WriteLine("{0} - {1}",
                            premiumCustomer.ToString(), premiumCustomer.LicenseKey);
                    }

                    ResetColor();
                }
            }
            catch (Exception exceptionObject)
            {
                WriteLine("Error Occurred, Details : " + exceptionObject.Message);
            }

            WriteLine("End of Application!");
            ReadLine();
        }
    }
}
