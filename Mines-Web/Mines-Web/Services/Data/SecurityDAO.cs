using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Mines_Web.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string RegisterUserQuery = "INSERT INTO dbo.Users (USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, STATE, GENDER, AGE) " +
                                                "VALUES(@Username, @Password, @FirstName, @LastName, @Email, @State, @Gender, @Age);";
        string FindUsernameQuery = "SELECT * FROM Test.dbo.Users " +
                                    "WHERE USERNAME = @Username";
        public bool CheckIfUsernameExists(UserModel user)
        {
            bool usernameExists = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(FindUsernameQuery, conn))
                {
                    //add values to the command parameters
                    command.Parameters.AddWithValue("@Username", user.Username);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                            usernameExists = true;
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return usernameExists;
                }
            }
        }

        //public bool EmailExists(UserModel user)
        //{

        //}

        public bool RegisterUser(UserModel user)
        {
            bool isAccountRegistered = false;

            // create database connection and command
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                using (SqlCommand command = new SqlCommand(RegisterUserQuery, conn))
                { 
                    //add values to the command parameters
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@State", user.State);
                    command.Parameters.AddWithValue("@Gender", user.Gender);
                    command.Parameters.AddWithValue("@Age", user.Age);

                    try
                    {
                        conn.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            isAccountRegistered = true;
                        }
                    } 
                    catch(SqlException ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return isAccountRegistered;
                }
            }
        }
    }
}