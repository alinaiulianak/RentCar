﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RentCar
{
    class Program
    {
        
    static void Main(string[] args)
        {

            Console.WriteLine("Welcome to RentC, your brand new solution to manage and control your company's data without missing anything.");
            Console.WriteLine(" Press ENTER to continue or ESC to quit.");
           
            ConsoleKeyInfo KeyM;
            do
            {
                KeyM = Console.ReadKey();
                Console.Write(KeyM.Key);
                if (KeyM.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (KeyM.Key == ConsoleKey.Enter)
                {
                   // DisplayMenu();
                }
                else
                {
                    Console.WriteLine(" This is not a valid option! Press ENTER to continue or ESC to quit!");
                  }
            } while ((KeyM.Key != ConsoleKey.Enter) && (KeyM.Key != ConsoleKey.Escape));




            int vMenu = DisplayMenu();
            switch (vMenu)
            {
                case 1:
                    Console.Clear();
                    Reservations myReservation = new Reservations();
                    myReservation.AddRent();
                   
                    SqlConnection con;
                    SqlCommand com;

                    try
                    {
                        con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                         con.Open();

                 

                        if (myReservation.IsCarIDValid() && myReservation .IsCustomerIDValid () && myReservation.IsCarLocationValid() && myReservation.IsDataEndValid() && myReservation.IsDataStartValid())
                        {
                        
                            com = new SqlCommand("insert into Reservations (CarID, CostumerID, StartDate, EndDate, Location) values (@CarID, @CostumerID, @StartDate, @EndDate, @Location)", con);

                            com.Parameters.Add("@CarID", myReservation.txt_CarID);
                            com.Parameters.Add("@CostumerID", myReservation.txt_CostumerID);
                            com.Parameters.Add("@StartDate", myReservation.txt_StartDate);
                            com.Parameters.Add("@EndDate", myReservation.txt_EndDate);
                            com.Parameters.Add("@Location", myReservation.txt_Location);
                            com.ExecuteNonQuery();
                            Console.WriteLine("Success  register a new cart rent!");
                        }
                        con.Close();
                    }


                    catch (Exception ex)

                    {

                        Console.WriteLine(ex.Message);
                      
                    }
                                        
                    break;
                case 2:
                    Console.WriteLine("Update Car Rent");
                    break;
                case 3:
                    Console.WriteLine("List Rents");
                    break;
                case 4:
                    Console.WriteLine("List Available Cars");
                    break;
                case 5:
                    Console.WriteLine("Register new Customer");
                    break;
                case 6:
                    Console.WriteLine("Update Customer");
                    break;
                case 7:
                    Console.WriteLine("List Customer");
                    break;
                case 8:
                    Console.WriteLine("Quit");
                    break;
                default:
                    Console.WriteLine("This is not a valid option.");
                    break;
            }


            Console.ReadLine();
        }
        
        static public int DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Register new Cart Rent");
            Console.WriteLine("2. Update Car Rent");
            Console.WriteLine("3. List Rents");
            Console.WriteLine("4. List Available Cars");
            Console.WriteLine("5. Register new Customer");
            Console.WriteLine("6. Update Customer");
            Console.WriteLine("7. List Customer");
            Console.WriteLine("8. Quit");
            
                var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
        
        private static void MenuScreen()
        {
            int vMenu = DisplayMenu();
            switch (vMenu)
            {
                case 1:
                    Console.WriteLine("Register new Cart Rent");
                    break;
                case 2:
                    Console.WriteLine("Update Car Rent");
                    break;
                case 3:
                    Console.WriteLine("List Rents");
                    break;
                case 4:
                    Console.WriteLine("List Available Cars");
                    break;
                case 5:
                    Console.WriteLine("Register new Customer");
                    break;
                case 6:
                    Console.WriteLine("Update Customer");
                    break;
                case 7:
                    Console.WriteLine("List Customer");
                    break;
                case 8:
                    Console.WriteLine("Quit");
                    break;
                default:
                    Console.WriteLine("This is not a valid option.");
                    break;
            }

        }
    }
}
