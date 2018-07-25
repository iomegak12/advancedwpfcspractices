using IntSol.Libraries.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Entities.LoanRequests
{
    public class LoanRequest
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public Customer CustomerDetails { get; set; }
        public AssetDetail AssetDetails { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}, {3}, {4}",
                this.RequestId, this.RequestDate, this.CustomerDetails, this.AssetDetails, this.Amount);
        }
    }
}
