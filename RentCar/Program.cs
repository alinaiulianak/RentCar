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


            int vMenu;
            SqlConnection con;
            SqlCommand com;
            SqlDataReader reader;

            do
            {
                vMenu = DisplayMenu();
                switch (vMenu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Register new Cart Rent ");
                        Reservations myReservation = new Reservations();
                        myReservation.AddRent();

                        //SqlConnection con;
                        //SqlCommand com;

                        try
                        {
                            con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            con.Open();




                            if (myReservation.IsCarIDValid(myReservation.consoleCarID) && myReservation.IsCustomerIDValid(myReservation.consoleCustomerID)
                                && myReservation.IsCarAvailable() && myReservation.IsCarLocationValid() && myReservation.IsDataEndValid(myReservation.consoleDataEnd)
                                && myReservation.IsDataStartValid(myReservation.consoleDataStart))
                            {
                                //myReservation.txt_CarID = Int32.Parse(myReservation.consoleCarID);
                                //myReservation.txt_CostumerID = Int32.Parse(myReservation.consoleCustomerID);
                                //myReservation.txt_StartDate = DateTime.Parse(myReservation.consoleDataStart);
                                //myReservation.txt_EndDate = DateTime.Parse(myReservation.consoleDataEnd);

                                com = new SqlCommand("insert into Reservations (CarID, CostumerID, StartDate, EndDate, Location) values (@CarID, @CostumerID, @StartDate, @EndDate, @Location)", con);

                                com.Parameters.Add("@CarID", myReservation.txt_CarID);
                                com.Parameters.Add("@CostumerID", myReservation.txt_CostumerID);
                                com.Parameters.Add("@StartDate", myReservation.txt_StartDate);
                                com.Parameters.Add("@EndDate", myReservation.txt_EndDate);
                                com.Parameters.Add("@Location", myReservation.txt_Location);
                                com.ExecuteNonQuery();
                                Console.WriteLine("Success  register a new cart rent!");

                            }
                            else
                            {
                                Console.WriteLine("Error! Please try again! ");
                            }
                            Console.ReadLine();
                            con.Close();
                        }


                        catch (Exception ex)

                        {

                            Console.WriteLine(ex.Message);
                            Console.ReadLine();

                        }

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Update Cart Rent");

                        Reservations UpdateRentItem = new Reservations();
                        Console.WriteLine("All cart rent:");
                        OutputTable("select CarID, CostumerID, StartDate, EndDate,Location from Reservations ", true);
                        Console.WriteLine("   ");
                        Console.WriteLine("Which Cart Rent would you like to update?");

                        String consoleUpdateCar, consoleUpdateClient, consoleUpdateStart;
                        Console.Write("Cart ID:");
                        consoleUpdateCar = Console.ReadLine().ToString();

                        Console.Write("Client ID:");
                        consoleUpdateClient = Console.ReadLine().ToString();

                        Console.Write("Start Date (e.g. 10/22/1987):");
                        consoleUpdateStart = Console.ReadLine().ToString();
                        

                        try
                        {
                            DateTime updateStart=DateTime.Now;
                            if (UpdateRentItem.IsCarIDValid(consoleUpdateCar) && UpdateRentItem.IsDataStartValid(consoleUpdateStart)  && UpdateRentItem.IsCustomerIDValid(consoleUpdateClient))
                            {
                                //UpdateRentItem.txt_CarID = Int32.Parse(UpdateRentItem.consoleCarID);
                                //UpdateRentItem.txt_CostumerID = Int32.Parse(UpdateRentItem.consoleCustomerID);
                                //UpdateRentItem.txt_StartDate= DateTime.Parse(UpdateRentItem.consoleDataStart);
                                //updateStart=DateTime .Parse(con)

                                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                                con.Open();
                                reader = new SqlCommand("select CarID, CostumerID, StartDate, EndDate,Location from Reservations where CarID=" + Int32.Parse(consoleUpdateCar) + " and CostumerID=" + Int32.Parse(consoleUpdateClient) + " and StartDate='" + DateTime.Parse(consoleUpdateStart) + "'", con).ExecuteReader();

                                if (reader.FieldCount != null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Update this cart rent:");
                                    OutputTable("select CarID, CostumerID, StartDate, EndDate,Location from Reservations where CarID=" + Int32.Parse(consoleUpdateCar) + " and CostumerID=" + Int32.Parse(consoleUpdateClient) + " and StartDate='" + DateTime.Parse(consoleUpdateStart) + "'", true);
                                    //Console.WriteLine("select CarID, CostumerID, StartDate, EndDate,Location from Reservations where CarID=" + Int32.Parse(consoleUpdateCar) + " and CostumerID=" + Int32.Parse(consoleUpdateClient) + " and StartDate='" + DateTime.Parse(consoleUpdateStart) + "'");
                                    UpdateRentItem.AddRent();

                                    if (UpdateRentItem.IsCarIDValid(UpdateRentItem.consoleCarID) && UpdateRentItem.IsCustomerIDValid(UpdateRentItem.consoleCustomerID)
                                            && UpdateRentItem.IsCarAvailable() && UpdateRentItem.IsCarLocationValid() && UpdateRentItem.IsDataEndValid(UpdateRentItem.consoleDataEnd)
                                            && UpdateRentItem.IsDataStartValid(UpdateRentItem.consoleDataStart))
                                    {
                                        //UpdateRentItem.txt_CarID = Int32.Parse(UpdateRentItem.consoleCarID);
                                        //UpdateRentItem.txt_CostumerID = Int32.Parse(UpdateRentItem.consoleCustomerID);
                                        //UpdateRentItem.txt_StartDate = DateTime.Parse(UpdateRentItem.consoleDataStart);
                                        //UpdateRentItem.txt_EndDate = DateTime.Parse(UpdateRentItem.consoleDataEnd);
                                        reader.Close();

                                        com = new SqlCommand("Update Reservations SET CarID=@CarID, CostumerID=@CostumerID, StartDate=@StartDate, EndDate=@EndDate, Location=@Location where CarID=" + Int32.Parse(consoleUpdateCar) + " and CostumerID=" + Int32.Parse(consoleUpdateClient) + " and StartDate='" + DateTime.Parse(consoleUpdateStart) + "'", con);

                                        com.Parameters.Add("@CarID", UpdateRentItem.txt_CarID);
                                        com.Parameters.Add("@CostumerID", UpdateRentItem.txt_CostumerID);
                                        com.Parameters.Add("@StartDate", UpdateRentItem.txt_StartDate);
                                        com.Parameters.Add("@EndDate", UpdateRentItem.txt_EndDate);
                                        com.Parameters.Add("@Location", UpdateRentItem.txt_Location);
                                        com.ExecuteNonQuery();
                                        Console.WriteLine("Success  update this cart rent!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Update failed!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This cart rent doesn't exist in database!");
                                }

                                con.Close();
                                Console.ReadLine();

                            }
                            else
                            {
                                Console.Write("Error! Update failed!");
                            }
                          
                            Console.ReadLine();
                            
                        }


                        catch (Exception ex)

                        {

                            Console.WriteLine(ex.Message);
                            Console.ReadLine();

                        }

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("List Rents");
                        OutputTable("select CarID, CostumerID, StartDate, EndDate,Location from Reservations ", true);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("List of available car ");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Please specify in which date interval do you want to see the available cars");
                        Console.WriteLine("\n");
                        Console.Write("Start Date (e.g. 10/22/1987):");
                        string consoleListDateStart= Console.ReadLine().ToString();
                        Console.Write("End Date (e.g. 10/22/1987):");
                        string consoleListDateEnd = Console.ReadLine().ToString();


                        localhost.ListRentCart obj = new localhost.ListRentCart();
                        if ((obj.IsDataValid(consoleListDateStart) == true) && (obj.IsDataValid(consoleListDateEnd) == true))
                        {
                            DateTime txt_DateListStart = DateTime.Now;
                            DateTime txt_DateListEnd = DateTime.Now;
                            txt_DateListStart = DateTime.Parse(consoleListDateStart);
                            txt_DateListEnd = DateTime.Parse(consoleListDateEnd);
                            OutputTable("select distinct  Cars.CarID, Plate, Model,LocationCar  from Reservations, Cars  where (Cars.CarID not in (select Reservations.CarID from Reservations )) or (Cars.CarID not in (select Cars.CarID from Reservations, Cars where Reservations.CarID = Cars.CarID and ((Reservations.StartDate <= '"
                                + txt_DateListStart+"' and Reservations.EndDate >= '"+ txt_DateListEnd+ "') or (Reservations.StartDate between '"
                                + txt_DateListStart+"' and '"+ txt_DateListEnd+"'))))", true);
                        }
                        else
                        { Console.Write("Error! The date is incorrect!"); }
                        
                        Console.ReadLine();
                        break;

//                        select Cars.CarID,Plate, Manufacturer,Model from Reservations, Cars where Reservations.CarID = Cars.CarID and Reservations.StartDate <= '9/9/2001' and Reservations.EndDate >= '9/9/2001'

//select Plate, Model, StartDate, EndDate, Reservations.Location from Reservations, Cars where (Reservations.CarID = Cars.CarID and(((Reservations.StartDate < '9/9/2001' and Reservations.EndDate < '9/9/2001') or(Reservations.StartDate > '9/9/2001' and Reservations.EndDate > '9/9/2001'))))  or(Cars.CarID not in (select CarID from Reservations)) 

//select* from Cars, Reservations where Cars.CarID not in (select CarID from Reservations) group by Cars.CarID
//select* from Cars, Reservations where Cars.CarID not in Reservations.CarID

//select Cars.CarID, Plate, Model, StartDate, EndDate, Reservations.Location from Cars, Reservations
//where Cars.CarID not in(select Reservations.CarID from Reservations where  Reservations.StartDate <= '9/9/2001' and Reservations.EndDate >= '9/9/2001' group by Cars.Plate) 
                    case 5:

                        Console.Clear();
                        Console.WriteLine("Register new Customer:");
                        Customers  myCustomer = new Customers();
                        myCustomer.AddCustomer();

                       

                        try
                        {
                            con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            con.Open();




                            if (myCustomer.IsClientIDValid(myCustomer.consoleClientID) && myCustomer.IsZipValid() && myCustomer.BirthDateValid() && myCustomer.IsNameValid())
                            {
                                
                                
                                
                                com = new SqlCommand("insert into Customers (CostumerID, Name, BirthDate, ZIPCode) values (@CostumerID, @Name, @BirthDate, @ZIPCode)", con);

                                com.Parameters.Add("@CostumerID", myCustomer.txt_CostumerID);
                                com.Parameters.Add("@Name", myCustomer.txt_Name);
                                com.Parameters.Add("@BirthDate", myCustomer.txt_BirthDate);
                                com.Parameters.Add("@ZIPCode", myCustomer.txt_Location);
                                com.CommandText = "SET IDENTITY_INSERT Customers ON";
                                com.ExecuteNonQuery();
                                Console.WriteLine("Success  register a new customer!");

                                com.CommandText = "SET IDENTITY_INSERT Customers OFF";
                                com.ExecuteNonQuery();
                            }
                            else
                            {
                                Console.WriteLine("Error! Please try again! ");
                            }
                            Console.ReadLine();
                            con.Close();
                        }


                        catch (Exception ex)

                        {

                            Console.WriteLine(ex.Message);
                            Console.ReadLine();

                        }

                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Update Customer");

                        Customers UpdateCustomer= new Customers();
                        Console.WriteLine("All customers:");
                        OutputTable("select CostumerID, Name, BirthDate, ZIPCode from Customers ", true);
                        Console.WriteLine("   ");
                        Console.WriteLine("Which customer would you like to update?");

                        String consoleUpdateCustomer;
                        Console.Write("Customer ID:");
                        consoleUpdateCustomer = Console.ReadLine().ToString();
                        
                        try
                        {
                            
                            if (UpdateCustomer.ClientIDUpdate(consoleUpdateCustomer))
                            {
                                

                                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                                con.Open();
                                reader = new SqlCommand("select CostumerID, Name, BirthDate, ZIPCode from Customers where CostumerID=" + Int32.Parse(consoleUpdateCustomer), con).ExecuteReader();

                                if (reader.FieldCount != null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Update this customer:");
                                    OutputTable("select CostumerID, Name, BirthDate, ZIPCode from Customers where CostumerID=" + Int32.Parse(consoleUpdateCustomer), true);
                                    UpdateCustomer.AddCustomer();

                                    if  (UpdateCustomer.IsZipValid() && UpdateCustomer.BirthDateValid() && UpdateCustomer.IsNameValid())
                                    {
                                        
                                        reader.Close();
                                    
                                        com = new SqlCommand("SET IDENTITY_INSERT dbo.Customers ON; Update dbo.Customers SET  Name=@Name,  BirthDate=@BirthDate, ZIPCode=@ZIPCode where CostumerID=" + Int32.Parse(consoleUpdateCustomer), con);
                                       Console.WriteLine("Update Customers SET  Name='"+UpdateCustomer.txt_Name+"', BirthDate='"+UpdateCustomer.txt_BirthDate+"', ZIPCode='"+UpdateCustomer.txt_Location +"' where CostumerID=" + Int32.Parse(consoleUpdateCustomer));
                                        //com.Parameters.Add("@CostumerID", UpdateCustomer.txt_CostumerID);
                                        com.Parameters.Add("@Name", UpdateCustomer.txt_Name);
                                        com.Parameters.Add("@BirthDate", UpdateCustomer.txt_BirthDate);
                                        com.Parameters.Add("@ZIPCode", UpdateCustomer.txt_Location);

                                        //com.CommandText = "SET IDENTITY_INSERT dbo.Customers ON";
                                        int rows = com.ExecuteNonQuery();
                                        Console.WriteLine("Success  update this customer!");
                                        OutputTable("select CostumerID, Name, BirthDate, ZIPCode from Customers where CostumerID=" + Int32.Parse(consoleUpdateCustomer), true);
                                        com.CommandText = "SET IDENTITY_INSERT Customers OFF";
                                        com.ExecuteNonQuery();
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine("Update failed!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This customer doesn't exist in database!");
                                }

                                con.Close();
                                Console.ReadLine();

                            }
                            else
                            {
                                Console.Write("Error! Update failed!");
                            }

                            Console.ReadLine();

                        }


                        catch (Exception ex)

                        {

                            Console.WriteLine(ex.Message);
                            Console.ReadLine();

                        }
                        break;
                    case 7:
                       
                        Console.Clear();
                        Console.WriteLine("List Customers");
                        OutputTable("select * from Customers ", true);
                        break;
                    case 8:
                        Console.WriteLine("Quit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("This is not a valid option.");
                        Console.ReadLine();
                        break;
                }
            } while (vMenu!=8);

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
        //private static void OutputTable()
        //{

           

        //    con = new SqlConnection(Properties.Settings.Default.ConnectionString);
        //    con.Open();
        //    reader = new SqlCommand("select CarID, CostumerID, StartDate, EndDate,Location from Reservations ", con).ExecuteReader();

        //    int columnCount = reader.FieldCount;
            private static void OutputTable(string query, bool showHeader)
        {
            SqlConnection con= new SqlConnection(Properties.Settings.Default.ConnectionString);
            //SqlCommand com;
            SqlDataReader reader;

            SqlCommand com = con.CreateCommand();
            com.CommandText = query;
            con.Open();
            reader = com.ExecuteReader();
            int columnCount = reader.FieldCount;

            List<List<string>> output = new List<List<string>>();

          
            List<string> values = new List<string>();
                for (int count = 0; count < columnCount; ++count)
                {
                    values.Add(string.Format("{0}", reader.GetName(count)));
                }
                output.Add(values);
           

            while (reader.Read())
            {
                List<string> values1 = new List<string>();
                for (int count = 0; count < columnCount; ++count)
                {
                    values1.Add(string.Format("{0}", reader[count]));
                }
                output.Add(values1);
            }
            reader.Close();

            List<int> widths = new List<int>();
            for (int count = 0; count < columnCount; ++count)
            {
                widths.Add(0);
            }

            foreach (List<string> row in output)
            {
                for (int count = 0; count < columnCount; ++count)
                {
                    widths[count] = Math.Max(widths[count], row[count].Length);
                }
            }

            //int totalWidth = widths.Sum() + (widths.Count * 1) * 3;
            //Console.SetWindowSize(Math.Max(Console.WindowWidth, totalWidth), Console.WindowHeight);

            foreach (List<string> row in output)
            {
                StringBuilder outputLine = new StringBuilder();

                for (int count = 0; count < columnCount; ++count)
                {
                    if (count > 0)
                    {
                        outputLine.Append(" ");
                    }
                    else
                    {
                        outputLine.Append("| ");
                    }
                    string value = row[count];
                    outputLine.Append(value.PadLeft(widths[count]));
                    outputLine.Append(" |");
                }

                Console.WriteLine("{0}", outputLine.ToString());
            }
            Console.ReadLine();
        }
    }
}
