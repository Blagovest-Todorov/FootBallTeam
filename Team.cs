using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam
{
    public class Team
    {
        private string name;
        private readonly List<Player>players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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

        public double GetTeamRating => this.TeamRating();
        public void AddPlayer(Player player) 
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(pl => pl.Name == playerName);

            if (player is null)
            {
               throw new InvalidOperationException(
                   $"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(player);
        }

        private int TeamRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            var rating = players.Sum(pl => pl.GetSkillLevel);
            
            var teamRating = rating / players.Count;
            return teamRating; // TeamRating  = SumPlayersRating / countPlayers

            //int resRating = default;
            //foreach (var player in players)
            //{
            //    rating += player.GetSkillLevel;
            //}
        }
    }
}
