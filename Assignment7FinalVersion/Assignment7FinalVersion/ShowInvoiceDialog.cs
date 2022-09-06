using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLib.Business;
using BusinessLib.Common;
using InvoiceLookupApi;

namespace Assignment7AB
    // font consolas
{
    public partial class ShowInvoiceDialog : Form
    {
        public ClientViewModel ClientVM { get; set; }
        public ShowInvoiceDialog()
        {
            InitializeComponent();
        }

        private void ShowInvoiceDialog_Load(object sender, EventArgs e)
        {
            
            List<Invoice> invoices = InvoiceLookupApiClient.GetInvoicesByClient(ClientVM.ClientCode); //Get the list of invoices based on the client code

            richTextBoxInvoice.Text = InvoicePrinter.PrintInvoices(invoices); //Get the invoices as a string based on the code used in Assignment03.
        }


    }
}
