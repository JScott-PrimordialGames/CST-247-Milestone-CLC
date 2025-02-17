﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MinesAPI.DTOs;

namespace MinesAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGameResultsService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetGameResults/{limit}")]
        GameResultsDTO GetGameResults(string limit);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetGameResultsForUser/{id}")]
        GameResultsDTO GetGameResultsForUser(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetGameResultsForUser/{id}/GameDifficulty/{difficulty}")]
        GameResultsDTO GetGameResultsForUserAndGameDifficulty(string id, string difficulty);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetGameResults/{limit}/GameDifficulty/{difficulty}")]
        GameResultsDTO GetGameResultsForGameDifficulty(string limit, string difficulty);
    }
}
