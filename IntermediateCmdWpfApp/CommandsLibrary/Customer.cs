using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLibrary
{
    public class Customer : BaseModel
    {
        private int _id;
        private string _name;
        private string _address;
        private int _credit;
        private bool _status;
        private string _photoUrl;

        public int Id { get => _id; set { _id = value; Notify("Id"); } }
        public string Name { get => _name; set { _name = value; Notify("Name"); } }
        public string Address { get => _address; set { _address = value; Notify("Address"); } }
        public int Credit { get => _credit; set { _credit = value; Notify("Credit"); } }
        public bool Status { get => _status; set { _status = value; Notify("Status"); } }
        public string PhotoUrl { get => _photoUrl; set { _photoUrl = value; Notify("PhotoUrl"); } }

        public override string ToString()
        {
            return string.Format(
                @"{0}, {1}, {2}, {3}, {4}, {5}",
                this.Id, this.Name, this.Address, this.Credit, this.Status, this.PhotoUrl);
        }
    }
}
