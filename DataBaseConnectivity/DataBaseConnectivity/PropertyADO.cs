using c_class11;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBaseConnectivity
{ 

    public class PropertyADO:IProperty
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=KARTHICK;Persist Security Info=True;User ID=sa;Password=sql@123";

    public static int Cusid;
    public static string fname;
    public static string lname;
    public static string address;
    public static int mobnum;
    public static string email;
    public static string uname;
    public static string pass;

    public  void getInput()
    {
        Console.WriteLine("Enter Customer Id: ");
        Cusid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter First name: ");
        fname = Console.ReadLine();
        Console.WriteLine("Enter Last name: ");
        lname = Console.ReadLine();
        Console.WriteLine("Enter Customer Address: ");
        address = Console.ReadLine();
        Console.WriteLine("Enter Mobile Number: ");
        mobnum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email: ");
        email = Console.ReadLine();
        Console.WriteLine("Enter User name: ");
        uname = Console.ReadLine();
        Console.WriteLine("Enter Password: ");
        pass = Console.ReadLine();
       


    }

        public  void ShowCus()
        {
            using(var con = new SqlConnection(connectionString))
            {
                using(var cmd  = new SqlCommand("SHOWCUS", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"Customer ID:{reader["CUSTOMER_ID"]}");
                            Console.WriteLine($"First Name:{reader["FIRST_NAME"]}");
                            Console.WriteLine($"Last Name:{reader["LAST_NAME"]}");
                            Console.WriteLine($"Customer Address:{reader["CUTOMER_ADDRESS"]}");
                            Console.WriteLine($"Mobile Number:{reader["MOBILE_NUMBER"]}");
                            Console.WriteLine($"Email Address:{reader["EMAIL_ADDRESS"]}");
                            Console.WriteLine($"User Name:{reader["USERNAME"]}");
                            Console.WriteLine($"Password:{reader["PASSWORD"]}");
                        }
                    }
                }
            }
        }
        public void Showorders()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SHOWORDERS", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Order ID:{reader["ORDER_ID"]}");
                            Console.WriteLine($"Customer ID:{reader["CUSTOMER_ID"]}");
                            Console.WriteLine($"Product ID:{reader["PRODUCT_ID"]}");
                            Console.WriteLine($"Total Price:{reader["TOTAL_PRICE"]}");
                            Console.WriteLine($"Status:{reader["STATUS"]}");
                            
                        }
                    }
                }
            }
        }
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

        public  void InsertCus()
        {
            getInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("INSERTCUS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSID", Cusid);
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@CUSADD", address);
                    cmd.Parameters.AddWithValue("@MOBNUM", mobnum);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@UNAME", uname);
                    cmd.Parameters.AddWithValue("@PWD", pass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Property details successfully added");


                }
            }
        }

        public  void DeleteCus()
        {
            Console.WriteLine("Enter User Id:");
            Cusid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Are You Confirm To Delete Y/N");
            char flag = Convert.ToChar(Console.ReadLine());

            if (flag == 'Y')
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("DELETECUS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CUSID", Cusid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        

                    }
                }
                Console.WriteLine("Records Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Property not deleted ");
            }
        }

        public  void UpdateCus()
        {
            Console.WriteLine("Enter Customer ID to update: ");
            Cusid = Convert.ToInt32(Console.ReadLine());

            // Fetch the existing customer information
            ShowCusById();

            // Get new details from the user
            Console.WriteLine("Enter updated details: ");
            getInput();

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("UPDATECUS", con)) // Use the appropriate stored procedure for updating or modify the SQL command.
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSID", Cusid);
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@CUSADD", address);
                    cmd.Parameters.AddWithValue("@MOBNUM", mobnum);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@UNAME", uname);
                    cmd.Parameters.AddWithValue("@PASS", pass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Customer details successfully updated");
                }
            }
        }



        public  void ShowCusById()
        {
            Console.WriteLine("Enter User Id:");
            Cusid = Convert.ToInt32(Console.ReadLine());
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SHOWCUSBYID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSID", Cusid);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Customer ID:{reader["CUSTOMER_ID"]}");
                            Console.WriteLine($"First Name:{reader["FIRST_NAME"]}");
                            Console.WriteLine($"Last Name:{reader["LAST_NAME"]}");
                            Console.WriteLine($"Customer Address:{reader["CUTOMER_ADDRESS"]}");
                            Console.WriteLine($"Mobile Number:{reader["MOBILE_NUMBER"]}");
                            Console.WriteLine($"Email Address:{reader["EMAIL_ADDRESS"]}");
                            Console.WriteLine($"User Name:{reader["USERNAME"]}");
                            Console.WriteLine($"Password:{reader["PASSWORD"]}");
                        }
                    }



                }
            }
        }


        public void Addtoorder()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("ADDTOORDER", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSID", Cusid);
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.Parameters.AddWithValue("@CUSADD", address);
                    cmd.Parameters.AddWithValue("@MOBNUM", mobnum);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@UNAME", uname);
                    cmd.Parameters.AddWithValue("@PWD", pass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Property details successfully added");


                }
            }
        }





    }

}
