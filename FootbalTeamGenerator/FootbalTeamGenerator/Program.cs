﻿using System;
using System.Collections.Generic;

namespace FootbalTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input = Console.ReadLine();


            while (input != "END")
            {
                try
                {
                    string[] inputInfo = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    if (inputInfo[0].ToLower() == "team")
                    {
                        string name = inputInfo[1];
                        Team team = new Team(name);
                        teams.Add(name, team);
                    }
                    else if (inputInfo[0].ToLower() == "add")
                    {
                        //•	"Add;{TeamName};{PlayerName};
                        //{Endurance};{Sprint};{Dribble};{Passing};{Shooting}"

                        string teamName = inputInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }
                        string playerName = inputInfo[2];
                        int endurance = int.Parse(inputInfo[3]);
                        int sprint = int.Parse(inputInfo[4]);
                        int dribble = int.Parse(inputInfo[5]);
                        int passing = int.Parse(inputInfo[6]);
                        int shooting = int.Parse(inputInfo[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble
                            , passing, shooting);

                        teams[teamName].AddPlayer(player);
                    }
                    else if (inputInfo[0].ToLower() == "remove")
                    {
                        string teamName = inputInfo[1];
                        string playerName = inputInfo[2];

                        bool removed = teams[teamName].RemovePlayer(playerName);

                        if (!removed)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }

                    }
                    else if (inputInfo[0].ToLower() == "rating")
                    {
                        string teamName = inputInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teams[teamName].Stats}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
