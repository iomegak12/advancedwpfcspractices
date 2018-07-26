using IntSol.Libraries.Models.Extensibility;
using IntSol.Libraries.Services.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IntSol.Applications.CRMProcessing
{
    class Program
    {
        // 6.5 Seconds
        static void Main(string[] args)
        {
            try
            {
                var directory = @"C:\00 WPF\Demonstrations\Data";
                var csvFiles = Directory.GetFiles(directory, "*.csv");
                var timer = Stopwatch.StartNew();

                var parallelResult = Parallel.ForEach<string>(
                    csvFiles,
                    currentFile =>
                    {
                        using (var customerService = new CustomerService(currentFile))
                        {
                            var customers = customerService.GetCustomers();
                            var premiumCustomers =
                                from customer in customers
                                where customer.Credit >= 49500
                                select customer;

                            Console.WriteLine(@"Totally # {0} Premium Customer(s) Found!", premiumCustomers.Count());
                        }
                    });

                timer.Stop();

                Console.WriteLine(@"Totally # {0} ms elapsed to complete reading all files ...",
                    timer.ElapsedMilliseconds);
            }
            catch (Exception exceptionObject)
            {
                WriteLine("Error Occurred, Details : " + exceptionObject.Message);
            }

            WriteLine("End of Application!");
            ReadLine();
        }

        // 11 Second(s)
        static void Main2(string[] args)
        {
            try
            {
                var directory = @"C:\00 WPF\Demonstrations\Data";
                var csvFiles = Directory.GetFiles(directory, "*.csv");
                var timer = Stopwatch.StartNew();

                foreach (var file in csvFiles)
                {
                    using (var customerService = new CustomerService(file))
                    {
                        var customers = customerService.GetCustomers();
                        var premiumCustomers =
                            from customer in customers
                            where customer.Credit >= 49500
                            select customer;

                        Console.WriteLine(@"Totally # {0} Premium Customer(s) Found!", premiumCustomers.Count());
                    }
                }

                timer.Stop();

                Console.WriteLine(@"Totally # {0} ms elapsed to complete reading all files ...",
                    timer.ElapsedMilliseconds);
            }
            catch (Exception exceptionObject)
            {
                WriteLine("Error Occurred, Details : " + exceptionObject.Message);
            }

            WriteLine("End of Application!");
            ReadLine();
        }
    }
}
