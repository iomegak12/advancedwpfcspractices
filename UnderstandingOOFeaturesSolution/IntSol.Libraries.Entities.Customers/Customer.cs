using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Entities.Customers
{
    public abstract class Customer
    {
        private int customerId;
        private string customerName;
        private string address;

        #region Public Properties
        public int CustomerId
        {
            get { return this.customerId; }
            set { this.customerId = value; }
        }

        public string CustomerName
        {
            get { return this.customerName; }
            set { this.customerName = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        #endregion
        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                this.customerId, this.customerName, this.address);
        }
    }
}
