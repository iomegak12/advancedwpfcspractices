using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Models
{
    public class Customer : BaseModel
    {
        private int _id;
        private string _name;
        private string _address;
        private int _credit;
        private bool _status;
        private string _photoUrl;

        public int CustomerId { get => _id; set { _id = value; Notify("CustomerId"); } }
        public string CustomerName { get => _name; set { _name = value; Notify("CustomerName"); } }
        public string Address { get => _address; set { _address = value; Notify("Address"); } }
        public int CreditLimit { get => _credit; set { _credit = value; Notify("CreditLimit"); } }
        public bool ActiveStatus { get => _status; set { _status = value; Notify("ActiveStatus"); } }
        public string PhotoUrl { get => _photoUrl; set { _photoUrl = value; Notify("PhotoUrl"); } }

        public override string ToString()
        {
            return string.Format(
                @"{0}, {1}, {2}, {3}, {4}, {5}",
                this.CustomerId, this.CustomerName, this.Address, this.CreditLimit, this.ActiveStatus, this.PhotoUrl);
        }
    }
}
