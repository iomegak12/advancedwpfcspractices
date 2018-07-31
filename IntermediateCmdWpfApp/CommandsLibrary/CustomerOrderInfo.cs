using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLibrary
{
    public class CustomerOrderInfo
    {
        public Customer SelectedCustomer { get; set; }

        public Orders Orders { get; set; }
    }
}
