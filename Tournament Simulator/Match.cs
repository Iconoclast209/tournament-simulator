using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Simulator
{
    class Match
    {
        Team firstTeam;
        Team secondTeam;
        Random random = new Random();


        public Match(Team teamOne, Team teamTwo)
        {
            firstTeam = teamOne;
            secondTeam = teamTwo;
        }

        public Team SimulateMatchAndReturnLoser()
        {

            //Simulate Match by comparing ratings of the two teams against a random number

            double a = secondTeam.Rating - firstTeam.Rating;
            double b = a / 600;
            //Console.WriteLine("ratings difference / 600 = " + b);
            double c = Math.Pow(10,b)+1;
            //Console.WriteLine("10^b + 1 = " + c);
            double probabilityOfFirstTeamWin = 1 / c;
            //double probabilityOfFirstTeamWin = (1 / (1 + (Math.Pow(10,((secondTeam.Rating - firstTeam.Rating) / 600)) ) ) );
            //Console.WriteLine("Probability of First Team Winning is:  " + probabilityOfFirstTeamWin.ToString());

            //Generate a random number that will be different for each match
            double comparison = 0;
            for (int i = 0; i < (firstTeam.Rating/3); i++)
            {
                comparison = random.NextDouble();
            }
            
            //Console.WriteLine("Random Comparison Value is:  " + comparison);

            if (probabilityOfFirstTeamWin >= comparison)
            {
                //Console.WriteLine("First Team, " + firstTeam.Name + ", wins!");
                return secondTeam;
            }
            else
            {
                //Console.WriteLine("Second Team, " + secondTeam.Name + ", wins!");
                return firstTeam;
            }
            
        }

    }
}
