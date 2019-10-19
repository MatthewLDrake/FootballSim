using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public interface Thrower
    {
        void SetUpThrower(int[] ratings);
        ThrowingStyle GetThrowingStyle();
        double GetArmStrength();
        double GetShortAccuracy();
        double GetMiddleAccuarcy();
        double GetDeepAccuracy();
        double GetVision();
        double GetDecisionMaking();
        double GetThrowingOverall();
    }
    public enum ThrowingStyle
    {
        DUAL_THREAT = 0, GUNSLINGER = 1, POCKET_PASSER = 2, BALANCED = 3, NON_QB = -1
    }
    public interface RouteRunner
    {
        void SetUpRouteRunner(int[] ratings);
        double GetOpenCatching();
        double GetContestedCatching();
        double GetSpectacularCatching();
        double GetCutting();
        double GetRelease();
        double GetRouteRunningOverall();
    }
    public interface Blocker
    {
        void SetUpBlocker(int[] ratings);
        double GetRunBlocking();
        double GetPassBlocking();
        double GetBlockerOverall();
    }
    public interface BallCarrier
    {
        void SetUpBallCarrier(int[] ratings);
        double GetCarrying();
        double GetElusiveness();
        double GetBreakTackle();
        double GetBallCarrierVision();
        double GetBallCarrierDecision();
        double GetBallCarrierOverall();
    }
}
