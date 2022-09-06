using BusinessLib.Common;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BusinessLib.Business
{
    public class Validation
    {
        private static List<string> errors = new List<string>();


        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string line in errors)
                {
                    message += line + "\r\n";
                }

                return message;
            }
        }
        public static ClientCollection GetClients() => ClientRepository.GetClients;

        public static int AddClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.AddClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int UpdateClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.UpdateClient(client);
            }
            else
            {
                return -1;
            }
        }
        public static int DeleteClient(Client client) => ClientRepository.DeleteClient(client);

        private static bool validate(Client client)
        {
            bool success = true;
            errors.Clear();

            if(String.IsNullOrWhiteSpace(client.ClientCode))
            {
                errors.Add("Client Code cannot be blank");
            }
            else
            {
                string regExClientCode = @"^[A-Z]{5}$";
                if (!Regex.IsMatch(client.ClientCode, regExClientCode))
                {
                    errors.Add("Client Code must have a pattern of AAAAA (All positions required)");
                }
            }

            if (string.IsNullOrEmpty(client.CompanyName))
            {
                errors.Add("CompanyName cannot be Empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Address1))
            {
                errors.Add("Address1 cannot be Empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Province))
            {
                errors.Add("Province cannot be Empty");
                success = false;
            }

            if (String.IsNullOrWhiteSpace(client.PostalCode))
            {
                errors.Add("Postal Code cannot be blank");
            }
            else
            {
                string regExClientCode = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";
                if (!Regex.IsMatch(client.PostalCode, regExClientCode))
                {
                    errors.Add("Postal Code must have a pattern of A9A 9A9 (All positions required)");
                }
            }

            if (client.YTDSales < 0)
            {
                errors.Add("YTDSales cannot be negative");
                success = false;
            }

            return success;
        }

    }
}
