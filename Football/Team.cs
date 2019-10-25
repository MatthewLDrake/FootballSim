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
        private List<Player> players;
        private Coach headCoach, offCoor, defCoor, stCoor;
        private DepthChart depthChart;
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
            depthChart = new DepthChart();

            players = new List<Player>();
        }
        public void AddPlayer(Player p)
        {
            players.Add(p);
            int i;
            switch(p.GetMainPosition())
            { 
                case "QB":

                    for (i = 0; i < depthChart.quarterbacks.Length && depthChart.quarterbacks[i] != null; i++);                        
                    if(i < depthChart.quarterbacks.Length)
                        depthChart.quarterbacks[i] = p;
                    break;
                case "HB":
                    for (i = 0; i < depthChart.halfbacks.Length && depthChart.halfbacks[i] != null; i++) ;
                    if (i < depthChart.halfbacks.Length)
                        depthChart.halfbacks[i] = p;
                    break;
                case "FB":
                    for (i = 0; i < depthChart.fullbacks.Length && depthChart.fullbacks[i] != null; i++) ;
                    if (i < depthChart.fullbacks.Length)
                        depthChart.fullbacks[i] = p;
                    break;
                case "TE":
                    for (i = 0; i < depthChart.tightEnds.Length && depthChart.tightEnds[i] != null; i++) ;
                    if (i < depthChart.tightEnds.Length)
                        depthChart.tightEnds[i] = p;
                    break;
                case "WR":
                    for (i = 0; i < depthChart.wideRecievers.Length && depthChart.wideRecievers[i] != null; i++) ;
                    if (i < depthChart.wideRecievers.Length)
                        depthChart.wideRecievers[i] = p;
                    break;
                case "LT":
                    for (i = 0; i < depthChart.leftTackles.Length && depthChart.leftTackles[i] != null; i++) ;
                    if (i < depthChart.leftTackles.Length)
                        depthChart.leftTackles[i] = p;
                    break;
                case "LG":
                    for (i = 0; i < depthChart.leftGuards.Length && depthChart.leftGuards[i] != null; i++) ;
                    if (i < depthChart.leftGuards.Length)
                        depthChart.leftGuards[i] = p;
                    break;
                case "C":
                    for (i = 0; i < depthChart.centers.Length && depthChart.centers[i] != null; i++) ;
                    if (i < depthChart.centers.Length)
                        depthChart.centers[i] = p;
                    break;
                case "RG":
                    for (i = 0; i < depthChart.rightGuards.Length && depthChart.rightGuards[i] != null; i++) ;
                    if (i < depthChart.rightGuards.Length)
                        depthChart.rightGuards[i] = p;
                    break;
                case "RT":
                    for (i = 0; i < depthChart.rightTackles.Length && depthChart.rightTackles[i] != null; i++) ;
                    if (i < depthChart.rightTackles.Length)
                        depthChart.rightTackles[i] = p;
                    break;
                case "RE":
                    for (i = 0; i < depthChart.rightEnds.Length && depthChart.rightEnds[i] != null; i++) ;
                    if (i < depthChart.rightEnds.Length)
                        depthChart.rightEnds[i] = p;
                    break;
                case "LE":
                    for (i = 0; i < depthChart.leftEnds.Length && depthChart.leftEnds[i] != null; i++) ;
                    if (i < depthChart.leftEnds.Length)
                        depthChart.leftEnds[i] = p;
                    break;
                case "DT":
                    for (i = 0; i < depthChart.defensiveTackles.Length && depthChart.defensiveTackles[i] != null; i++) ;
                    if (i < depthChart.defensiveTackles.Length)
                        depthChart.defensiveTackles[i] = p;
                    break;
                case "LOLB":
                    for (i = 0; i < depthChart.leftOutsideLinebackers.Length && depthChart.leftOutsideLinebackers[i] != null; i++) ;
                    if (i < depthChart.leftOutsideLinebackers.Length)
                        depthChart.leftOutsideLinebackers[i] = p;
                    break;
                case "MLB":
                    for (i = 0; i < depthChart.middleLinebackers.Length && depthChart.middleLinebackers[i] != null; i++) ;
                    if (i < depthChart.middleLinebackers.Length)
                        depthChart.middleLinebackers[i] = p;
                    break;
                case "ROLB":
                    for (i = 0; i < depthChart.rightOutsideLinebackers.Length && depthChart.rightOutsideLinebackers[i] != null; i++) ;
                    if (i < depthChart.rightOutsideLinebackers.Length)
                        depthChart.rightOutsideLinebackers[i] = p;
                    break;
                case "CB":
                    for (i = 0; i < depthChart.cornerBacks.Length && depthChart.cornerBacks[i] != null; i++) ;
                    if (i < depthChart.cornerBacks.Length)
                        depthChart.cornerBacks[i] = p;
                    break;
                case "FS":
                    for (i = 0; i < depthChart.freeSafeties.Length && depthChart.freeSafeties[i] != null; i++) ;
                    if (i < depthChart.freeSafeties.Length)
                        depthChart.freeSafeties[i] = p;
                    break;
                case "SS":
                    for (i = 0; i < depthChart.strongSafeties.Length && depthChart.strongSafeties[i] != null; i++) ;
                    if (i < depthChart.strongSafeties.Length)
                        depthChart.strongSafeties[i] = p;
                    break;
                case "K":
                    if (depthChart.kicker == null)
                        depthChart.kicker = p;
                    break;
                case "P":
                    if (depthChart.punter == null)
                        depthChart.punter = p;
                    break;

            }
        }
        public DepthChart GetDepthChart()
        {
            return depthChart;
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