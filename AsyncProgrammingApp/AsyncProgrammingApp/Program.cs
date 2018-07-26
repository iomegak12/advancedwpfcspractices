using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgrammingApp
{
    class Program
    {
        private static async Task<string[]> ReadContents(string fileName)
        {
            var validation = !string.IsNullOrEmpty(fileName) &&
                File.Exists(fileName);

            if (!validation)
                throw new ArgumentException();

            var allContents = new List<string>();

            await Task.Run(() =>
            {
                using (var fileStream = File.OpenRead(fileName))
                using (var streamReader = new StreamReader(fileStream))
                {
                    streamReader.ReadLine();

                    while (true)
                    {
                        var currentLine = streamReader.ReadLine();

                        if (string.IsNullOrEmpty(currentLine))
                            break;

                        allContents.Add(currentLine);
                    }
                }
            });

            return allContents.ToArray();
        }

        public async static Task Display(string[] contents)
        {
            await Task.Run(() =>
            {
                foreach (var line in contents)
                {
                    var splittedLine = line.Split(',');

                    Console.WriteLine(@"{0}, {1}, {2}, {3}, {4}",
                        splittedLine[0],
                        splittedLine[1],
                        splittedLine[2],
                        splittedLine[3],
                        splittedLine[4]);
                }

                Thread.Sleep(2000);
            });
        }

        static void Main(string[] args)
        {
            StartTheWork();

            Console.WriteLine("End of App!");
            Console.ReadLine();
        }

        private static async void StartTheWork()
        {
            var fileName = @"C:\00 WPF\Demonstrations\Data\customers.csv";
            var contents = await ReadContents(fileName);

            await Display(contents);

            Console.WriteLine("Operation Completed ...");
        }
    }
}
