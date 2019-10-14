using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    public interface Kicker
    {
        void SetUpKicker(int[] ratings);
        double GetLegPower();
        double GetPuntingAim();
        double GetFieldGoalAim();
        double GetKickerOverall();
        double GetPunterOverall();
    }
}
