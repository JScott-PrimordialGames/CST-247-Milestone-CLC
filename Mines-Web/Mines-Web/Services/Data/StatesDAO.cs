﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mines_Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Mines_Web.Services.Data
{
    public class StatesDAO
    {

        //Configuration string from web.config
        string connectionStr = ConfigurationManager.ConnectionStrings["MinesApp"].ConnectionString;

        //Stored Procedures
        string spGetStates = "[DBO].[SP_GetStates]";

        public List<StateModel> GetStates()
        {
            List<StateModel> stateList = new List<StateModel>();
            using(SqlConnection conn = new SqlConnection(connectionStr))
            {
                using(SqlCommand cmd = new SqlCommand(spGetStates, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            StateModel state = new StateModel();
                            state.StateCode = reader["StateCode"].ToString();
                            state.State = reader["State"].ToString();
                            stateList.Add(state);
                        }
                        reader.Close();
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Console.Error.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Exception:");
                        Console.Error.WriteLine(ex.Message);
                    }
                }
            }
            return stateList;
        }
    }
}