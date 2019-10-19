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
        private BallLocation ball;
        private TempForm form;
        private int down, lineToGain;
        public Game(Team teamOne, Team teamTwo, bool playoffs = false, TempForm form = null)
        {
            this.teamOne = teamOne;
            this.teamTwo = teamTwo;

            this.playoffs = playoffs;

            teamOneScore = new int[5];
            teamTwoScore = new int[5];

            quarterTime = 60 * 15;
            quarter = 1;

            teamOnePossession = firstPos = Random.GetInstance().GetBool();

            

            this.form = form;

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
        public PassResult WideOpenCatch(int catchRating, int specCatchRating, PassType type)
        {
            double yards = Math.Abs(type.GetYards());
            if (type.OnTarget())
            {
                double num = -0.005300 * catchRating * catchRating + 1.165 * catchRating + 35;
                //double num = Math.pow(64.9746 * Math.E, 0.0042 * (100 - catchRating));
                int randNum = Random.GetInstance().Next(100);
                bool caught = num > randNum;
                if (!caught)
                    return PassResult.Incomplete;
                if (num - randNum > 15)
                    return PassResult.In_Stride;
                else
                    return PassResult.Slowed;
            }
            else if (yards < 1)
            {
                double rating = .75 * catchRating + .25 * specCatchRating;
                double num = 0.001000 * rating * rating + 0.7500 * rating + 10.00;
                int randNum = Random.GetInstance().Next(100);
                bool caught = num > randNum;
                if (!caught)
                    return PassResult.Incomplete;
                if (num - randNum > 25)
                    return PassResult.Slowed;
                else
                    return PassResult.Dove;
            }
            else if (yards < 3)
            {
                double num = 0.0;
                if (specCatchRating > 50)
                    num = 0.008200 * specCatchRating * specCatchRating - 0.33 * specCatchRating + 1;
                else
                    num = 0.0008000 * specCatchRating * specCatchRating + 0.04000 * specCatchRating + 1.000;
                int randNum = Random.GetInstance().Next(0, 100);
                bool caught = num > randNum;
                if (!caught)
                    return PassResult.Incomplete;
                else
                    if (num - randNum > 25)
                    return PassResult.Slowed;
                else
                    return PassResult.Dove;
            }
            return PassResult.Incomplete;
        }
        public static BlockingResult PassBlock(int passBlocking, int defenderMove, Blocker doubleTeam = null, Blocker chip = null)
        {
            if(doubleTeam == null && chip == null)
            {
                double rating = ((passBlocking - defenderMove) * 3.0 + Random.GetInstance().Next(-100, 101))/4.0;
                if (Math.Abs(rating) < 10)
                    return BlockingResult.Blocker_Average;
                else if (rating > 0 && rating < 25)
                    return BlockingResult.Blocker_Forward;
                else if (rating < 0 && rating > -25)
                    return BlockingResult.Blocker_Backward;
                else if (rating < 0)
                    return BlockingResult.Blocker_Pancaked;
                else
                    return BlockingResult.Pancake;
            }
            // Chip help
            else if(doubleTeam == null)
            {
                double chipRating = chip.GetPassBlocking();
            }
            // double team
            else
            {

            }
            
            return BlockingResult.None;
        }
        public static BlockingResult RunBlock(int runBlocking, int defenderMove, bool finesseMove, Blocker doubleTeam = null, Blocker chip = null)
        {
            if (doubleTeam == null && chip == null)
            {
                double rating = ((runBlocking - defenderMove) * 3.0 + Random.GetInstance().Next(-100, 101)) / 4.0;
                if (Math.Abs(rating) < 10)
                    return BlockingResult.Blocker_Average;
                else if (rating > 0 && rating < 25)
                    return BlockingResult.Blocker_Forward;
                else if (rating < 0 && rating > -25)
                    return BlockingResult.Blocker_Backward;
                else if (rating < 0)
                    return BlockingResult.Blocker_Pancaked;
                else
                    return BlockingResult.Pancake;
            }
            // Chip help
            else if (doubleTeam == null)
            {

            }
            // double team
            else
            {
                Random r = Random.GetInstance();
                double blocking = (doubleTeam.GetRunBlocking() + runBlocking)/1.75;
                if (finesseMove)
                    blocking -= defenderMove + (r.GetBool() ? defenderMove * .25 : 0);
                else
                    blocking -= defenderMove - (r.GetBool() ? defenderMove * .25 : 0);
                Console.WriteLine(blocking);
            }
            return BlockingResult.None;
        }
        

        private void PlayGame()
        {
            ball = new BallLocation(75, 80);
            down = 1;
            lineToGain = 105;

            while(quarterTime > 0)
                DoDrive(false);

            quarter++;
            quarterTime += 60 * 15;

            while (quarterTime > 0)
                DoDrive(true);

            ball = new BallLocation(75, 80);
            down = 1;
            lineToGain = 105;

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

            OffensivePlay offensivePlay = ChoosePlay();
            DefensivePlay defensivePlay = ChooseDefensivePlay(offensivePlay.GetFormation());

            SetUpPlay(offensivePlay.GetFormation(), defensivePlay.GetFormation());

            if(offensivePlay.GetType() != OffensivePlayType.PASS)
            {
                DoRun(offensivePlay, defensivePlay);
            }
            else
            {
                DoPass(offensivePlay, defensivePlay);
            }
        }

        private void SetUpPlay(Formation offensiveFormation, Formation defensiveFormation)
        {

        }

        private void DoRun(OffensivePlay offensivePlay, DefensivePlay defensivePlay)
        {

        }
        private void DoPass(OffensivePlay offensivePlay, DefensivePlay defensivePlay)
        {

        }


        private OffensivePlay ChoosePlay()
        {
            PlayBook book = PlayBook.GetInstance();
            OffensiveFormation offense = book.iFormTwoWR;
            switch(Random.GetInstance().Next(8))
            {
                case 0:
                    return offense.GetPlay("Dive Right");
                case 1:
                    return offense.GetPlay("Slam Right");
                case 2:
                    return offense.GetPlay("Stretch Right");
                case 3:
                    return offense.GetPlay("Pitch Right");
                case 4:
                    return offense.GetPlay("Dive Left");
                case 5:
                    return offense.GetPlay("Slam Left");
                case 6:
                    return offense.GetPlay("Stretch Left");
                case 7:
                    return offense.GetPlay("Pitch Left");                
            }
            return null;
            // TODO: Implement coach playcalling logic
        }
        private DefensivePlay ChooseDefensivePlay(Formation formation)
        {
            DefensiveFormation defense = PlayBook.GetInstance().fourThree;
            return defense.GetPlay("Cover Three");
            // TODO: Implement coach playcalling logic
        }
        /*private void DoDrive(bool endIfTimeExpires)
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
        }*/
    }
}
public class PassType
{
    private bool onTarget;
    private double yards;
    public PassType(bool onTarget, double yards)
    {
        this.onTarget = onTarget;
        this.yards = yards;
    }
    public bool OnTarget()
    {
        return onTarget;
    }
    public double GetYards()
    {
        return yards;
    }
}
public enum PassResult
{
    Interception, Incomplete, In_Stride, Slowed, Dove
}
public enum BlockingResult
{
    Pancake, Blocker_Forward, Blocker_Average, Blocker_Backward, Blocker_Pancaked, None
}