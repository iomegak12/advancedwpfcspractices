using IntSol.Libraries.Entities.Customers;
using IntSol.Libraries.Entities.LoanRequests;
using IntSol.Libraries.Processing.External.Impl;
using IntSol.Libraries.Processing.External.Interfaces;
using IntSol.Libraries.Processing.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Applications.LRProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var loanRequest = new LoanRequest
                {
                    RequestId = 1,
                    RequestDate = DateTime.Now,
                    Amount = 600000,
                    CustomerDetails = new RegisteredCustomer
                    {
                        CustomerId = 1,
                        CustomerName = "Northwind Traders",
                        Address = "Bangalore",
                        RegistrationNumber = "REG12000"
                    },
                    AssetDetails = new AssetDetail
                    {
                        AssetAmount = 20000,
                        EvaluatedBy = "ABC Traders",
                        EvaluatedOn = DateTime.Now.AddDays(-2)
                    }
                };

                var externalLoanRequestProcessor = new ExternalLoanRequestProcessor();
                var loanRequestProcessor = new LoanRequestProcessor(externalLoanRequestProcessor);

                var status = loanRequestProcessor.Process(loanRequest);

                Console.WriteLine("Status : {0}", status);
            }
            catch (Exception exceptionObject)
            {
                Console.WriteLine("Error Occurred, Details : " + exceptionObject.Message);
            }

            Console.WriteLine("End of Application!");
            Console.ReadLine();
        }
    }
}
