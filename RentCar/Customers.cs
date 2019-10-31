using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace RentCar
{
    class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        public string consoleClientID, consoleClientName, consoleBirthDate, consoleZipCode;

        public int txt_Id;
        public DateTime txt_BirthDate;
        public string txt_Location, txt_Name;

        public void AddCustomer()
        {

            //Console.Write("Client ID:");
            //consoleClientID = Console.ReadLine().ToString();

            Console.Write("Client Name:");
            consoleClientName = Console.ReadLine().ToString();

            Console.Write("Birth Date (e.g. dd-MM-yyyy):");
            consoleBirthDate = Console.ReadLine().ToString();

            Console.Write("ZIP Code:");
            consoleZipCode = Console.ReadLine();
        }

        public bool IsClientIDValid(string consoleClientID)
        {
            SqlConnection con;
            SqlCommand com;
            SqlDataReader reader;

            try
            {
                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();



                if (consoleClientID == "")
                {
                    Console.WriteLine("Please enter a client id!");
                    return false;
                }

                // Check for characters other than integers.
                else if (Regex.IsMatch(consoleClientID.ToString(), @"^\D*$"))
                {
                    // Show message and clear input.
                    Console.WriteLine("Client ID must contain only numbers!");
                    return false;
                }
                else
                {

                    reader = new SqlCommand("select * from Customers where CostumerID = " + consoleClientID, con).ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine("Client Id already exist! Please use another client id!");
                        return false;

                    }

                    else

                    {
                        txt_Id = Int32.Parse(consoleClientID);
                        return true;

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

        public bool ClientIDUpdate(string consoleClientID)
        {
            SqlConnection con;
            SqlCommand com;
            SqlDataReader reader;

            try
            {
                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                con.Open();



                if (consoleClientID == "")
                {
                    Console.WriteLine("Please enter a client id!");
                    return false;
                }

                // Check for characters other than integers.
                else if (Regex.IsMatch(consoleClientID.ToString(), @"^\D*$"))
                {
                    // Show message and clear input.
                    Console.WriteLine("Client ID must contain only numbers!");
                    return false;
                }
                else
                {


                    txt_Id = Int32.Parse(consoleClientID);
                     return true;

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

        public bool BirthDateValid()
        {
            //string[] formats = {"dd-MM-yyyy hh:mm:ss",  "dd-MM-yyyy hh:mm" };
            string[] formats = {"dd-MM-yyyy"};

            if (consoleBirthDate == "")
            {
                Console.WriteLine("Please enter a birth date!");
                return false;
            }
            else if ((DateTime.TryParseExact(consoleBirthDate, formats,
                                new System.Globalization.CultureInfo("en-US"),
                                DateTimeStyles.None, out txt_BirthDate)) == false)
            {
                Console.WriteLine("Birth Date: You have entered an incorrect value.");

                return false;
            }
            else
            {
                
                txt_BirthDate = DateTime.Parse(consoleBirthDate);
                String.Format("{0:dd-MM-yyyy}", txt_BirthDate);
                return true;
            }
        }

        //'''I added ZIP code in the database column

        public bool IsZipValid()
        {
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            if (consoleZipCode == "")
            {
                txt_Location = "";
                return true;
            }
            else if ((!Regex.Match(consoleZipCode, _usZipRegEx).Success))
            {
                Console.WriteLine("ZIP Code is not in the correct US format!");
                return false;
            }
            else
            {
                txt_Location = consoleZipCode;
                return true;

            }

        }

        public bool IsNameValid()
        {
            
          if (consoleClientName == "")
                {
                    Console.WriteLine("Please specify a name!");
                    return false;
                }

                // Check for characters other than integers.
                else if (Regex.IsMatch(consoleClientName.ToString(), @"^[a-zA-Z- ]+$") == false)
                {
                    // Show message and clear input.
                    Console.WriteLine("Name must contain only letters!");
                    return false;
                }
                else
                {

          
                        txt_Name = consoleClientName.ToString();
                        return true;


                    }
        }
    }
}
