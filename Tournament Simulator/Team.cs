using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Simulator
{
    class Team : IComparable<Team>
    {
        string name;
        int rating;
        int numberOfWins = 0;

        public Team(string name, int rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public int Rating { get => rating; set => rating = value; }
        public int NumberOfWins { get => numberOfWins; set => numberOfWins = value; }
        public string Name { get => name; set => name = value; }

        // Default comparer.
        public int CompareTo(Team team)
        {
            return team.NumberOfWins;
        }
    }
}
