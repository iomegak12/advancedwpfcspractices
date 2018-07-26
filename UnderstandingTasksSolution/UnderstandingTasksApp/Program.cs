﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnderstandingTasksApp
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
        static void Main1(string[] args)
        {
            var fileName = @"C:\00 WPF\Demonstrations\Data\customers.csv";

            using (var customersCsvReader = new CustomersCsvReader(fileName))
            {
                var task = Task.Factory.StartNew(() => customersCsvReader.ReadContents());

                Console.WriteLine("Continuing with other main operations ...");

                task.Wait();
            }

            Console.WriteLine("End of the Application!");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var step1 = Task.Factory.StartNew<int>(
                 () =>
                 {
                     Console.WriteLine("Doing the operation 1 ...");

                     Thread.Sleep(2000);

                     return 10;
                 });

            var step2 = step1.ContinueWith(previousTask =>
            {
                Console.WriteLine("Previous Task Result is ..." +
                    previousTask.Result.ToString());

                Console.WriteLine("Completing the Chain!");
            });

            step2.Wait();

            Console.WriteLine("End of App!");
            Console.ReadLine();
        }
    }
}
