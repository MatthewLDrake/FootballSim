using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    public partial class Player : IComparable<Player>
    {
        private int overallComparer;
        // This is the base player
        public Player()
        {
            SetUpKicker();
            SetUpThrower();
            SetUpRouteRunner();
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
        public void SetUpKicker()
        {
            
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
