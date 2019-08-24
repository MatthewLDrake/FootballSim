using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public interface Thrower
    {
        void SetUpThrower();
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
        DUAL_THREAT, GUNSLINGER, POCKET_PASSER
    }
    public interface RouteRunner
    {
        void SetUpRouteRunner();
        double GetOpenCatching();
        double GetContestedCatching();
        double GetSpectacularCatching();
        double GetCutting();
        double GetRelease();
        double GetRouteRunningOverall();
    }
    public interface Blocker
    {
        void SetUpBlocker();
        double GetRunBlocking();
        double GetPassBlocking();
        double GetBlockerOverall();
    }
    public interface BallCarrier
    {
        void SetUpBallCarrier();
        double GetCarrying();
        double GetElusiveness();
        double GetBreakTackle();
        double GetBallCarrierVision();
        double GetBallCarrierDecision();
        double GetBallCarrierOverall();
    }
}
