using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace RentCar
{
    class Reservations
    {
        //public Cars CarID { get; set; }
        //public Customers CostumerID { get; set; }
        //public RezervationStatuses ReservStatsID { get; set; }
        public int CarID;
        public int CostumerID;
        public int ReservStatsID;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
         public string  Location { get; set; }
        public Coupons  CouponCode { get; set; }

        public int txt_CarID, txt_CostumerID;
        public DateTime txt_StartDate, txt_EndDate;
        public string txt_Location;
        public string consoleCarID , consoleCustomerID, consoleLocation, consoleDataStart, consoleDataEnd;

        public void AddRent()
        {
      
            Console.Write("Cart Id:");
            consoleCarID = Console.ReadLine().ToString();

            Console.Write("Client ID:");
            consoleCustomerID = Console.ReadLine().ToString();

            Console.Write("Start Date (e.g. 10/22/1987):");
            consoleDataStart= Console.ReadLine().ToString();
       
            Console.Write("End Date (e.g. 10/22/1987):");
            consoleDataEnd = Console.ReadLine().ToString();

            Console.Write("City:");
            consoleLocation = Console.ReadLine();
        }

        public bool IsDataStartValid()
        {
            if (consoleDataStart == "")
            {
                Console.WriteLine("Please enter a start date!");
                return false;
            }
            else if ((DateTime.TryParse(consoleDataStart, out txt_StartDate)) == false)
            {
                Console.WriteLine("You have entered an incorrect value.");
                return false;
            }
            else
            {
                txt_StartDate = DateTime.Parse(consoleDataStart);
                return true;
            }
        }

        public bool IsDataEndValid()
        {
            if (consoleDataEnd == "")
            {
                Console.WriteLine("Please enter end date!");
                return false;
            }
            else if ((DateTime.TryParse(consoleDataEnd, out txt_EndDate)) == false)
            {
                Console.WriteLine("You have entered an incorrect value.");
                return false;
            }
            else
            {
                txt_EndDate = DateTime.Parse(consoleDataEnd);
                if (txt_StartDate <= txt_EndDate)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                    return false;
                }
            }
            
          
        }
            
        public bool IsCarIDValid()
        {
            SqlConnection con;
            SqlDataReader carId_reader;
                       ;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();



                if (consoleCarID == "")
                {
                    Console.WriteLine("Please specify the Cart ID!");
                    return false;
                }

                // Check for characters other than integers.
                else if (Regex.IsMatch(consoleCarID.ToString(), @"^\D*$"))
                {
                    // Show message and clear input.
                    Console.WriteLine("Cart ID must contain only numbers!");
                    return false;
                }
                else
                {
                    //•	If the Car Model exists and is available
                    carId_reader = new SqlCommand("select * from Cars where CarID = " + consoleCarID, con).ExecuteReader();

                    if (carId_reader.HasRows)
                    {
                        txt_CarID = Int32.Parse(consoleCarID);
                        return true;

                    }

                    else

                    {

                        Console.WriteLine("Client Id is not valid!");
                        return false;
                    }
                }
                carId_reader.Close();
            }
             

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);
                return false;
            }
            con.Close();

        }

        public bool IsCustomerIDValid()
        {
            SqlConnection con;
            SqlCommand com;
            SqlDataReader reader;
            ;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();



                if (consoleCustomerID == "")
                {
                    Console.WriteLine("Please create customer account before!");
                    return false;
                }

                // Check for characters other than integers.
                else if (Regex.IsMatch(consoleCustomerID.ToString(), @"^\D*$"))
                {
                    // Show message and clear input.
                    Console.WriteLine("Customer ID must contain only numbers!");
                    return false;
                }
                else
                {
                  
                    reader = new SqlCommand("select * from Customers where CostumerID = " + consoleCustomerID, con).ExecuteReader();

                    if (reader.HasRows)
                    {
                        txt_CostumerID = Int32.Parse(consoleCustomerID);
                        return true;

                    }

                    else

                    {

                        Console.WriteLine("Please create customer account before!");
                        return false;
                    }
                }
                reader.Close();
            }


            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);
                return false;
            }

            con.Close();
        }

        public bool IsCarLocationValid()
        {
            SqlConnection con;
            SqlCommand com;
            SqlDataReader reader;
           
            try
            {

              
                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();



                if (consoleLocation == "")
                {
                    Console.WriteLine("Please specify the Location!");
                    return false;
                }

                // Check for characters other than integers.
                else if (Regex.IsMatch(consoleLocation.ToString(), @"^[a-zA-Z-]+$")==false)
                {
                    // Show message and clear input.
                    Console.WriteLine("Location must contain only letters!");
                    return false;
                }
                else
                {
                 
                    reader = new SqlCommand("select * from Cars where LocationCar =\'" + consoleLocation.ToString() + "\' and CarID =" + txt_CarID, con).ExecuteReader();
         
                    if (reader.HasRows)
                    {
                        
                        txt_Location = consoleLocation.ToString();
                        return true;
                        

                    }

                    else

                    {
                        
                        Console.WriteLine("Cart is not available in the city for the user");
                        return false;
                       
                    }
                }
                reader.Close();
            }


            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);
                
                return false;
            }
            con.Close();

        }


    }
}
