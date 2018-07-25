using IntSol.Libraries.Entities.LoanRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Processing.Interfaces
{
    public interface ILoanRequestProcessor
    {
        bool Process(LoanRequest loanRequest);
    }
}
