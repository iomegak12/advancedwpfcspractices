using IntSol.Libraries.Models;
using IntSol.Libraries.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Services.Impl
{
    public class CustomerService : ICustomerService, IDisposable
    {
        private const int HEADER_LINES = 1;
        private const char COL_DELIMITER = ',';
        private string fileName = default(string);
        private FileStream fileStream = default(FileStream);
        private StreamReader streamReader = default(StreamReader);

        public CustomerService(string fileName)
        {
            var validation = !string.IsNullOrEmpty(fileName) &&
                File.Exists(fileName);

            if (!validation)
                throw new ArgumentException();

            this.fileName = fileName;
            this.fileStream = File.OpenRead(this.fileName);
            this.streamReader = new StreamReader(this.fileStream);
        }

        public void Dispose()
        {
            if (this.streamReader != default(StreamReader))
                this.streamReader.Close();

            if (this.fileStream != default(FileStream))
                this.fileStream.Close();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customersList = default(List<Customer>);

            /* Skip Header Rows */
            for (var rowCount = 0; rowCount < HEADER_LINES; rowCount++)
                this.streamReader.ReadLine();

            customersList = new List<Customer>();

            while (true)
            {
                var currentLine = this.streamReader.ReadLine();

                if (string.IsNullOrEmpty(currentLine))
                    break;

                var splittedCurrentLine = currentLine.Split(COL_DELIMITER);

                var customer = new Customer
                {
                    CustomerId = int.Parse(splittedCurrentLine[0]),
                    CustomerName = splittedCurrentLine[1],
                    Address = splittedCurrentLine[2],
                    Credit = int.Parse(splittedCurrentLine[3]),
                    Status = bool.Parse(splittedCurrentLine[4]),
                    Remarks = splittedCurrentLine[5]
                };

                customersList.Add(customer);
            }

            return customersList;
        }
    }
}
