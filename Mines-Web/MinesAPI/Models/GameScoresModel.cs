using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MinesAPI.Models
{
    [DataContract]
    public class GameScoresModel
    {
        [DataMember]
        public string Difficulty { get; set; }
        [DataMember]
        public float Score { get; set; }
    }
}