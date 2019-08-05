using System;
using System.Collections.Generic;

namespace Football
{
    public class Division
    {
        private List<Team> teams;
        private String name;
        public Division(String name)
        {
            teams = new List<Team>();
            this.name = name;
        }
        public void AddTeams(Team firstTeam, Team secondTeam, Team thirdTeam, Team fourthTeam)
        {
            teams.Add(firstTeam);
            teams.Add(secondTeam);
            teams.Add(thirdTeam);
            teams.Add(fourthTeam);
        }
        public Team GetTeamInPos(int pos)
        {
            return teams[pos];
        }
        public void OrderTeams()
        {
            teams.Sort();
        }
        public void OrderByFranchiseTeams()
        {
            Team[] orderedTeams = new Team[4];

            for(int i = 0; i < orderedTeams.Length; i++)
            {
                int maxWins = 0, maxTies = 0;
                Team bestTeam = null;
                foreach(Team team in teams)
                {
                    if(team.GetFranchiseWins() > maxWins)
                    {
                        bestTeam = team;
                        maxWins = team.GetFranchiseWins();
                        maxTies = team.GetFranchiseTies();
                    }
                    else if(team.GetFranchiseWins() == maxWins)
                    {
                        if(team.GetFranchiseTies() > maxTies)
                        {
                            bestTeam = team;
                            maxWins = team.GetFranchiseWins();
                            maxTies = team.GetFranchiseTies();
                        }
                    }
                }
                orderedTeams[i] = bestTeam;
                teams.Remove(bestTeam);
            }
            foreach (Team team in orderedTeams)
                teams.Add(team);

        }
        public void PrintResults()
        {
            OrderTeams();

            Console.WriteLine(name + " Results\n______________________________");
            Console.WriteLine("01. " + teams[0].GetResult());
            Console.WriteLine("02. " + teams[1].GetResult());
            Console.WriteLine("03. " + teams[2].GetResult());
            Console.WriteLine("04. " + teams[3].GetResult() + "\n\n");

        }
        public string GetFranchiseResults()
        {
            OrderByFranchiseTeams();

            string 
        }
        public Team GetDivisionWinner()
        {
            return teams[0];
        }
        public List<Team> GetWildCards()
        {
            List<Team> retVal = new List<Team>
            {
                teams[1],
                teams[2]
            };
            return retVal;
        }
    }
}