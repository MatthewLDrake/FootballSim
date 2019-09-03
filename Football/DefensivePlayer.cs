using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public partial class Player : BaseDefender
    {
        private int blockShedding, defensiveReactions, playRecognition, tackling;
        public void SetDefenderRatings(int[] ratings)
        {
            blockShedding = ratings[0];
            defensiveReactions = ratings[1];
            playRecognition = ratings[2];
            tackling = ratings[3];
        }
        public double GetBlockShedding()
        {
            return blockShedding;
        }

        public double GetDefensiveReactions()
        {
            return defensiveReactions;
        }

        public double GetPlayRecognition()
        {
            return playRecognition;
        }

        public double GetTackling()
        {
            return tackling;
        }        
    }
    public partial class Player : PassRush
    {
        private int bullRush, swimRush;
        public void SetUpPassRusher(int[] ratings)
        {
            bullRush = ratings[0];
            swimRush = ratings[1];
        }
        public double GetBullRush()
        {
            return bullRush;
        }

        public double GetSwimRush()
        {
            return swimRush;
        }       
    }
    public partial class Player : Coverage
    {
        private int press, manCoverage, zoneCoverage;
        public void SetUpCoverage(int[] ratings)
        {
            press = ratings[0];
            manCoverage = ratings[1];
            zoneCoverage = ratings[2];
        }
        public double GetPressCoverage()
        {
            return press;
        }
        public double GetManCoverage()
        {
            return manCoverage;
        }
        public double GetZoneCoverage()
        {
            return zoneCoverage;
        }
    }
}
