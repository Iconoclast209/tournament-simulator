using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Simulator
{
    class Tournament
    {
        public List<Team> startingTeams;
        List<Team> winningTeams;
        Team winningTeam;
        Random random = new Random();

        public Tournament(List<Team> listOfTeams)
        {
            this.startingTeams = listOfTeams;
            winningTeams = new List<Team>();
        }
    
        public Team SimulateTournament()
        {
            //At the beginning of the tournament, all teams are added to the winners list.
            foreach (Team team in startingTeams)
            {
                winningTeams.Add(team);
            }
            //winningTeams = startingTeams;
            
            //Simulate Rounds Until One Winner
            int round = 0;
            //Console.WriteLine(winningTeams.Count + " teams remaining.");

            while (winningTeams.Count > 1)
            {
                winningTeams = SimulateRound();
                round++;
                Console.WriteLine("Round " + round + " complete.");
            }
            return winningTeams[0];
        }

        private List<Team> SimulateRound()
        {
            //Create Matches for all the teams, then simulate match
            int matchesToSimulate = winningTeams.Count / 2;
            /*Console.WriteLine(matchesToSimulate + " matches to simulate in this round.");
            Console.WriteLine("The winning teams at the start of the round are:  ");
            for (int i = 0; i < winningTeams.Count; i++)
            {
                Console.WriteLine(winningTeams[i].Name);
            }*/

            List<Team> teamsRemainingInRound = new List<Team>();
            //teamsRemainingInRound = winningTeams;
            foreach (Team team in winningTeams)
            {
                teamsRemainingInRound.Add(team);
            }


            for (int i = 0; i < matchesToSimulate; i++)
            {
                //Pick two teams randomly
                int firstIndex = random.Next(teamsRemainingInRound.Count);
                int secondIndex = random.Next(teamsRemainingInRound.Count);
                
                //Make sure they are not the same index numbers
                while (firstIndex == secondIndex)
                {
                    //If they are the same index numbers, try again
                    //Console.WriteLine("Trying to find a better second team...");
                    secondIndex = random.Next(teamsRemainingInRound.Count);
                }

                Team firstTeam = teamsRemainingInRound[firstIndex];
                Team secondTeam = teamsRemainingInRound[secondIndex];

                // Create a new match
                Match currentMatch = new Match(firstTeam, secondTeam);
                //Remove teams that are playing the current match from the list of teams remaining in the round
                teamsRemainingInRound.Remove(firstTeam);
                teamsRemainingInRound.Remove(secondTeam);

                //Console.WriteLine(teamsRemainingInRound.Count + " teams remain in teamsInRound");

                //Simulate Match & Delete Loser from winning teams list
                Team losingTeam = currentMatch.SimulateMatchAndReturnLoser();
                

                /*Console.WriteLine("The winning teams prior to removal are:  ");
                for (int j = 0; j < winningTeams.Count; j++)
                {
                    Console.WriteLine(winningTeams[j].Name);
                }
                Console.WriteLine("Removing the losing team, " + losingTeam.Name);*/
                winningTeams.Remove(losingTeam);
                //Console.WriteLine(winningTeams.Count + " winning teams.");

                /*Console.WriteLine("The winning teams at the end of this match are:  ");
                for (int k = 0; k < winningTeams.Count; k++)
                {
                    Console.WriteLine(winningTeams[k].Name);
                }*/

            }
            
            /*Console.WriteLine("The winning teams at the end of this round are:  ");
            for (int i = 0; i < winningTeams.Count; i++)
            {
                Console.WriteLine(winningTeams[i].Name);
            }*/
            return winningTeams;

        }

    }
}
