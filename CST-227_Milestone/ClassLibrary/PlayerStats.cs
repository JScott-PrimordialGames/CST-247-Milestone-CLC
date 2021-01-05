using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class PlayerStats : IComparable
    {
        public string Name { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public double DifficultyLevel { get; set; }
        public decimal Score { get; set; }

        public PlayerStats(string name, int difficultyLevel, TimeSpan timeElapsed, decimal score)
        {
            Name = name;
            DifficultyLevel = difficultyLevel;
            TimeElapsed = timeElapsed;
            Score = score; // calculate score
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            PlayerStats otherStats = obj as PlayerStats;
            if (otherStats != null)
                return this.Score.CompareTo(otherStats.Score);
            else
                throw new ArgumentException("Object is not stat");
        }

        // the string that represents the PlayerStats on the leaderboard
        public string Display()
        {
            return Name + "\t" + Score;
        }

        // create the string to represent the PlayerStats in the txt file
        public override string ToString()
        {
            return Name + "|" + DifficultyLevel.ToString() + "|" + TimeElapsed.ToString() + "|" + Score.ToString();
        }
    }
}
