using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_class11;
using container;

namespace DataBaseConnectivity
{
    internal class Login:ILogin
    {
        PropertyADO obj3 = new PropertyADO();
        Userlogin obj4 = new Userlogin();
        public string username;
        public int perspective;
        [DataType(DataType.Password)]
        public string pwd;
        static SqlCommand cmd;

        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=KARTHICK;Persist Security Info=True;User ID=sa;Password=sql@123";

        public void LoginUserInput()
        {
            Console.WriteLine("Welcome to Tesla");
            Console.WriteLine("********************");
            Console.WriteLine("Login into User press '0' Or Admin press '1' ");
            perspective = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            pwd = Console.ReadLine();
        }

        public void UserRegistration()
        {
            

            
            obj3.InsertCus();
        }


        public void logincheck()
        {
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.LOGINCHECK(@uname,@pass)", con))
                {


                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@pass", pwd);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());


                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                        Console.WriteLine("******************************");
                        if (perspective == 0)
                        {
                            obj3.ShowProduct();
                            Console.WriteLine("Want To Buy Press 0 (Or) Leave Press 1");
                            int flag = Convert.ToInt32(Console.ReadLine());
                            if(flag == 0)
                            {
                                Console.WriteLine("**************************************************");
                                Console.WriteLine("Now Choose Your Product");
                                obj4.Orderprd();
                                Console.WriteLine("Enter Product ID To Add This Item into Your Cart");
                                int prd = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                            


                        }
                        else
                        {
                            Demo p = new Demo();
                            p.Menu();
                            Console.WriteLine("Would you like to continue (Y / N)");
                            char choice = Convert.ToChar(Console.ReadLine());
                            while (choice == 'Y' && choice != 'N')
                            {
                                p.Menu();
                            }
                        }

                        
                    }
                    else 
                    {
                        Console.WriteLine("User profile not available,Register Yourself");
                        Console.WriteLine("Choose \n 1.Register Yourself \n 2.Exit");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                obj3.InsertCus();
                                break;

                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }
}
