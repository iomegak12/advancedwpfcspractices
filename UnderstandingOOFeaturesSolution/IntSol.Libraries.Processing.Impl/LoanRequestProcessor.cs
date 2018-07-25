using IntSol.Libraries.Entities.Customers;
using IntSol.Libraries.Entities.LoanRequests;
using IntSol.Libraries.Processing.External.Interfaces;
using IntSol.Libraries.Processing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Processing.Impl
{
    public class LoanRequestProcessor : ILoanRequestProcessor
    {
        private const int MAX_PROCESSING_AMOUNT = 500000;
        private IExternalLoanRequestProcessor externalLoanRequestProcessor = default(IExternalLoanRequestProcessor);

        public LoanRequestProcessor(IExternalLoanRequestProcessor externalLoanRequestProcessor)
        {
            var validation = externalLoanRequestProcessor != default(IExternalLoanRequestProcessor);

            if (!validation)
                throw new ArgumentException();

            this.externalLoanRequestProcessor = externalLoanRequestProcessor;
        }

        public bool Process(LoanRequest loanRequest)
        {
            var processingStatus = default(bool);

            var validation = loanRequest != default(LoanRequest) &&
                loanRequest.CustomerDetails != default(Customer) &&
                loanRequest.AssetDetails != default(AssetDetail) &&
                loanRequest.Amount <= MAX_PROCESSING_AMOUNT;

            if (validation)
            {
                processingStatus = true;

                Console.WriteLine("Loan Request Processed Internally ...");
            }
            else
            {
                Console.WriteLine("Unable to process loan request internally ...");
                Console.WriteLine("Sending the Loan Request to External and Partner Banks ...");

                processingStatus = this.externalLoanRequestProcessor.ProcessExternal(loanRequest);

                Console.WriteLine("External Loan Request Processing Completed ...");
            }

            return processingStatus;
        }
    }
}
