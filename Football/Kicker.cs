using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    interface Kicker
    {
        void SetUpKicker();
        double GetLegPower();
        double GetPuntingAim();
        double GetFieldGoalAim();
        double GetKickerOverall();
        double GetPunterOverall();
    }
}
