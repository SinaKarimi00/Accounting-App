using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repositories;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private Accounting_DBEntities db;

        public CustomerRepositories(Accounting_DBEntities context)
        {
            db = context; 
        }
        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = db.Customers.Find(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Customers GetCustomer(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public List<Customers> GetCustomers()
        {
            return db.Customers.ToList();
        }

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(c=>c.FullName.Contains(parameter) || c.Email.Contains(parameter) || c.Mobile.Contains(parameter)).ToList();
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
