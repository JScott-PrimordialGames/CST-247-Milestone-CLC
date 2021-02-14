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

        string spGetAllGameScores = "[dbo].[SP_GetAllGameScores]";
        string spGetGameScoresForUser = "[dbo].[SP_GetGameResultsForUser]";
        string spDoesUserExist = "[dbo].[SP_DoesUserExist]";
        string spGetGameResultsForUserAndGameDifficulty = "[dbo].[SP_GetGameResultsForUserAndGameDifficulty]";

        public List<GameResultsModel> GetAllUsers(int limit = 0)
        {
            List<GameResultsModel> allScores = new List<GameResultsModel>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spGetAllGameScores, conn))
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

        public List<GameResultsModel> GetGameResultsByUser(int userId)
        {
            List<GameResultsModel> allScores = new List<GameResultsModel>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spGetGameScoresForUser, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            
                            GameResultsModel gameResults = new GameResultsModel();
                            gameResults.UserId = Convert.ToInt32(reader["USERID"].ToString());
                            gameResults.UserName = reader["USERNAME"].ToString();
                            
                            GameScoresModel gameScore = new GameScoresModel();
                            gameScore.Difficulty = reader["DIFFICULTY"].ToString();
                            gameScore.Score = float.Parse(reader["SCORE"].ToString());

                            gameResults.GameScores = new List<GameScoresModel>();
                            gameResults.GameScores.Add(gameScore);

                            while (reader.Read())
                            {
                                gameScore = new GameScoresModel();
                                gameScore.Difficulty = reader["DIFFICULTY"].ToString();
                                gameScore.Score = float.Parse(reader["SCORE"].ToString());

                                gameResults.GameScores.Add(gameScore);
                            }

                            allScores.Add(gameResults);
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

        public bool DoesUserExist(int userId)
        {

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spDoesUserExist, conn))
                {
                    SqlParameter doesExist = new SqlParameter("@UserExists", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.Add(doesExist);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if (Convert.ToInt32(doesExist.Value) == 1)
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

        public List<GameResultsModel> GetGameResultsByUserAndGameDifficulty(int userId, int difficulty)
        {
            List<GameResultsModel> allScores = new List<GameResultsModel>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spGetGameResultsForUserAndGameDifficulty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Difficulty", difficulty);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            GameResultsModel gameResults = new GameResultsModel();
                            gameResults.UserId = Convert.ToInt32(reader["USERID"].ToString());
                            gameResults.UserName = reader["USERNAME"].ToString();

                            GameScoresModel gameScore = new GameScoresModel();
                            gameScore.Difficulty = reader["DIFFICULTY"].ToString();
                            gameScore.Score = float.Parse(reader["SCORE"].ToString());

                            gameResults.GameScores = new List<GameScoresModel>();
                            gameResults.GameScores.Add(gameScore);

                            while (reader.Read())
                            {
                                gameScore = new GameScoresModel();
                                gameScore.Difficulty = reader["DIFFICULTY"].ToString();
                                gameScore.Score = float.Parse(reader["SCORE"].ToString());

                                gameResults.GameScores.Add(gameScore);
                            }

                            allScores.Add(gameResults);
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