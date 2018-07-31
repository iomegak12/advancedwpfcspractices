using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary
{
    public class Customer : BaseModel
    {
        private int customerProfileId;

        public int CustomerProfileId
        {
            get { return this.customerProfileId; }
            set
            {
                this.customerProfileId = value;

                Notify("CustomerProfileId");
            }
        }

        private int creditLimit;

        public int CreditLimit
        {
            get { return this.creditLimit; }
            set
            {
                this.creditLimit = value;

                Notify("CreditLimit");
            }
        }
    }
}
