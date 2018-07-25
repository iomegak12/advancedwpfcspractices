using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Entities.Customers
{
    public class RegisteredCustomer : Customer
    {
        private string registrationNumber;

        #region Public Properties
        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set { this.registrationNumber = value; }
        } 
        #endregion

        public override string ToString()
        {
            return string.Format(@"{0}, {1}", base.ToString(), this.registrationNumber);
        }
    }
}
