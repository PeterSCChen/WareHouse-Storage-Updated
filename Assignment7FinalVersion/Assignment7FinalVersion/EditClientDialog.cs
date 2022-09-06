using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLib.Business;
using BusinessLib.Common;
using BusinessLib.Data;
using InvoiceLookupApi;

namespace Assignment7AB
{
    public partial class EditClientDialog : Form
    {
        List<Province> provinces = new List<Province>();
        public ClientViewModel ClientVM { get; set; }
        public EditClientDialog()
        {
            InitializeComponent();
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            setBindings();
            comboBoxProvince.Text = "";

            provinces = ProvinceRepository.GetAllProivnce();

            // loop to add all provinces
            foreach (Province place in provinces)
            {
                comboBoxProvince.DisplayMember = "Abbreviation";
                comboBoxProvince.Items.Add(place.Abbreviation);
            }

            List<Invoice> invoices = InvoiceLookupApiClient.GetInvoicesByClient(ClientVM.ClientCode);

            buttonShowInvoice.Enabled = false;

            for(int i = 0; i < invoices.Count; i++)
            {

                if (invoices[i].ClientCode.Contains(ClientVM.ClientCode))
                {
                    buttonShowInvoice.Enabled = true;
                }
                
            }
        }

        private void setBindings()
        {
            textBoxCompanyName.DataBindings.Add("Text", ClientVM, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress1.DataBindings.Add("Text", ClientVM, "Address1", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", ClientVM, "Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", ClientVM, "City", false, DataSourceUpdateMode.OnValidation, "");
            comboBoxProvince.DataBindings.Add("Text", ClientVM, "Province", false, DataSourceUpdateMode.OnValidation, "");
            maskedTextBoxPostalCode.DataBindings.Add("Text", ClientVM, "PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", ClientVM, "YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", ClientVM, "CreditHold");
            textBoxNotes.DataBindings.Add("Text", ClientVM, "Notes", false, DataSourceUpdateMode.OnValidation, "");
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = ClientVM.GetDisplayClient();
                int rowsAffected = Validation.UpdateClient(client);
                string errorMessages;

                errorProviderEditClientDialog.SetError(buttonOk, "");
                if (rowsAffected > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (rowsAffected == 0)
                    {
                        errorMessages = "No DB changes were made";
                    }
                    else
                    {
                        errorMessages = Validation.ErrorMessage;
                    }
                    errorProviderEditClientDialog.SetError(buttonOk, errorMessages);
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowInvoice_Click(object sender, EventArgs e)
        {
            using (ShowInvoiceDialog invoice = new ShowInvoiceDialog())
            {
                invoice.ClientVM = this.ClientVM;
                invoice.ShowDialog();
            }
        }
    }
}
