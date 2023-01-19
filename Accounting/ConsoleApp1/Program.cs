using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using Accounting.DataLayer.Context;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork db = new UnitOfWork();
            var selectedCustomer = db.IcustomerRep.GetCustomers();
            foreach (var item in selectedCustomer)
            {
                Console.WriteLine(item.FullName);
            }

            Console.ReadKey();
        }
    }
}
