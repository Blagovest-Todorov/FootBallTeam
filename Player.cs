using System;

namespace FootballTeam
{
    public class Player
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(
            string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {              
                ValidateStatValue(value, nameof(Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateStatValue(value, nameof(Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateStatValue(value, nameof(Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateStatValue(value, nameof(Passing));
                this.passing = value;
            }            
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateStatValue(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        public int GetSkillLevel => SkillLevel();

        private int SkillLevel() 
        {
            double countPlayerSkills = 5.0;
            return (int)Math.Round(
            (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting)
                 / countPlayerSkills );
        }
        private void ValidateStatValue(int value, string propertyName)
        {
            if (value < MinStatValue || value > MaxStatValue)
            {
                throw new ArgumentException(
               $"{propertyName} should be between {MinStatValue} and {MaxStatValue}.");
            }
        }
    }
}
