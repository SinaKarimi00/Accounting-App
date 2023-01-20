using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer.Context;

namespace Accounting.App
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void ftmCustomers_Load(object sender, EventArgs e)
        {
            BidGrid();
        }

        void BidGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.AutoGenerateColumns = false;
                dgCustomers.DataSource = db.IcustomerRep.GetCustomers();
            }     
        }

        private void bnRefreshCustomer_Click(object sender, EventArgs e)
        {
            BidGrid();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using(UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.DataSource = db.IcustomerRep.GetCustomersByFilter(txtFilter.Text);
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            using(UnitOfWork db = new UnitOfWork())
            {
                
            }
        }
    }
}
