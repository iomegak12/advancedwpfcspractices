using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                this.OrderId, this.OrderDate.ToString(), this.Amount);
        }
    }
}
