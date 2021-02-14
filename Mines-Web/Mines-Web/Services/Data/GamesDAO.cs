using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Mines_Web.Models;
using System.Web;
using System.Diagnostics;


namespace Mines_Web.Services.Data
{
    public class GamesDAO
    {
        //Configuration string from web.config
        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;

        //Stored Procedure List
        string spSaveGame = "[DBO].[SP_SaveGame]";
        string spLoadGame = "[DBO].[SP_LoadGame]";
        string sp_GetThreeSavedGamesByUserID = "[DBO].[SP_GetThreeSavedGamesByUserID]";



        public bool SaveGame(int userID, string boardJsonString)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spSaveGame, conn))
                {

                    SqlParameter isSuccessful = new SqlParameter("@AddSucceeded", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameString", boardJsonString);
                    cmd.Parameters.AddWithValue("@userId", userID);
                    cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
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
                        Debug.WriteLine("Exception:" + ex.Message);
                    }
                    return false;

                }
            }
        }

        public string LoadGame(int gameID)
        {
            string boardJsonString = "";
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spLoadGame, conn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", gameID);


                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                        {
                            boardJsonString = reader["GameString"].ToString();
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
            return boardJsonString;
        }

        public List<GameObject> GetThreeSavedGamesByUserID(int userID)
        {
            List<GameObject> gamesList = new List<GameObject>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(sp_GetThreeSavedGamesByUserID, conn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userID);


                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            GameObject gameObject = new GameObject();
                            gameObject.Id = Convert.ToInt32(reader["id"].ToString());
                            gameObject.DateCreated = reader["DateCreated"].ToString();
                            gamesList.Add(gameObject);
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
            return gamesList;


        }
    }
}