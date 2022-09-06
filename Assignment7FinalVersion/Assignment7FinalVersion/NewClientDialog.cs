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

namespace Assignment7AB
{
    public partial class NewClientDialog : Form
    {
        List<Province> provinces = new List<Province>();
        public ClientViewModel clientVM { get; set; }

        public NewClientDialog()
        {
            InitializeComponent();
        }

        private void NewClientDialog_Load(object sender, EventArgs e)
        {
            maskedTextBoxClientCode.Select();
            maskedTextBoxClientCode.SelectAll();
            setBindings();
            comboBoxProvince.Text = "";

            provinces = ProvinceRepository.GetAllProivnce();

            // loop to add all provinces
            foreach (Province place in provinces)
            {
                comboBoxProvince.DisplayMember = "Abbreviation";
                comboBoxProvince.Items.Add(place.Abbreviation);
            }
        }

        private void setBindings()
        {
            maskedTextBoxClientCode.DataBindings.Add("Text", clientVM, "ClientCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCompanyName.DataBindings.Add("Text", clientVM, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress1.DataBindings.Add("Text", clientVM, "Address1", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", clientVM, "Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", clientVM, "City", false, DataSourceUpdateMode.OnValidation, "");
            comboBoxProvince.DataBindings.Add("Text", clientVM, "Province", false, DataSourceUpdateMode.OnValidation, "");
            maskedTextBoxPostalCode.DataBindings.Add("Text", clientVM, "PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", clientVM, "YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", clientVM, "CreditHold");
            textBoxNotes.DataBindings.Add("Text", clientVM, "Notes", false, DataSourceUpdateMode.OnValidation, "");

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = clientVM.GetDisplayClient();
                int rowsAffected;
                bool duplicate = false;
                string errorMessages;
                errorProviderNewClientDialog.SetError(buttonAccept, "");

                // Loop to see if this client code was used before
                for (int i = 0; i < Validation.GetClients().Count; i++)
                {
                    if (client.ClientCode == $"{Validation.GetClients()[i].ClientCode}")
                    {
                        duplicate = true;
                        i = Validation.GetClients().Count;
                    }
                }
                if (duplicate)
                {
                    rowsAffected = Validation.UpdateClient(client);
                }
                else
                {
                    rowsAffected = Validation.AddClient(client);
                }

                // check if any rows changed
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
                    errorProviderNewClientDialog.SetError(buttonAccept, errorMessages);
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
    }
}
