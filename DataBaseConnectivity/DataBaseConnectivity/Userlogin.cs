using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBaseConnectivity
{

    internal class Userlogin: IUserlogin
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=KARTHICK;Persist Security Info=True;User ID=sa;Password=sql@123";

        public void ShowProduct()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SHOWPRODUCT", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product ID:{reader["PRODUCT_ID"]}");
                            Console.WriteLine($"Product Name:{reader["PRODUCT_NAME"]}");
                            Console.WriteLine($"Product Price:{reader["PRODUCT_PRICE"]}");
                            Console.WriteLine($"Product Left:{reader["PRODUCT_LEFT"]}");
                           
                        }
                    }
                }
            }
        }

        
        public void AddOrder()
        {
            Console.WriteLine("Choose Which Product Do You Want?");

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("ADDORDER", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                        }
                    }



                }
            }
        }

        public void Orderprd()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("ORDERPRD", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product ID:{reader["PRODUCT_ID"]}");
                            Console.WriteLine($"Product Name:{reader["PRODUCT_NAME"]}");
                            

                        }
                    }
                }
            }
        }


       


    }
}
