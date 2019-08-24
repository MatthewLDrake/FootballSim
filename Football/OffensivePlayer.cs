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

        public void SetUpThrower()
        {

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
        public void SetUpRouteRunner()
        {

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
    public partial class Player : Blocker
    {
        private int runBlocking, passBlocking;
        public void SetUpBlocker()
        {
            
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
