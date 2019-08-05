using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class GuestBusinessLayer
    {
        /// <summary>
        /// Geting data from dataBase using storedProcedure
        /// </summary>
        public IEnumerable<Guest> Guest
        {
            #region "Get method"
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["GuestList"].ConnectionString;

                List<Guest> guests = new List<Guest>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllGuest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Guest guest = new Guest();
                        guest.Id = Convert.ToInt32(rdr["Id"]);
                        guest.Name = rdr["Name"].ToString();
                        guest.Address = rdr["Address"].ToString();
                        guest.Email = rdr["Email"].ToString();
                        guest.Age = Convert.ToInt32(rdr["Age"]);
                        guests.Add(guest);
                    }
                }
                return guests;
            }
            #endregion
        }
    }
}
