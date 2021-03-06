﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Models
{
    public class Customer
    {
        #region Public Properties
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int Credit { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; } 
        #endregion

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}, {3}, {4}, {5}",
                this.CustomerId, this.CustomerName, this.Address,
                this.Credit, this.Status, this.Remarks);
        }
    }
}
