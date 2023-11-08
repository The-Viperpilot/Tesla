using DataBaseConnectivity;
using System;
using System.Runtime.CompilerServices;


namespace container
{
    public class Demo
    {
        public void Menu()
        {
            
            bool val = true;
            
            while (val)
            {
                Console.WriteLine("What do you Need ?");
                Console.WriteLine("Choose\n 1.View Customers \n 2.View Customers By Id\n 3.Insert Customers\n 4.Update Customer\n 5.Delete Customer \n 6.Show Orders \n 7.Show Products \n 8.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                PropertyADO obj = new PropertyADO();

                switch (option)
                {
                    case 1:
                        obj.ShowCus();
                        break;
                    case 2:
                        obj.ShowCusById();
                        break;
                    case 3:
                        obj.InsertCus();
                        break;
                    case 4:
                        obj.UpdateCus();
                        break;
                    case 5:
                        obj.DeleteCus();
                        break;
                    case 6:
                        obj.Showorders();
                        break;
                    case 7:
                        obj.ShowProduct();
                        break;
                     case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option..");
                        break;
                }
                Console.WriteLine("Would you like to Continue  Y / N ");
                
                char c = Convert.ToChar(Console.ReadLine());
                if (c == 'Y')
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
        }
        public static void Main(string[] args)

        {
            Login ob = new Login();
            ob.logincheck();
        }


    }

}