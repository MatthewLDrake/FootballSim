using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Game
    {
        private double TO = .120, TD = .232, FG = .144;
        private double timeOfDrive = 166;
        private Team teamOne, teamTwo;
        private int[] teamOneScore, teamTwoScore;
        private int quarterTime, quarter;
        private bool teamOnePossession, firstPos, playoffs;
        public Game(Team teamOne, Team teamTwo, bool playoffs = false)
        {
            this.teamOne = teamOne;
            this.teamTwo = teamTwo;

            this.playoffs = playoffs;

            teamOneScore = new int[5];
            teamTwoScore = new int[5];

            quarterTime = 60 * 15;
            quarter = 1;

            teamOnePossession = firstPos = Random.GetInstance().GetBool();

            PlayGame();
        }
        public int GetTeamOneQuarterScore(int quarterNum)
        {
            return teamOneScore[quarterNum - 1];
        }
        public int GetTeamTwoQuarterScore(int quarterNum)
        {
            return teamTwoScore[quarterNum - 1];
        }
        public int GetTeamOneScore()
        {
            int retVal = 0;
            foreach (int num in teamOneScore)
                retVal += num;
            return retVal;
        }
        public int GetTeamTwoScore()
        {
            int retVal = 0;
            foreach (int num in teamTwoScore)
                retVal += num;
            return retVal;
        }
        private void PlayGame()
        {
            while(quarterTime > 0)
                DoDrive(false);

            quarter++;
            quarterTime += 60 * 15;

            while (quarterTime > 0)
                DoDrive(true);

            quarterTime = 60 * 15;
            quarter++;
            teamOnePossession = !firstPos;

            while (quarterTime > 0)
                DoDrive(false);

            quarter++;
            quarterTime += 60 * 15;

            while (quarterTime > 0)
                DoDrive(true);

            while(GetTeamOneScore() == GetTeamTwoScore())
            {
                quarter = 5;
                quarterTime = 60 * 10;

                DoDrive(true);
                if (Math.Abs(GetTeamOneScore() - GetTeamTwoScore()) == 7)
                    return;
                DoDrive(true);

                while (quarterTime > 0 && GetTeamOneScore() - GetTeamTwoScore() == 0)
                    DoDrive(true);

                if (!playoffs)
                    return;
            }

        }
        private void DoDrive(bool endIfTimeExpires)
        {
            Random r = Random.GetInstance();
            int timeTaken = (int)Math.Round(r.GetGaussian(timeOfDrive, 30));

            if(endIfTimeExpires && timeTaken > quarterTime)
            {
                quarterTime = 0;
                return;
            }

            double driveResult = r.GetDouble();
            double curr = 0;
            // TO happened
            if (curr + TO > driveResult)
            {
                bool isInt = r.GetDouble() < .625;
                if(isInt)
                {
                    if(r.GetDouble() < .3)
                    {
                        if (teamOnePossession)
                        {
                            teamTwoScore[quarter - 1] += 7;

                        }
                        else
                        {
                            teamOneScore[quarter - 1] += 7;
                        }
                    }
                    else
                    {
                        teamOnePossession = !teamOnePossession;
                    }
                }
                else
                {
                    if (r.GetDouble() < .05)
                    {
                        if (teamOnePossession)
                        {
                            teamTwoScore[quarter - 1] += 7;

                        }
                        else
                        {
                            teamOneScore[quarter - 1] += 7;
                        }
                    }
                    else
                    {
                        teamOnePossession = !teamOnePossession;
                    }
                }
            }
            else
            {
                curr += TO;
                // TD happened
                if (curr + TD > driveResult)
                {
                    if(teamOnePossession)
                    {
                        teamOneScore[quarter - 1] += 7;

                    }
                    else
                    {
                        teamTwoScore[quarter - 1] += 7;
                    }
                }
                else
                {
                    curr += TD;
                    //FG happened
                    if(curr + FG > driveResult)
                    {
                        if (teamOnePossession)
                        {
                            teamOneScore[quarter - 1] += 3;

                        }
                        else
                        {
                            teamTwoScore[quarter - 1] += 3;
                        }
                    }
                    else
                    {

                    }
                }
                teamOnePossession = !teamOnePossession;
            }





            quarterTime -= timeTaken;
        }
    }
}
