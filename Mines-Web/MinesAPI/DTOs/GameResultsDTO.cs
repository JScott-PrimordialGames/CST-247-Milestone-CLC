using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using MinesAPI.Models;

namespace MinesAPI.DTOs
{
    [DataContract]
    public class GameResultsDTO
    {
        [DataMember]
        public int ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public List<GameResultsModel> GameResults {get;set;}
    }
}