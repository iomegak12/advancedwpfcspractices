using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalClassesInWPFForNotifications
{
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;

                Notify("Id");
            }
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; Notify("Name"); }
        }

        private string phone;

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; Notify("Phone"); }
        }

        private string address;

        public string Address
        {
            get { return this.address; }
            set { this.address = value; Notify("Address"); }
        }

        private string email;

        public string Email
        {
            get { return this.email; }
            set { this.email = value; Notify("Email"); }
        }

        private void Notify(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName) &&
                PropertyChanged != default(PropertyChangedEventHandler))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
