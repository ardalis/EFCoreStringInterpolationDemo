using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EFCoreTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var context = new AppDbContext())
            {
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new MyLoggerProvider());
                Console.WriteLine("All Customers:");
                var customers = context.Customers;
                PrintCustomers(customers);
                Console.WriteLine();

                Console.WriteLine("London Customers:");
                string city = "London";
                var londonCustomers = context.Customers.FromSql($"SELECT * FROM Customers WHERE City = {city}");
                PrintCustomers(londonCustomers);
            }
        }

        private static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.CompanyName} from {customer.City}");
            }
        }
    }
}
