using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public partial class Player : Thrower
    {
        private int armStrength, shortArmAccuracy, middleArmAccuracy, deepArmAccuracy, vision, decisionMaking;
        private ThrowingStyle style;

        public void SetUpThrower(int[] ratings)
        {
            armStrength = ratings[0];
            shortArmAccuracy = ratings[1];
            middleArmAccuracy = ratings[2];
            deepArmAccuracy = ratings[3];
            vision = ratings[4];
            decisionMaking = ratings[5];
            style = (ThrowingStyle)ratings[6];
        }
        public ThrowingStyle GetThrowingStyle()
        {
            return style;
        }

        public double GetArmStrength()
        {
            return armStrength;
        }

        public double GetShortAccuracy()
        {
            return shortArmAccuracy;
        }

        public double GetMiddleAccuarcy()
        {
            return middleArmAccuracy;
        }

        public double GetDeepAccuracy()
        {
            return deepArmAccuracy;
        }

        public double GetVision()
        {
            return vision;
        }

        public double GetDecisionMaking()
        {
            return decisionMaking;
        }

        public double GetThrowingOverall()
        {
            throw new NotImplementedException();
        }
    }
    public partial class Player : RouteRunner
    {
        private int openCatching, contestedCatching, spectacularCatching, cutting, release;
        public void SetUpRouteRunner(int[] ratings)
        {
            openCatching = ratings[0];
            contestedCatching = ratings[1];
            spectacularCatching = ratings[2];
            cutting = ratings[3];
            release = ratings[4];
        }
        public double GetOpenCatching()
        {
            return openCatching;
        }

        public double GetContestedCatching()
        {
            return contestedCatching;
        }

        public double GetSpectacularCatching()
        {
            return spectacularCatching;
        }

        public double GetCutting()
        {
            return cutting;
        }

        public double GetRelease()
        {
            return release;
        }

        public double GetRouteRunningOverall()
        {
            throw new NotImplementedException();
        }
    }
    public partial class Player : BallCarrier
    {
        private int carrying, elusiveness, breakTackle, ballCarrierVision, ballCarrierDecision;
        public void SetUpBallCarrier(int[] ratings)
        {
            carrying = ratings[0];
            elusiveness = ratings[1];
            breakTackle = ratings[2];
            ballCarrierVision = ratings[3];
            ballCarrierDecision = ratings[4];
        }
        public double GetCarrying()
        {
            return carrying;
        }
        public double GetElusiveness()
        {
            return elusiveness;
        }
        public double GetBreakTackle()
        {
            return breakTackle;
        }
        public double GetBallCarrierVision()
        {
            return ballCarrierVision;
        }
        public double GetBallCarrierDecision()
        {
            return ballCarrierDecision;
        }
        public double GetBallCarrierOverall()
        {
            throw new NotImplementedException();
        }
    }
    public partial class Player : Blocker
    {
        private int runBlocking, passBlocking;
        public void SetUpBlocker(int[] ratings)
        {
            runBlocking = ratings[0];
            passBlocking = ratings[1];
        }

        public double GetRunBlocking()
        {
            return runBlocking;
        }

        public double GetPassBlocking()
        {
            return passBlocking;
        }

        public double GetBlockerOverall()
        {
            throw new NotImplementedException();
        }
    }
}
