using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Configuration;


namespace Mines_Web.Services.Data
{
    public class SecurityDAO
    {
        //Configuration string from web.config
        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;

        //Store Procedures
        string spVerifyLogon = "[DBO].[SP_VerifyLogin]";
        string spChangePassWord = "[DBO].[SP_ChangePassword]";

        public UserModel Authenticate(PrincipalModel principal)
        {
            UserModel user = new UserModel();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spVerifyLogon, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Login", principal.UserName);
                    cmd.Parameters.AddWithValue("@Password", principal.Password);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
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
    
        public bool ChangePassword(PrincipalModel principal)
        {
            using(SqlConnection conn = new SqlConnection(connectionStr))
            {
                using(SqlCommand cmd = new SqlCommand(spChangePassWord, conn))
                {
                    SqlParameter isSuccessful = new SqlParameter("@IsSuccessful", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", principal.UserName);
                    cmd.Parameters.AddWithValue("@Password", principal.Password);
                    cmd.Parameters.Add(isSuccessful);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if(Convert.ToInt32(isSuccessful) == 1)
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