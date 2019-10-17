using System;
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

            //SqlConnection con;
            //SqlDataReader reader;

            //try

            //{

            //    //int id;

            //    con = new SqlConnection(Properties.Settings.Default.ConnectionString);

            //    con.Open();

            //    //Console.WriteLine("Enter Employee Id");

            //    //id = int.Parse(Console.ReadLine());

            //    reader = new SqlCommand("select * from Customers where CostumerID=1", con).ExecuteReader();



            //    if (reader.HasRows)

            //    {

            //        while (reader.Read())

            //        {

            //            Console.WriteLine("CostumerID | Name  \n {0}  |   {1}  ", reader.GetInt32(0),

            //            reader.GetString(1));

            //        }

            //    }

            //    else

            //    {

            //        Console.WriteLine("No rows found.");

            //    }

            //    reader.Close();

            //}

            //catch (Exception ex)

            //{

            //    Console.WriteLine(ex.Message);

            //}
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


            //////
            //MenuScreen();

            int c_CarId, c_ClientId;
            DateTime c_StartDate, c_EndDate;
            string c_location;

            int vMenu = DisplayMenu();
            switch (vMenu)
            {
                case 1:
                    ////Console.WriteLine("Register new Cart Rent");
                    //Console.Write("Cart Id:");
                    //Reservations myReservation = new Reservations ();
                    //myReservation .CarID= int.Parse (Console.ReadLine());
                    //Console.Write("Client ID:");
                    //myReservation.CostumerID = int.Parse(Console.ReadLine());
                    //Console.Write("Start Date:");
                    //myReservation.StartDate  = DateTime.Parse (Console.ReadLine());
                    //Console.Write("End Date:");
                    //myReservation.EndDate  = DateTime.Parse(Console.ReadLine());
                    //Console.Write("City:");
                    //myReservation.Location = Console.ReadLine();

                    Console.Write("Cart Id:");
                    int txt_CarID = int.Parse(Console.ReadLine());
                    Console.Write("Client ID:");
                    int txt_CostumerID = int.Parse(Console.ReadLine());
                    Console.Write("Start Date (e.g. 10/22/1987):");
                    DateTime txt_StartDate;
                    if ( (DateTime.TryParse(Console.ReadLine(), out txt_StartDate))==false)
                     {
                        Console.WriteLine("You have entered an incorrect value.");
                    }
                    //DateTime txt_StartDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("End Date (e.g. 10/22/1987):");
                    //DateTime txt_EndDate = DateTime.Parse(Console.ReadLine());
                    DateTime txt_EndDate;
                    if ((DateTime.TryParse(Console.ReadLine(), out txt_EndDate)) == false)
                    {
                        Console.WriteLine("You have entered an incorrect value.");
                    }
                    else
                    {
                        if (txt_StartDate <=txt_EndDate)
                        {
                            // Doyour stuff.
                        }
                        else
                        {
                            Console.WriteLine("You have entered an incorrect value.");
                        }
                    }


                    Console.Write("City:");
                    string txt_Location = Console.ReadLine();

                    //''''''
                    //int txt_ReservStatsID = 1;
                    //string txt_CouponCode = "0I0J93K";
                    SqlConnection con;
                    SqlCommand com;
                    SqlDataReader reader, carId_reader, CostumerId_reader;

                    con = new SqlConnection(Properties.Settings.Default.ConnectionString);

                    con.Open();

                    //•	If the Car Model exists and is available
                    carId_reader = new SqlCommand("select * from Cars where CarID = "+ txt_CarID, con).ExecuteReader();
                   
                    if (carId_reader.HasRows)

                    {

                        while (carId_reader.Read())

                        {

                            //com = new SqlCommand("insert into Reservations (CarID, CostumerID, StartDate, EndDate, Location, ReservStatsID, CouponCode) values (@CarID, @CostumerID, @StartDate, @EndDate, @Location, @ReservStatsID, @CouponCode)", con);
                            com = new SqlCommand("insert into Reservations (CarID, CostumerID, StartDate, EndDate, Location) values (@CarID, @CostumerID, @StartDate, @EndDate, @Location)", con);

                            com.Parameters.Add("@CarID", txt_CarID);
                            com.Parameters.Add("@CostumerID", txt_CostumerID);
                            com.Parameters.Add("@StartDate", txt_StartDate);
                            com.Parameters.Add("@EndDate", txt_EndDate);
                            com.Parameters.Add("@Location", txt_Location);
                            //com.Parameters.Add("@ReservStatsID", txt_ReservStatsID);
                            //com.Parameters.Add("@CouponCode", txt_CouponCode);
                            com.ExecuteNonQuery();


                        }

                    }

                    else

                    {

                        Console.WriteLine("No car found.");

                    }

                    carId_reader.Close();

                    
                    //reader = new SqlCommand("select * from Reservations where CostumerID =1", con).ExecuteReader();



                    //if (reader.HasRows)

                    //{

                    //    while (reader.Read())

                    //    {

                    //        Console.WriteLine("CostumerID |CarID  \n {0}  |   {1}  ", reader.GetInt32(0), reader.GetInt32(0));

                    //    }

                    //}

                    //else

                    //{

                    //    Console.WriteLine("No rows found.");

                    //}

                    //reader.Close();
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
