using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Mines_Web.Services.Data
{
    public class ScoreDAO
    {
        //Configuration string from web.config
        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;

        //Stored Procedure List
        string spAddScore = "[DBO].[SP_AddScore]";


        public bool AddScore(int userId, float score, int difficulty)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(spAddScore, conn))
                {
                    SqlParameter isInserted = new SqlParameter("@InsertSucceeded", System.Data.SqlDbType.Bit) { Direction = System.Data.ParameterDirection.Output };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.Parameters.AddWithValue("@Difficulty", difficulty);
                    cmd.Parameters.Add(isInserted);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if (Convert.ToInt32(isInserted.Value) == 1)
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
    }
}