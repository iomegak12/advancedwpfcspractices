using System;

namespace IntSol.Libraries.Entities.LoanRequests
{
    public class AssetDetail
    {
        public int AssetAmount { get; set; }
        public string EvaluatedBy { get; set; }
        public DateTime EvaluatedOn { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                this.AssetAmount, this.EvaluatedBy, this.EvaluatedOn);
        }
    }
}