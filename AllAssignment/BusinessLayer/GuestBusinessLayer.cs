using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class GuestBusinessLayer
    {
        #region "Global string"
        string connectionString = ConfigurationManager.ConnectionStrings["GuestList"].ConnectionString;
        #endregion

        #region "Get method"
        /// <summary>
        /// Geting data from dataBase using storedProcedure @ACTION='SELECT'
        /// </summary>
        public IEnumerable<Guest> Guest
        {
            get
            {
                List<Guest> guests = new List<Guest>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CRUDOperationsGuest ", con);
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
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
                        guest.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        guest.Age = Convert.ToInt32(rdr["Age"]);
                        guest.Gender = rdr["Gender"].ToString();
                        guests.Add(guest);
                    }
                }
                return guests;
            }
        }
        #endregion

        #region "Insert method"
        /// <summary>
        ///  Inserting data in dataBase using storedProcedure @ACTION='INSERT'
        /// </summary>
        /// <param name="guest"></param>
        public void AddGuests(Guest guest)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("CRUDOperationsGuest", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@Name",guest.Name);
                    cmd.Parameters.AddWithValue("@Address", guest.Address);
                    cmd.Parameters.AddWithValue("@Email", guest.Email);
                    cmd.Parameters.AddWithValue("@Age", guest.Age);
                    cmd.Parameters.AddWithValue("@DateOfBirth", guest.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", guest.Gender);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion

        #region "Update method"
        /// <summary>
        ///  Updating data from dataBase using storedProcedure @ACTION='UPDATE'
        /// </summary>
        /// <param name="guest"></param>
        public void SaveGuest(Guest guest)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("CRUDOperationsGuest", con))
                {
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GuestId", guest.Id);
                    cmd.Parameters.AddWithValue("@Name", guest.Name);
                    cmd.Parameters.AddWithValue("@Address", guest.Address);
                    cmd.Parameters.AddWithValue("@Email", guest.Email);
                    cmd.Parameters.AddWithValue("@Age", guest.Age);
                    cmd.Parameters.AddWithValue("@DateOfBirth", guest.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", guest.Gender);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion

        #region "Delete method"
        /// <summary>
        ///  Deleting data from dataBase using storedProcedure @ACTION='DELETE'
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGuests(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CRUDOperationsGuest", con);
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@GuestId";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
