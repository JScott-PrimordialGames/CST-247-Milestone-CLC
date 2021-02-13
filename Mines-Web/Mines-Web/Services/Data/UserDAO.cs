using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Mines_Web.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Mines_Web.Services.Data
{
    public class UserDAO
    {
        //Configuration string from web.config
        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;

        //Stored Procedure List
        string spGetUser = "[DBO].[SP_GetUser]";
        string spAddUser = "[DBO].[SP_AddUser]";
        string spEmailCheck = "[DBO].[SP_EmailAddress_Unique_Check]";
        string spDeleteUser = "[DBO].[sp_deleteUser]";
        string spUserNameCheck = "[DBO].[SP_UserName_Unique_Check]";
        string spUpdateProfile = "[DBO].[SP_UpdateProfile]";
        string spUpdateProfileAdmin = "[DBO].[SP_UpdateProfile_Admin]";
        string spGetAllUsers = "[DBO].[SP_GetAllUsers]";
        string spSearchUsers = "[DBO].[SP_SearchUsers]";

        //Gets a single user from the database
        public UserModel GetUser(int id)
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

                        if (reader.HasRows)
                        {
                            user.ID = Convert.ToInt32(reader["Id"].ToString());
                            user.Username = reader["UserName"].ToString();
                            user.FirstName = reader["FirstName"].ToString();
                            user.LastName = reader["LastName"].ToString();
                            user.Email = reader["EmailAddress"].ToString();
                            user.State = reader["State"].ToString();
                            user.Age = Convert.ToInt32(reader["Age"].ToString());
                            user.Gender = Convert.ToChar(reader["Gender"].ToString());
                        }

                        reader.Close();
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("Exception: {0}: {1}\n{2}", ex.Number, ex.Message, ex.Errors);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                }
            }

            return user;
        }

        //Adds a single user to the database
        public bool AddUser(UserModel user)
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
                        Debug.WriteLine("Exception: {0}: {1}\n{2}", ex.Number, ex.Message, ex.Errors);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Exception:" + ex.Message);
                    }
                    return false;
                }
            }
        }

        //Checks if an email address is unique
        public bool EmailUnique(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spEmailCheck, conn))
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

                        if(Convert.ToInt32(isUnique.Value) == 1)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("Exception: {0}: {1}\n{2}", ex.Number, ex.Message, ex.Errors);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Exception:" + ex.Message);
                    }
                    return false;
                }
            }
        }

        //Deletes a single user
        public bool DeleteUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spDeleteUser, conn))
                {
                    SqlParameter isSuccessful = new SqlParameter("@DeletionSuccessful", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };
                    cmd.Parameters.AddWithValue("@Id", user.ID);
                    cmd.Parameters.Add(isSuccessful);
                    
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if(Convert.ToInt32(isSuccessful.Value) == 1)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    return false;
                }
            }
        }
        
        //Returns a list of all users in the database
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> allUsers = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spGetAllUsers, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            UserModel user = new UserModel();
                            user.ID = Convert.ToInt32(reader["Id"]);
                            user.Username = reader["UserName"].ToString();
                            user.FirstName = reader["FirstName"].ToString();
                            user.LastName = reader["LastName"].ToString();
                            user.Email = reader["EmailAddress"].ToString();
                            user.State = reader["State"].ToString();
                            user.Age = Convert.ToInt32(reader["Age"].ToString());
                            user.Gender = Convert.ToChar(reader["Gender"].ToString());
                            allUsers.Add(user);
                        }
                        reader.Close();
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                }
            }
            
            return allUsers;
        }

        //Returns a list of all users matching a search string in the database
        public List<UserModel> SearchUsers(string searchString)
        {
            List<UserModel> allUsers = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spSearchUsers, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchString", searchString);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            UserModel user = new UserModel();
                            user.ID = Convert.ToInt32(reader["Id"]);
                            user.Username = reader["UserName"].ToString();
                            user.FirstName = reader["FirstName"].ToString();
                            user.LastName = reader["LastName"].ToString();
                            user.Email = reader["EmailAddress"].ToString();
                            user.State = reader["State"].ToString();
                            user.Age = Convert.ToInt32(reader["Age"].ToString());
                            user.Gender = Convert.ToChar(reader["Gender"].ToString());
                            allUsers.Add(user);
                        }
                        reader.Close();
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                }
            }

            return allUsers;
        }

        //User updates their profile
        public bool UpdateProfile(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spUpdateProfile, conn))
                {
                    SqlParameter isSuccessful = new SqlParameter("@UpdateSuccessful", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", user.ID);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@State", user.State);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.Add(isSuccessful);


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if(Convert.ToInt32(isSuccessful.Value) == 1)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }

                    return false;
                }
            }
        }

        //Admin updates a profile
        public bool UpdateProfileAdmin(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spUpdateProfileAdmin, conn))
                {
                    SqlParameter isSuccessful = new SqlParameter("@UpdateSuccessful", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", user.ID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.Email);
                    cmd.Parameters.AddWithValue("@State", user.State);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.Add(isSuccessful);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        if (Convert.ToInt32(isSuccessful.Value) == 1)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }

                    return false;
                }
            }
        }

        //Checks if an username is unique
        public bool UserNameUnique(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spUserNameCheck, conn))
                {
                    SqlParameter isUnique = new SqlParameter("@IsUnique", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };
                    cmd.Parameters.AddWithValue("@UserName", user.Username);
                    cmd.Parameters.Add(isUnique);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if (Convert.ToInt32(isUnique.Value) == 1)
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
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Debug.WriteLine("Exception: {0}" + ex.Message);
                    }
                    return false;
                }
            }
        }
    }
}