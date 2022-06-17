﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootbalTeamGenerator
{
    public class Player
    {
        private readonly int endurance;
        private readonly int sprint;
        private readonly int dribble;
        private readonly int shooting;
        private readonly int passing;
        private string name;


        public Player(
            string name, 
            int endurance, 
            int sprint, 
            int dribble, 
            int passing,
            int shooting)
        {
            this.Name = name;

            ValidateStats("Endurance", endurance); 
            ValidateStats("Spirnt", sprint); 
            ValidateStats("Dribble", dribble); 
            ValidateStats("Passing", passing); 
            ValidateStats("Shooting", shooting); 

            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }

        public double Stats
            => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;


        private void ValidateStats(string name, int endurance)
        {
            if (endurance < 0 || endurance > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
