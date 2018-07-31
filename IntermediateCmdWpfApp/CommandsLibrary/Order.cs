using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLibrary
{
    public class Order : BaseModel
    {
        private int _orderId;
        private DateTime _orderDate;
        private int _amount;

        public int OrderId { get => _orderId; set { _orderId = value; Notify("OrderId"); } }
        public DateTime OrderDate { get => _orderDate; set { _orderDate = value; Notify("OrderDate"); } }
        public int Amount { get => _amount; set { _amount = value; Notify("Amount"); } }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                this.OrderId, this.OrderDate.ToString(), this.Amount);
        }
    }
}
