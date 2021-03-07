using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsToSimulate = 1000;
            List<Team> teamList = new List<Team>();
            List<Team> winHistory = new List<Team>();

            Console.WriteLine("Enter input filename including file extension:  ");
            string inputFilename = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            FileReader fileReader = new FileReader(inputFilename);
            teamList = fileReader.ReadFile();

            //Simulate Tournaments
            for (int i = 0; i < tournamentsToSimulate; i++)
            {
                Tournament tourney = new Tournament(teamList);
                Team winner = tourney.SimulateTournament();
                if (winHistory.Contains(winner))
                {
                    winner.NumberOfWins += 1;
                }
                else
                {
                    winHistory.Add(winner);
                    winner.NumberOfWins = 1;
                }
            }

            //winHistory.Sort(); Sort List by NumberOfWins, highest first

            foreach (Team team in winHistory)
            {
                Console.WriteLine(team.Name + " has " + team.NumberOfWins + " win(s).");
            }


            Console.WriteLine("Hit any key to exit.");
            Console.ReadKey();
        }
    }
}
