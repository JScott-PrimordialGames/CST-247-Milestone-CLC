using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Mines_Web.Models;
using System.Data.SqlClient;

namespace Mines_Web.Services.Data
{
    public class UserDAO
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;
        string spGetUser = "SP_GetUser";
        string spAddUser = "SP_AddUser";

        public UserModel getUser(int id)
        {
            UserModel user = new UserModel();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spGetUser, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        user.ID = Convert.ToInt32(reader["Id"].ToString());
                        user.Username = reader["UserName"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.Email = reader["EmailAddress"].ToString();
                        user.State = reader["State"].ToString();
                        user.Age = Convert.ToInt32(reader["Age"].ToString());
                        user.Gender = reader["Gender"].ToString();

                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                }
            }

            return user;
        }

        public bool addUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spAddUser, conn))
                {
                    SqlParameter isSuccessful = new SqlParameter("@AddSucceeded", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.Email);
                    cmd.Parameters.AddWithValue("@State", user.State);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.Add(isSuccessful);


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if (Convert.ToInt32(isSuccessful.Value) == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.Error.WriteLine("SQL Exception: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Exception:" + ex.Message);
                    }
                    return false;
                }
            }
        }

        public bool emailUnique(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLQuery, conn))
                {
                    SqlParameter isUnique = new SqlParameter("@IsUnique", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailAddress", user.Email);
                    cmd.Parameters.Add(isUnique);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if(Convert.ToInt32(isUnique) == 1)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.Error.WriteLine("SQL Exception: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Exception:" + ex.Message);
                    }
                    return false;
                }
            }
        }
    
        
    }
}