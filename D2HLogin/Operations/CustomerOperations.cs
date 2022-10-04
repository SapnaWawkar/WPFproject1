using D2HLogin.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2HLogin.Operations
{
    public class CustomerOperations
    {
        private static string connectionString = @"Data Source=LAPTOP-QQJKA00R;Initial Catalog=Sapna;Integrated Security=True";
        public static CustomerPersonalInfo GetCustomersPersonalInfo(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command =
                    new SqlCommand(
                        $"EXECUTE [dbo].[GetCustomerPersonalInformation] {customerId}",
                        connection);

                var reader = command.ExecuteReader();
                CustomerPersonalInfo customerinfo = new CustomerPersonalInfo();
                
                while (reader.Read())
                {
                    customerinfo.CustomerId = (int)reader[0];
                    customerinfo.FirstName = (string)reader[1];
                    customerinfo.LastName = (string)reader[2];
                    customerinfo.PackageName = (string)reader[3];
                    customerinfo.GroupName = (string)reader[4];
                    customerinfo.AreaName = (string)reader[5];
                    break;
                }


                return customerinfo;
            }
        }
    }
}
