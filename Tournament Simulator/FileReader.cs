using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Simulator
{
    class FileReader
    {
        string fileName;
        List<Team> teams = new List<Team>();

        public FileReader(string file)
        {
            this.fileName = file;
        }

        public List<Team> ReadFile()
        {
            StreamReader input = null;
            List<string> lines = new List<string>(); //List for all raw input lines
            string line = null;

            try
            {
                //Open the CSV file
                input = File.OpenText(fileName);
                Console.WriteLine("CSV file opened.");
                //Throw away the first line
                string trash = input.ReadLine();

                //Continue to read the lines of data
                line = input.ReadLine();

                while (line != null)
                {
                    //Console.WriteLine("Read line: " + line);
                    lines.Add(line);
                    line = input.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (input != null)
                {
                    input.Close();
                    //Console.WriteLine("Input File closed.");
                }
            }
            //lines list now contains all of the lines except for the column titles
            for (int i = 0; i < lines.Count; i++)
            {
                //Find the comma delineator
                int location = lines[i].IndexOf(',');
                //Console.WriteLine("The first comma is located at index " + location);

                string teamName = lines[i].Substring(0, location);
                string teamRating = lines[i].Substring(location + 1);
                Team newTeam = new Team(teamName, Convert.ToInt16(teamRating));
                teams.Add(newTeam);
            }
            return teams;
        }
    }
}
