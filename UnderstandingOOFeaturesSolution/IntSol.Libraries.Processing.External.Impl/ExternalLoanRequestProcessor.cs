using IntSol.Libraries.Entities.Customers;
using IntSol.Libraries.Entities.LoanRequests;
using IntSol.Libraries.Processing.External.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Processing.External.Impl
{
    public class ExternalLoanRequestProcessor : IExternalLoanRequestProcessor
    {
        private const int MIN_AMOUNT = 1;
        private const int MAX_AMOUNT = 1000000;

        public bool ProcessExternal(LoanRequest loanRequest)
        {
            var status = default(bool);

            var validation = loanRequest != default(LoanRequest) &&
                loanRequest.Amount >= MIN_AMOUNT &&
                loanRequest.Amount <= MAX_AMOUNT &&
                loanRequest.CustomerDetails != default(Customer) &&
                loanRequest.AssetDetails != default(AssetDetail);

            status = validation;

            Console.WriteLine("External Submission Completed ...");

            return status;
        }
    }
}
