using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Entities.Customers
{
    public class UnregisteredCustomer : Customer
    {
        private string panNumber;
        private string aadhaarNumber;

        #region Public Properties

        public string PanNumber
        {
            get { return this.panNumber; }
            set { this.panNumber = value; }
        }

        public string AadhaarNumber
        {
            get { return this.aadhaarNumber; }
            set { this.aadhaarNumber = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                base.ToString(), this.panNumber, this.aadhaarNumber);
        }
    }
}

