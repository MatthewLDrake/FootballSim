using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Field
    {
        private static Field instance;
        private FieldObject field;
        private int whoHasBall;
        private Team teamOne, teamTwo;
        public Player[] offensivePlayers, defensivePlayers;
        public Tuple<int, int>[] offensivePlayerLocations, defensivePlayerLocations;
        private BallLocation ball;
        private Field()
        {
            
        }
        public static Field GetInstance()
        {
            if (instance == null)
                instance = new Field();
            return instance;
        }
        public void SetTeams(Team teamOne, Team teamTwo)
        {
            this.teamOne = teamOne;
            this.teamTwo = teamTwo;
        }
        public PlayResult RunPlay(BallLocation ball, int lineToGain, OffensivePlay offensivePlay, DefensivePlay defensivePlay, bool teamOnePossesion)
        {
            field = new FieldObject(this);
            this.ball = ball;
            SetUpPlay(lineToGain, offensivePlay, defensivePlay, teamOnePossesion);
            

            if (offensivePlay.GetPlayType() != OffensivePlayType.PASS)
            {
                return DoRun(offensivePlay, defensivePlay);
            }
            else
            {
                return DoPass(offensivePlay, defensivePlay);
            }
        }
        private void SetUpPlay(int lineToGain, OffensivePlay offense, DefensivePlay defense, bool teamOnePossesion)
        {
            OffensiveFormation offensiveFormation = offense.GetFormation() as OffensiveFormation;
            offensivePlayers = offensiveFormation.GetPlayers(teamOnePossesion ? teamOne.GetDepthChart() : teamTwo.GetDepthChart());
            DefensiveFormation defensiveFormation = defense.GetFormation() as DefensiveFormation;
            defensivePlayers = defensiveFormation.GetPlayers(teamOnePossesion ? teamTwo.GetDepthChart() : teamOne.GetDepthChart());

            offensivePlayerLocations = new Tuple<int, int>[11];
            defensivePlayerLocations = new Tuple<int, int>[11];
            for (int i = 0; i < offensivePlayerLocations.Length; i++)
            {
                offensivePlayerLocations[i] = new Tuple<int, int>(-1, -1);
                defensivePlayerLocations[i] = new Tuple<int, int>(-1, -1);
            }

            int midPoint = ball.GetWidth();
            int lineOfScrimmage = ball.GetLength();

            field[lineOfScrimmage, midPoint] = 4;
            offensivePlayerLocations[3] = new Tuple<int, int>(lineOfScrimmage, midPoint);
            field[lineOfScrimmage, midPoint - 3] = 3;
            field[lineOfScrimmage, midPoint - 6] = 2;
            field[lineOfScrimmage, midPoint + 3] = 5;
            field[lineOfScrimmage, midPoint + 6] = 6;

            EligibleRecieverLayout[] locations = offensiveFormation.GetLocations();

            List<int> leftTEs = new List<int>(), rightTEs = new List<int>(), leftWRs = new List<int>(), rightWRs = new List<int>(); 

            if(offensiveFormation.GetShotGun())
            {
                field[lineOfScrimmage - 15, midPoint] = 1;
                for(int i = 0; i < locations.Length; i++)
                {
                    if(locations[i].GetLocation() == EligibleLocation.BACKFIELD)
                    {
                        if (locations[i].GetLeft())
                            field[lineOfScrimmage - 15, midPoint - 3] = 7 + i;
                        else
                            field[lineOfScrimmage - 15, midPoint + 3] = 7 + i;
                    }
                    else
                    {
                        if(locations[i].GetPosition() == (int)Constants.WR)
                        {
                            if (locations[i].GetLeft())
                                leftWRs.Add(i);
                            else rightWRs.Add(i);
                        }
                        else
                        {
                            if (locations[i].GetLeft())
                                leftTEs.Add(i);
                            else rightTEs.Add(i);
                        }
                    }
                }
            }
            else
            {
                field[lineOfScrimmage - 3, midPoint] = 1;
                for(int i = 0; i < locations.Length; i++)
                {
                    if (locations[i].GetLocation() == EligibleLocation.BACKFIELD || locations[i].GetLocation() == EligibleLocation.CENTER_BACKFIELD)
                    {
                        int playerMidPoint;
                        if (locations[i].GetLocation() == EligibleLocation.CENTER_BACKFIELD)
                            playerMidPoint = midPoint;
                        else if (locations[i].GetLeft())
                            playerMidPoint = midPoint - 3;
                        else
                            playerMidPoint = midPoint + 3;

                        int playerLine;

                        if (locations[i].GetPosition() == 1)
                            playerLine = lineOfScrimmage - 15;
                        else
                            playerLine = lineOfScrimmage - 9;

                        field[playerLine, playerMidPoint] = 7 + i;
                    }
                    else
                    {
                        if (locations[i].GetPosition() == (int)Constants.WR)
                        {
                            if (locations[i].GetLeft())
                                leftWRs.Add(i);
                            else rightWRs.Add(i);
                        }
                        else
                        {
                            if (locations[i].GetLeft())
                                leftTEs.Add(i);
                            else rightTEs.Add(i);
                        }
                    }
                }
            }
            for (int i = 0; i < leftTEs.Count; i++ )
            {
                int playerMidPoint = midPoint - (i * 3 + 9);
                int playerLine;

                if (locations[leftTEs[i]].GetLocation() == EligibleLocation.ON_LINE)
                    playerLine = lineOfScrimmage;
                else
                    playerLine = lineOfScrimmage - 2;

                field[playerLine, playerMidPoint] = 7 + leftTEs[i];
            }
            for (int i = 0; i < rightTEs.Count; i++)
            {
                int playerMidPoint = midPoint + (i * 3 + 9);
                int playerLine;

                if (locations[rightTEs[i]].GetLocation() == EligibleLocation.ON_LINE)
                    playerLine = lineOfScrimmage;
                else
                    playerLine = lineOfScrimmage - 2;

                field[playerLine, playerMidPoint] = 7 + rightTEs[i];
            }
            for (int i = 0; i < leftWRs.Count; i++)
            {
                int num = i + 1;
                int playerMidPoint = (num * midPoint) / (leftWRs.Count + 1);//(num * midPoint) / (leftWRs.Count + num);

                int playerLine;

                if (locations[leftWRs[i]].GetLocation() == EligibleLocation.ON_LINE)
                    playerLine = lineOfScrimmage;
                else
                    playerLine = lineOfScrimmage - 2;

                field[playerLine, playerMidPoint] = 7 + leftWRs[i];
            }
            for (int i = 0; i < rightWRs.Count; i++)
            {
                int num = i + 1;
                int playerMidPoint = midPoint + (num * ((160 - midPoint)) / (rightWRs.Count + 1));

                int playerLine;

                if (locations[rightWRs[i]].GetLocation() == EligibleLocation.ON_LINE)
                    playerLine = lineOfScrimmage;
                else
                    playerLine = lineOfScrimmage - 2;

                field[playerLine, playerMidPoint] = 7 + rightWRs[i];
            }
            



            File.WriteAllText(fileName + ".txt", field.ToString());
            fileName++;

        }
        private static int fileName = 0;
        private PlayResult DoRun(OffensivePlay offense, DefensivePlay defense)
        {
            return null;
        }
        private RouteTypes[] routes;
        private PlayResult DoPass(OffensivePlay offense, DefensivePlay defense)
        {
            routes = new RouteTypes[5];
            bool playOver = false, first = true;
            while(!playOver)
            {
                for (int i = 0; i < 5; i++)
                {
                    routes[i] = RunRoute(offensivePlayers[i + 6], first ? offense.GetRoute(i) : routes[i]);
                }
                first = false;
            }
            return null;
        }

        private RouteTypes RunRoute(Player player, RouteTypes routeTypes)
        {
            double time = 0;
            while(time < .1)
            {
                List<Tuple<Direction, int, bool>> routePart = routeTypes.GetTuple();
            }

            
            throw new NotImplementedException();
        }
    }
    class FieldObject
    {
        private int[,] field, offenseEndZone, defenseEndZone;
        private Field theField;
        public FieldObject(Field theField)
        {
            this.theField = theField;
            field = new int[300, 160];
            offenseEndZone = new int[30, 160];
            defenseEndZone = new int[30, 160];
        }
        public int this[int i, int j]
        {
            get 
            {
                if (i < 0)
                    return offenseEndZone[i - 30, j];
                else if (i < 300)
                    return field[i, j];
                else
                    return defenseEndZone[i - 300, j];
            }
            set 
            {
                if (i < 0)
                    offenseEndZone[i - 30, j] = value;
                else if (i < 300)
                    field[i, j] = value;
                else
                    defenseEndZone[i - 300, j] = value;

                if(value > 0)
                {
                    theField.offensivePlayerLocations[value - 1].Item1 = i;
                    theField.offensivePlayerLocations[value - 1].Item2 = j;
                }
                else if(value < 0)
                {
                    theField.defensivePlayerLocations[Math.Abs(value) - 1].Item1 = i;
                    theField.defensivePlayerLocations[Math.Abs(value) - 1].Item2 = j;
                }
            }
        }
        public override string ToString()
        {
            string retVal = "";
            for (int i = 0; i < 30; i++ )
            {
                for(int j = 0; j < 160; j++)
                {
                    bool flag = false;
                    if (offenseEndZone[i, j] == 0)
                    {
                        retVal += flag ? "" : " ";
                        flag = false;
                    }
                    else if (offenseEndZone[i, j] > 0)
                    {
                        retVal += "" + theField.offensivePlayers[offenseEndZone[i, j] - 1].GetMainPosition().PadRight(2);
                        flag = true;
                    }
                    else
                    {
                        retVal += "" + theField.defensivePlayers[Math.Abs(offenseEndZone[i, j]) - 1].GetMainPosition().PadRight(2);
                        flag = true;
                    }
                }
                retVal += "\n";
            }
            for (int i = 0; i < 160; i++)
                retVal += "_";
            for (int i = 0; i < 300; i++)
            {
                bool flag = false;
                for (int j = 0; j < 160; j++)
                {
                    if (field[i, j] == 0)
                    {
                        retVal += flag ? "" : " ";
                        flag = false;                         
                    }
                    else if (field[i, j] > 0)
                    {
                        retVal += "" + theField.offensivePlayers[field[i, j] - 1].GetMainPosition().PadRight(2);
                        flag = true;
                    }
                    else
                    {
                        retVal += "" + theField.defensivePlayers[Math.Abs(field[i, j]) - 1].GetMainPosition().PadRight(2);
                        flag = true;
                    }
                }
                retVal += "\n";
            }
            for (int i = 0; i < 160; i++)
                retVal += "_";
            for (int i = 0; i < 30; i++)
            {
                bool flag = false;
                for (int j = 0; j < 160; j++)
                {
                    if (defenseEndZone[i, j] == 0)
                    {
                        retVal += flag ? "" : " ";
                        flag = false;
                    }
                    else if (defenseEndZone[i, j] > 0)
                    {
                        retVal += "" + theField.offensivePlayers[defenseEndZone[i, j] - 1].GetMainPosition().PadRight(2);
                        flag = true;
                    }
                    else
                    {
                        retVal += "" + theField.defensivePlayers[Math.Abs(defenseEndZone[i, j]) - 1].GetMainPosition().PadRight(2);
                        flag = true;
                    }
                }
                retVal += "\n";
            }
            return retVal;
        }
    }
    public class PlayResult
    {
        public bool turnover, touchdown;
        public BallLocation ball;
        public PlayResult(BallLocation ball, bool turnover, bool touchdown)
        {
            this.ball = ball;
            this.turnover = turnover;
            this.touchdown = touchdown;
        }
    }
    public class BallLocation
    {
        private int length, width;
        public BallLocation(int length, int width)
        {
            this.length = length;
            this.width = width;
        }
        public int GetLength()
        {
            return length;
        }
        public int GetWidth()
        {
            return width;
        }
        public void SetLocation(int length, int width)
        {            
            this.length = length;

            if (width < 70)
                this.width = 70;
            else if (width > 90)
                this.width = 90;
            else
                this.width = width;
        }

    }
}
