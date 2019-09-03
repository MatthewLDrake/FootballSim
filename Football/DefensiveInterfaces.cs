using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    interface BaseDefender
    {
        void SetDefenderRatings(int[] ratings);
        double GetTackling();
        double GetBlockShedding();
        double GetPlayRecognition();
        double GetDefensiveReactions();
    }

    interface PassRush
    {
        void SetUpPassRusher(int[] ratings);
        double GetBullRush();
        double GetSwimRush();

    }

    interface Coverage
    {
        void SetUpCoverage(int[] ratings);
        double GetPressCoverage();
        double GetManCoverage();
        double GetZoneCoverage();
    }
}
