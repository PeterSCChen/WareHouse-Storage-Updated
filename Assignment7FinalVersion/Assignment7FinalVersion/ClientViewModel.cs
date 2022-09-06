using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using InvoiceLookupApi;
using BusinessLib.Business;
using BusinessLib.Common;

namespace Assignment7AB
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private string clientCode;
        private string companyName;
        private string address1;
        private string address2;
        private string city;
        private string province;
        private string postalCode;
        private decimal YTDsales;
        private bool creditHold;
        private string notes;

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ClientViewModel()
        {

        }

        public ClientViewModel(ClientCollection clients)
        {
            this.Clients = clients;
        }

        public ClientCollection Clients { get; set; }

        public string ClientCode
        {
            get { return clientCode; }
            set { clientCode = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                OnPropertyChanged();
            }
        }

        public string Address1
        {
            get { return address1; }
            set
            {
                address1 = value;
                OnPropertyChanged();
            }
        }

        public string Address2
        {
            get { return address2; }
            set
            {
                address2 = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        public string Province
        {
            get { return province; }
            set
            {
                province = value;
                OnPropertyChanged();
            }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged();
            }
        }
        public decimal YTDSales
        {
            get { return YTDsales; }
            set
            {
                YTDsales = value;
                OnPropertyChanged();
            }
        }
        public bool CreditHold
        {
            get { return creditHold; }
            set
            {
                creditHold = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }

        public Client GetDisplayClient()
        {
            Client customer = new Client();
            customer.ClientCode = this.clientCode;
            customer.CompanyName = this.CompanyName;
            customer.Address1 = this.Address1;
            customer.Address2 = this.Address2;
            customer.City = this.City;
            customer.Province = this.Province;
            customer.PostalCode = this.PostalCode;
            customer.YTDSales = this.YTDSales;
            customer.CreditHold = this.CreditHold;
            customer.Notes = this.Notes;

            return customer;
        }

        public void SetDisplayClient(Client client)
        {
            this.clientCode = client.ClientCode;
            this.CompanyName = client.CompanyName;
            this.Address1 = client.Address1;
            this.Address2 = client.Address2;
            this.City = client.City;
            this.Province = client.Province;
            this.PostalCode = client.PostalCode;
            this.YTDSales = client.YTDSales;
            this.CreditHold = client.CreditHold;
            this.Notes = client.Notes;
        }
    }
}
