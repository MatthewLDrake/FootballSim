using System;
using System.Collections.Generic;

namespace Football
{
    public class Team : IComparable<Team>
    {
        private string teamName;
        private int pointsFor, pointsAgainst, teamNum, superBowlWins, superBowlLosses;
        private Record record, allTimeRecord, playoffRecord;
        private List<Record> seasonRecordVsTeam,allTimeRecordvsTeam;
        public Team(string name)
        {
            teamName = name;
            record = new Record();
            allTimeRecord = new Record();
            playoffRecord = new Record();

            seasonRecordVsTeam = new List<Record>();
            allTimeRecordvsTeam = new List<Record>();

            for(int i = 0; i < 32; i++)
            {
                seasonRecordVsTeam.Add(new Record());
                allTimeRecordvsTeam.Add(new Record());
            }

        }
        public int GetTeamNum()
        {
            return teamNum;
        }
        public void SetTeamNum(int teamNum)
        {
            this.teamNum = teamNum;
        }
        public override string ToString()
        {
            return teamName;
        }
        public string GetResult()
        {
            string tie = "";
            if (record.GetTies() != 0)
                tie = "-" + record.GetTies();

            return teamName +" (" + record.GetWins() + "-" + record.GetLosses() + tie + ")";
        }
        public string GetFranchiseResult()
        {
            return teamName + "," + allTimeRecord.GetWins() + "," + allTimeRecord.GetLosses() + "," + allTimeRecord.GetTies() + "," + superBowlWins + "," + superBowlLosses + "\n";
        }
        public void AddResult(Team opponent, int score, int opposingScore)
        {
            pointsFor += score;
            pointsAgainst += opposingScore;
            if (score > opposingScore)
            {
                record.AddWin();
                seasonRecordVsTeam[opponent.teamNum].AddWin();
            }
            else if (score < opposingScore)
            {
                record.AddLoss();
                seasonRecordVsTeam[opponent.teamNum].AddLoss();
            }
            else
            {
                record.AddTie();
                seasonRecordVsTeam[opponent.teamNum].AddTie();
            }
            
        }
        public void AddPlayoffResult(Team opponent, int score, int opposingScore, bool superBowl = false)
        {
            if (score > opposingScore)
            {
                playoffRecord.AddWin();
                if (superBowl)
                    superBowlWins++;
            }
            else
            {
                playoffRecord.AddLoss();
                if (superBowl)
                    superBowlLosses++;
            }
            
        }
        public int GetTies()
        {
            return record.GetTies();
        }
        public int GetWins()
        {
            return record.GetWins();
        }
        public int GetFranchiseWins()
        {
            return allTimeRecord.GetWins();
        }
        public int GetFranchiseLosses()
        {
            return allTimeRecord.GetLosses();
        }
        public int GetFranchiseTies()
        {
            return allTimeRecord.GetTies();
        }
        public int GetLosses()
        {
            return record.GetLosses();
        }
        public void ResetSeason()
        {
            allTimeRecord.AddWins(record.GetWins());
            allTimeRecord.AddLosses(record.GetLosses());
            allTimeRecord.AddTies(record.GetTies());
            record = new Record();

            for (int i = 0; i < 32; i++)
            {
                allTimeRecordvsTeam[i].AddWins(seasonRecordVsTeam[i].GetWins());
                allTimeRecordvsTeam[i].AddLosses(seasonRecordVsTeam[i].GetLosses());
                allTimeRecordvsTeam[i].AddTies(seasonRecordVsTeam[i].GetTies());
                seasonRecordVsTeam[i] = new Record();
            }

        }

        public int CompareTo(Team other)
        {
            if(GetWins() == other.GetWins())
            {
                int result = seasonRecordVsTeam[other.teamNum].GetResult();
                if (result == 0)
                {
                    if(pointsFor == other.pointsFor)
                    {
                        return other.pointsAgainst - pointsAgainst;
                    }
                    return other.pointsFor - pointsFor;
                }
                return result;
            }
            else
            {
                return other.GetWins() - GetWins();
            }
        }
    }
}