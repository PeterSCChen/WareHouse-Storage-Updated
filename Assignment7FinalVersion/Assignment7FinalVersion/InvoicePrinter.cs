using InvoiceLookupApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7AB
{
    class InvoicePrinter
    {
        public static string PrintInvoices(List<Invoice> invoice)
        {
            // Continue to print until the invoice in list is all printed
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("Invoice Listing");
            sb.AppendLine(new string('-', 75));


            for (int i = 0; i < invoice.Count; i++)
            {
                sb.AppendFormat("{0,-17} {1}", "Invoice Number:", invoice[i].InvoiceNumber);
                sb.AppendFormat("\n");
                sb.AppendFormat("{0,-17} {1}", "Invoice Date:", String.Format("{0:MMM d, yyyy}", invoice[i].InvoiceDate));
                sb.AppendFormat("\n");

                // Check if termdigit discount is available
                if (invoice[i].DiscountPercentage != 0)
                {
                    int discountDays = invoice[i].DiscountPeriod;
                    DateTimeOffset discountDate = invoice[i].InvoiceDate.AddDays(discountDays);
                    sb.AppendFormat("{0,-17} {1}", "Discount Date:", String.Format("{0:MMM d, yyyy}", discountDate));
                    sb.AppendFormat("\n");
                    sb.AppendFormat("{0,-17} {1:n2}% {2} days ADI", "Terms:", invoice[i].DiscountPercentage, invoice[i].DiscountPeriod);
                    sb.AppendFormat("\n");
                }

                // divider
                sb.AppendFormat(new string('-', 75));
                sb.AppendFormat("\n");
                sb.AppendFormat("{0, -3} {1, -13} {2, -23} {3, 10:n} {4,4} {5, 11}", "Qty", "SKU", "Description", "Price", "PST", "Ext");
                sb.AppendFormat("\n");
                sb.AppendFormat(new string('-', 75));
                sb.AppendFormat("\n");

                // takes the current loop through InvoiceDetailLines
                for (int j = 0; j < invoice[i].InvoiceDetailLines.Count; j++)
                {
                    char notTaxable = 'N';
                    char isTaxable = 'Y';
                    if (string.Equals(invoice[i].InvoiceDetailLines[j].Taxable, "False") == true)
                    {
                        sb.AppendFormat("{0, 3} {1, -9}     {2, -23} {3, 9:n} {4, 4} {5, 12:n}", invoice[i].InvoiceDetailLines[j].Quantity,
                                                                                                   invoice[i].InvoiceDetailLines[j].Sku,
                                                                                                   invoice[i].InvoiceDetailLines[j].Description,
                                                                                                   invoice[i].InvoiceDetailLines[j].Price,
                                                                                                   isTaxable,
                                                                                                   invoice[i].InvoiceDetailLines[j].ExtendedPrice);
                        sb.AppendFormat("\n");
                    }
                    else
                    {
                        sb.AppendFormat("{0, 3} {1, -9}     {2, -23} {3, 9:n} {4, 4} {5, 12:n}", invoice[i].InvoiceDetailLines[j].Quantity,
                                                                                                   invoice[i].InvoiceDetailLines[j].Sku,
                                                                                                   invoice[i].InvoiceDetailLines[j].Description,
                                                                                                   invoice[i].InvoiceDetailLines[j].Price,
                                                                                                   notTaxable,
                                                                                                   invoice[i].InvoiceDetailLines[j].ExtendedPrice);
                        sb.AppendFormat("\n");
                    }
                }

                // cost of items in total and taxes
                sb.AppendLine(new string('-', 75));
                sb.AppendFormat("{0, 17} {1} {2, 41:n}", "", "Subtotal:", invoice[i].Subtotal);
                sb.AppendFormat("\n");
                sb.AppendFormat("{0, 17} {1} {2, 46:n}", "", "GST:", invoice[i].GstTotal);
                sb.AppendFormat("\n");

                // total price and how much was discounted
                sb.AppendLine(new string('-', 75));
                sb.AppendFormat("{0, 17} {1} {2, 44:n}\n", "", "Total:", invoice[i].Total);
                sb.AppendFormat("{0, 17} {1} {2, 41:n}\n\n\n", "", "Discount:", invoice[i].Discount);
                sb.AppendFormat("\n");


            }
            return sb.ToString();
        }
    }
}
