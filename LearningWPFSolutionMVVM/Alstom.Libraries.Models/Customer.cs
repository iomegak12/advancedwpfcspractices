using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Credit { get; set; }
        public bool Status { get; set; }
        public string PhotoUrl { get; set; }

        public override string ToString()
        {
            return string.Format(
                @"{0}, {1}, {2}, {3}, {4}, {5}",
                this.Id, this.Name, this.Address, this.Credit, this.Status, this.PhotoUrl);
        }
    }
}
