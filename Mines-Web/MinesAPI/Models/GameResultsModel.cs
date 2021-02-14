using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MinesAPI.Models
{
    [DataContract]
    public class GameResultsModel
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public List<GameScoresModel> GameScores { get; set; }
    }
}