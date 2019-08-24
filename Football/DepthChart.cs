using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    class DepthChart
    {
        private Player[] quarterbacks, halfbacks, fullbacks, wideRecievers, tightEnds, leftTackles, leftGuards, centers, rightGuards, rightTackles, leftEnds, defensiveTackles, rightEnds, leftOutsideLinebackers, middleLinebackers, rightOutsideLinebackers, cornerBacks, strongSafeties, freeSafeties;
        private Player punter, kicker;
        public DepthChart()
        {
            quarterbacks = new Player[3];
            halfbacks = new Player[4];
            fullbacks = new Player[2];
            wideRecievers = new Player[6];
            tightEnds = new Player[3];
            leftTackles = new Player[3];
            leftGuards = new Player[3];
            centers = new Player[3];
            rightGuards = new Player[3];
            rightTackles = new Player[3];
            leftEnds = new Player[3];
            defensiveTackles = new Player[4];
            rightEnds = new Player[3];
            leftOutsideLinebackers = new Player[3];
            middleLinebackers = new Player[4];
            rightOutsideLinebackers = new Player[3];
            cornerBacks = new Player[6];
            strongSafeties = new Player[3];
            freeSafeties = new Player[3];
        }
    }
}
