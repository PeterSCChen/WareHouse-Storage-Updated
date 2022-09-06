using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Common;

namespace BusinessLib.Data
{
    public class ProvinceRepository
    {
        private static string connString = @"Server=tcp:comp2614.database.windows.net,1433; 
                                             Initial Catalog=comp2614;
                                             User ID=student; 
                                             Password=iLOVEpho!; 
                                             Encrypt=True; 
                                             TrustServerCertificate=False; 
                                             Connection Timeout=30;";

        public static ProvinceCollection GetAllProivnce()
        {
            ProvinceCollection provinces;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // embedded SQL
                string query;

                query = @"SELECT ProvinceId, Sort, Abbreviation, Name
                          FROM Province";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    provinces = new ProvinceCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int provinceId;
                        int sort = 0;
                        string abbreviation = null;
                        string name = null;

                        while (reader.Read())
                        {
                            provinceId = reader.GetInt32(reader.GetOrdinal("ProvinceId"));

                            sort = reader.GetInt32(reader.GetOrdinal("Sort"));

                            if (!reader.IsDBNull(1))
                            {
                                abbreviation = reader["Abbreviation"] as string;
                            }

                            if (!reader.IsDBNull(2))
                            {
                                name = reader["Name"] as string;
                            }

                            provinces.Add(new Province
                            {
                                ProvinceId = provinceId,
                                Sort = sort,
                                Abbreviation = abbreviation,
                                Name = name
                            });

                        }
                    }
                    return provinces;
                }

            }
        }
    }
}
