using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork:IDisposable
    {
        private ICustomerRepositories _iCustomerRepositories;
        Accounting_DBEntities db = new Accounting_DBEntities();
        public ICustomerRepositories IcustomerRep
        { get 
            {
                if (_iCustomerRepositories == null)
                {
                    _iCustomerRepositories = new CustomerRepositories(db);
                }

                return _iCustomerRepositories;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
