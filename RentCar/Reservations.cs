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
        public Cars CarID { get; set; }
        public Customers CostumerID { get; set; }
        public RezervationStatuses ReservStatsID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string  Location { get; set; }
        public Coupons  CouponCode { get; set; }

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
