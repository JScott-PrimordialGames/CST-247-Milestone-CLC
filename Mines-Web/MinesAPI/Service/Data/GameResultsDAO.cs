using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Configuration;
using MinesAPI.Models;
using System.Data.SqlClient;

namespace MinesAPI.Service.Data
{
    public class GameResultsDAO
    {

        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;

        string spGetAllUsers = "[dbo].[SP_GetAllGameScores]";

        public List<GameResultsModel> GetAllUsers(int limit = 0)
        {
            List<GameResultsModel> allScores = new List<GameResultsModel>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spGetAllUsers, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RowsToReturn", limit);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                GameResultsModel gameResult = new GameResultsModel();
                                gameResult.UserId = Convert.ToInt32(reader["USERID"]);
                                gameResult.UserName = reader["USERNAME"].ToString();

                                GameScoresModel score = new GameScoresModel();
                                score.Score = float.Parse(reader["SCORE"].ToString());
                                score.Difficulty = reader["DIFFICULTY"].ToString();

                                gameResult.GameScores = new List<GameScoresModel>();
                                gameResult.GameScores.Add(score);

                                allScores.Add(gameResult);
                            }
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

            return allScores;
        }

    }
}