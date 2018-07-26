using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnderstandingThreadingApp
{
    public class CustomersCsvReader : IDisposable
    {
        private string fileName = default(string);
        private FileStream fileStream = default(FileStream);
        private StreamReader streamReader = default(StreamReader);

        public CustomersCsvReader(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName) &&
                File.Exists(fileName))
            {
                this.fileName = fileName;
                this.fileStream = File.OpenRead(this.fileName);
                this.streamReader = new StreamReader(this.fileStream);
            }
            else throw new ArgumentException();
        }

        public void Dispose()
        {
            if (this.streamReader != default(StreamReader))
                this.streamReader.Close();

            if (this.fileStream != default(FileStream))
                this.fileStream.Close();
        }

        public void ReadContents()
        {
            this.streamReader.ReadLine();

            var currentLineCount = 0;

            while (true)
            {
                var currentLine = this.streamReader.ReadLine();

                if (string.IsNullOrEmpty(currentLine))
                    break;

                var splittedCurrentLine = currentLine.Split(',');

                Console.WriteLine(@"{0}, {1}, {2}, {3}, {4}",
                    splittedCurrentLine[0], splittedCurrentLine[1],
                    splittedCurrentLine[2], splittedCurrentLine[3],
                    splittedCurrentLine[4]);

                currentLineCount++;

                if (currentLineCount % 5 == 0)
                    Thread.Sleep(500);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"C:\00 WPF\Demonstrations\Data\customers.csv";

            using (var customersCsvReader = new CustomersCsvReader(fileName))
            {
                var thread = new Thread(customersCsvReader.ReadContents);

                thread.IsBackground = false;
                thread.Start();

                Console.WriteLine("Thread spinned ...");
                Console.WriteLine("Continuing with other main operations ...");

                thread.Join();
            }

            Console.WriteLine("End of the Application!");
            Console.ReadLine();
        }
    }
}
