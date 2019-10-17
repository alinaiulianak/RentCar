using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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


        public void AddCarRent()
        {
            
            Console.Write("Cart Id:");
           int txt_CarID= int.Parse(Console.ReadLine());
            Console.Write("Client ID:");
            int txt_CostumerID = int.Parse(Console.ReadLine());
            Console.Write("Start Date:");
            DateTime txt_StartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("End Date:");
            DateTime txt_EndDate = DateTime.Parse(Console.ReadLine());
            Console.Write("City:");
            string txt_Location = Console.ReadLine();

           SqlConnection con;
           SqlCommand com;
           con = new SqlConnection(Properties.Settings.Default.ConnectionString);

           con.Open();

           com = new SqlCommand("insert into Reservations (CarID, CostumerID, StartDate, EndDate, Location) values (@CarID, @CostumerID, @StartDate, @EndDate, @Location)", con);
           com.Parameters.Add("@CarID", txt_CarID);
            com.Parameters.Add("@CostumerID", txt_CostumerID);
            com.Parameters.Add("@StartDate", txt_StartDate);
            com.Parameters.Add("@EndDate", txt_EndDate);
            com.Parameters.Add("@Location", txt_Location);
            com.ExecuteNonQuery();



        }
        //        public int

        //        SqlConnection con;
        //        SqlDataReader reader;
        //        try
        //            {
        //                con = new SqlConnection(Properties.Settings.Default.ConnectionString);
        //                con.Open();

        //                reader = new SqlCommand("select * from Cars where CarID="+ console_CarID, con).ExecuteReader();



        //                if (reader.HasRows)

        //                {

        //                    while (reader.Read())

        //                    {

        //                        Console.WriteLine("CostumerID | Name  \n {0}  |   {1}  ", reader.GetInt32(0),

        //                        reader.GetString(1));

        //                    }

        //}

        //                else

        //                {

        //        Console.WriteLine("No rows found.");

        //    }

        //    reader.Close();

        //}

        //catch (Exception ex)

        //{

        //    Console.WriteLine(ex.Message);

        //}


    }
}
