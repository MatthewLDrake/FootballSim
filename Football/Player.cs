using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    public partial class Player : IComparable<Player>
    {
        private int overallComparer;
        private int speedRating, accelerationRating, strengthRating, jumpRating, height, weight;
        private string name;
        // This is the base player
        public Player(String name, int[] ratings, int height, int weight)
        {
            this.name = name;
            speedRating = ratings[0];
            accelerationRating = ratings[1];
            strengthRating = ratings[2];
            jumpRating = ratings[3];


            SetUpKicker(ratings.Skip(4).Take(3).ToArray());
            SetUpThrower(ratings.Skip(7).Take(7).ToArray());
            SetUpRouteRunner(ratings.Skip(14).Take(5).ToArray());
            SetUpBallCarrier(ratings.Skip(19).Take(5).ToArray());
            SetUpBlocker(ratings.Skip(24).Take(2).ToArray());
            SetDefenderRatings(ratings.Skip(26).Take(4).ToArray());
            SetUpPassRusher(ratings.Skip(30).Take(2).ToArray());
            SetUpCoverage(ratings.Skip(32).Take(3).ToArray());
        }
        public void SetOverallComparer(int value)
        {
            overallComparer = value;
        }

        public int CompareTo(Player other)
        {
            double num = 0;
            switch (overallComparer)
            {
                case 0:
                    num = other.GetKickerOverall() - GetKickerOverall();
                    break;
                case 1:
                    num = other.GetThrowingOverall() - GetThrowingOverall();
                    break;
                case 2:
                    num = other.GetRouteRunningOverall() - GetRouteRunningOverall();
                    break;
            }

            if (num > 0) return 1;
            else if (num == 0) return 0;
            else return -1;
        }
    }
    public partial class Player : Kicker
    {
        private int legStrength, puntingAim, fieldGoalAim;
        public void SetUpKicker(int[] ratings)
        {
            legStrength = ratings[0];
            puntingAim = ratings[1];
            fieldGoalAim = ratings[2];
        }

        public double GetLegPower()
        {
            return legStrength;
        }

        public double GetPuntingAim()
        {
            return puntingAim;
        }

        public double GetFieldGoalAim()
        {
            return fieldGoalAim;
        }

        public double GetKickerOverall()
        {
            throw new NotImplementedException();
        }

        public double GetPunterOverall()
        {
            throw new NotImplementedException();
        }
    }    
}
