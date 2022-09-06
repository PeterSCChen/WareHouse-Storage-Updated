using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Common
{
    public class ClientCollection: BindingList<Client>
    {
        // calculate total YTD sales
        public decimal TotalYTDSales => this.Sum(x => x.YTDSales);
        // calculate total credit hold
        public int TotalCreditHold => this.Count(x => x.CreditHold == true);
    }
}
