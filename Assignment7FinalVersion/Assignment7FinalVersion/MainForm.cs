using BusinessLib.Common;
using BusinessLib.Business;
using BusinessLib.Data;
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

namespace Assignment7AB
{
    public partial class MainForm : Form
    {
        private ClientViewModel clientVM;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                labelTotalYTDSalesResult.Text = string.Empty;
                labelCreditHoldCountResult.Text = string.Empty;
                clientVM = new ClientViewModel(Validation.GetClients());

                dataGridViewClients.AutoGenerateColumns = false;
                dataGridViewClients.DataSource = clientVM.Clients;
                labelYTDDifference.Text = "";

                updateCalculatedProperties();
                setupDataGridView();
                updateAmountOfClient();
                updateYTDAverageDifference();
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
        // display total ytd sales and total credit hold
        private void updateCalculatedProperties()
        {
            labelTotalYTDSalesResult.Text = $"${clientVM.Clients.TotalYTDSales:N2}";
            labelCreditHoldCountResult.Text = $"{clientVM.Clients.TotalCreditHold}";
        }

        // display total client number
        private void updateAmountOfClient()
        {
            labelRecordCountResult.Text = $"{clientVM.Clients.Count}";
        }

        // display difference between the current selected vs average YTD sales
        private void updateYTDAverageDifference()
        {
            int index = dataGridViewClients.CurrentRow.Index;
            decimal clientYTDAvgDiff = clientVM.Clients.TotalYTDSales / clientVM.Clients.Count;
            decimal currentClientVSAvgDiff = clientVM.Clients[index].YTDSales - clientYTDAvgDiff;

            if (currentClientVSAvgDiff < 0)
            {
                labelYTDDifference.Text = $"{currentClientVSAvgDiff:N2}";
                labelYTDDifference.ForeColor = Color.Red;
            }
            else
            {
                labelYTDDifference.Text = $"{currentClientVSAvgDiff:N2}";
                labelYTDDifference.ForeColor = Color.Black;
            }
        }

        private void setupDataGridView()
        {
            // configure for readonly 
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewClients.AllowUserToOrderColumns = true;
            dataGridViewClients.AllowUserToResizeColumns = false;
            dataGridViewClients.AllowUserToResizeRows = false;
            dataGridViewClients.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            DataGridViewTextBoxColumn clientCode = new DataGridViewTextBoxColumn();
            clientCode.Name = "clientCode";
            clientCode.DataPropertyName = "ClientCode";
            clientCode.HeaderText = "Client Code";
            clientCode.Width = 70;
            clientCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clientCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clientCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(clientCode);

            DataGridViewTextBoxColumn companyName = new DataGridViewTextBoxColumn();
            companyName.Name = "companyName";
            companyName.DataPropertyName = "CompanyName";
            companyName.HeaderText = "Company Name";
            companyName.Width = 160;
            companyName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            companyName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            companyName.DefaultCellStyle.Format = "N0";
            companyName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(companyName);

            DataGridViewTextBoxColumn address1 = new DataGridViewTextBoxColumn();
            address1.Name = "address1";
            address1.DataPropertyName = "Address1";
            address1.HeaderText = "Address1";
            address1.Width = 160;
            address1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            address1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            address1.DefaultCellStyle.Format = "N0";
            address1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(address1);

            DataGridViewTextBoxColumn address2 = new DataGridViewTextBoxColumn();
            address2.Name = "address2";
            address2.DataPropertyName = "Address2";
            address2.HeaderText = "Address2";
            address2.Width = 60;
            address2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            address2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            address2.DefaultCellStyle.Format = "N0";
            address2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(address2);

            DataGridViewTextBoxColumn city = new DataGridViewTextBoxColumn();
            city.Name = "city";
            city.DataPropertyName = "City";
            city.HeaderText = "City";
            city.Width = 70;
            city.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            city.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(city);

            DataGridViewTextBoxColumn province = new DataGridViewTextBoxColumn();
            province.Name = "province";
            province.DataPropertyName = "Province";
            province.HeaderText = "Prov";
            province.Width = 40;
            province.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            province.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            province.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(province);

            DataGridViewTextBoxColumn postalCode = new DataGridViewTextBoxColumn();
            postalCode.Name = "postalCode";
            postalCode.DataPropertyName = "PostalCode";
            postalCode.HeaderText = "Postal Code";
            postalCode.Width = 60;
            postalCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            postalCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            postalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(postalCode);

            DataGridViewTextBoxColumn YTDsales = new DataGridViewTextBoxColumn();
            YTDsales.Name = "YTDsales";
            YTDsales.DataPropertyName = "YTDSales";
            YTDsales.HeaderText = "YTD Sales";
            YTDsales.Width = 70;
            YTDsales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            YTDsales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            YTDsales.DefaultCellStyle.Format = "N2";
            YTDsales.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(YTDsales);

            DataGridViewCheckBoxColumn creditHold = new DataGridViewCheckBoxColumn();
            creditHold.Name = "creditHold";
            creditHold.DataPropertyName = "CreditHold";
            creditHold.HeaderText = "Credit Hold?";
            creditHold.Width = 50;
            creditHold.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            creditHold.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            creditHold.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(creditHold);

            DataGridViewTextBoxColumn notes = new DataGridViewTextBoxColumn();
            notes.Name = "notes";
            notes.DataPropertyName = "Notes";
            notes.HeaderText = "Notes";
            notes.Width = 100;
            notes.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            notes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            notes.DefaultCellStyle.Format = "N0";
            notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(notes);

        }

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            int index = dataGridViewClients.CurrentRow.Index;
            clientVM.SetDisplayClient(clientVM.Clients[index]);

            EditClientDialog newDialog = new EditClientDialog();
            newDialog.ClientVM = clientVM;

            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                clientVM.Clients = Validation.GetClients();
                dataGridViewClients.DataSource = clientVM.Clients;

                updateCalculatedProperties();
                setupDataGridView();
                updateAmountOfClient();
                updateYTDAverageDifference();
            }
            newDialog.Dispose();
        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            clientVM.SetDisplayClient(new Client());

            NewClientDialog newDialog = new NewClientDialog();
            newDialog.clientVM = clientVM;

            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                clientVM.Clients = Validation.GetClients();
                dataGridViewClients.DataSource = clientVM.Clients;

                updateCalculatedProperties();
                setupDataGridView();
                updateAmountOfClient();
                updateYTDAverageDifference();
            }
            newDialog.Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (checkBoxConfirmDeletion.Checked)
            {
                if (MessageBox.Show("Are you sure you want to delete this client?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteRecord();
                }
                else
                {
                    deleteRecord();
                }
            }
        }

        private void deleteRecord()
        {
            int index = dataGridViewClients.CurrentRow.Index;
            clientVM.SetDisplayClient(clientVM.Clients[index]);

            try
            {
                Client client = clientVM.GetDisplayClient();
                Validation.DeleteClient(client);
                clientVM.Clients = Validation.GetClients();
                dataGridViewClients.DataSource = clientVM.Clients;

                updateCalculatedProperties();
                setupDataGridView();
                updateAmountOfClient();
                updateYTDAverageDifference();
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

        // Response to cellclick, updates the ytd value compare to average ytd value
        private void dataGridViewClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewClients.CurrentRow.Index;
            clientVM.SetDisplayClient(clientVM.Clients[index]);
            Client client = clientVM.Clients[index];
            clientVM.SetDisplayClient(client);
            updateYTDAverageDifference();
        }
    }
}
