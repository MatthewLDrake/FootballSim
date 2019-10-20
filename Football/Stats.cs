using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class StatsHolder
    {
        private Stats stat;
        private Team team;
        public StatsHolder(Stats stat, Team team)
        {
            this.team = team;
            this.stat = stat;
        }
        public Team GetTeam()
        {
            return team;
        }
        public Stats GetStat()
        {
            return stat;
        }
    }
    public class Stats
    {
        public static List<Stats> GetTacklesByPlayer(Player p, List<StatsHolder> stats)
        {
            if (p == null)
                return null;
            List<Stats> retVal = new List<Stats>();
            foreach(StatsHolder stat in stats )
            {
                if(stat.GetStat() is Rush)
                {
                    Rush rush = stat.GetStat() as Rush;
                    if (p.Equals(rush.tackler))
                        retVal.Add(rush);
                }
                else if(stat.GetStat() is Reception)
                {
                    Reception reception = stat.GetStat() as Reception;
                    if (p.Equals(reception.tackler))
                        retVal.Add(reception);
                }
            }
            return retVal;
        }
    }
    public class Punts : Stats
    {
        public Kicker punter;
        public Player returner;
        public double yardsPunted, yardsReturned, hangTime;
        public int fairCaught, insideTwenty, touchDown, punts;
        public Punts(double yardsPunted, double yardsReturned, double hangTime, int fairCatches, int insideTwenty, int touchDowns, int punts = 0)
        {
            this.yardsPunted = yardsPunted;
            this.yardsReturned = yardsReturned;
            this.hangTime = hangTime;
            this.fairCaught = fairCatches;
            this.insideTwenty = insideTwenty;
            this.touchDown = touchDowns;
            this.punts = punts;
        }
        public Punts(int yardsPunted, int yardsReturned, double hangTime, bool fairCaught, bool insideTwenty, bool touchDown)
        {
            this.yardsPunted = yardsPunted;
            this.yardsReturned = yardsReturned;
            this.hangTime = hangTime;
            this.fairCaught = fairCaught ? 1 : 0;
            this.insideTwenty = insideTwenty ? 1 : 0;
            this.touchDown = touchDown ? 1 : 0;
        }
        public static Punts AddStats(List<Stats> list)
        {
            int fairCatches = 0, insideTwenties = 0, touchDowns = 0, punts = 0;
            double yardsPunted = 0.0, yardsReturned = 0.0, hangTimes = 0.0;

           foreach(Stats item in list)
            {
                if (item is Punts)
                {
                    Punts punt = item as Punts;
                    fairCatches += punt.fairCaught;
                    insideTwenties += punt.insideTwenty;
                    touchDowns += punt.touchDown;
                    punts++;
                    yardsPunted += punt.yardsPunted;
                    yardsReturned += punt.yardsReturned;
                    hangTimes += punt.hangTime;
                }

            }
            return new Punts(yardsPunted, yardsReturned, hangTimes, fairCatches, insideTwenties, touchDowns, punts);
           
        }
    }
    public class Reception : Stats
    {
        public Thrower quarterback;
        public RouteRunner catcher;
        public BaseDefender nearestDefender, tackler;
        public double yardsInAir, yardsAfterCatch;
        public int completions, attempts, interceptions, touchdowns;

        public Reception(Thrower quarterback, RouteRunner catcher, BaseDefender defender, BaseDefender tackler, double yardsInAir, double yardsAfterCatch, bool completion, bool interception, bool touchdown)
        {
            this.quarterback = quarterback;
            this.catcher = catcher;
            this.tackler = tackler;
            this.nearestDefender = defender;
            this.yardsAfterCatch = yardsAfterCatch;
            this.yardsInAir = yardsInAir;
            completions = completion ? 1 : 0;
            interceptions = interception ? 1 : 0;
            touchdowns = touchdown ? 1 : 0;
            attempts = 1;
        }
        public Reception(int completions, int attempts, int interceptions, int touchdowns, double yardsInAir, double yardsAfterCatch)
        {
            quarterback = null;
            catcher = null;
            nearestDefender = null;
            this.completions = completions;
            this.attempts = attempts;
            this.interceptions = interceptions;
            this.yardsAfterCatch = yardsAfterCatch;
            this.yardsInAir = yardsInAir;
            this.touchdowns = touchdowns;
        }

        public static Reception AddStats(List<Stats> list)
        {
            int completions = 0, attempts = 0, interceptions = 0, touchdowns = 0;
            double yardsInAir = 0.0, yardsAfterCatch = 0.0;
            foreach (Stats value in list)
            {
                if (value is Reception)
                {
                    Reception item = value as Reception;
                    completions += item.completions;
                    attempts += item.attempts;
                    interceptions += item.interceptions;
                    yardsInAir += item.yardsInAir;
                    yardsAfterCatch += item.yardsAfterCatch;
                    touchdowns += item.touchdowns;
                }
            }
            return new Reception(completions, attempts, touchdowns, interceptions, yardsInAir, yardsAfterCatch);

        }


    }
    public class Rush : Stats
    {
        public BallCarrier rusher;
        public BaseDefender tackler;
        public int yards, yardsAfterContact, fumbles, touchdowns, attempts;
        public Rush(BallCarrier rusher, BaseDefender tackler, int yards, int yardsAfterContact, bool fumble, bool touchdown)
        {
            this.rusher = rusher;
            this.tackler = tackler;
            this.yards = yards;
            this.yardsAfterContact = yardsAfterContact;
            this.fumbles = fumble ? 1 : 0;
            this.touchdowns = touchdown ? 1 : 0;
            attempts = 1;
        }
        public Rush(int yards, int yardsAfterContact, int attempts, int fumbles, int touchdowns)
        {
            this.yards = yards;
            this.yardsAfterContact = yardsAfterContact;
            this.attempts = attempts;
            this.fumbles = fumbles;
            this.touchdowns = touchdowns;
        }
        public static Rush AddStats(List<Stats> list)
        {
            int yards = 0, yardsAfterContact = 0, attempts = 0, fumbles = 0, touchdowns = 0;

            foreach(Stats stat in list)
            {
                if(stat is Rush)
                {
                    Rush item = stat as Rush;
                    yards += item.yards;
                    yardsAfterContact += item.yardsAfterContact;
                    attempts += item.attempts;
                    fumbles += item.fumbles;
                    touchdowns += item.touchdowns;
                }
            }

            return new Rush(yards, yardsAfterContact, attempts, fumbles, touchdowns);
        }
    }
    public class Sack: Stats
    {
        public Thrower quarterBack;
        public BaseDefender sacker;
        public int yards, fumbles;
        public Sack(Thrower thrower, BaseDefender defender, int yards, bool fumble)
        {
            fumbles = fumble ? 1 : 0;
            this.yards = yards;
            sacker = defender;
            quarterBack = thrower;
        }
        public Sack(Thrower thrower, BaseDefender defender, int yards, int fumbles)
        {
            this.fumbles = fumbles;
            this.yards = yards;
            sacker = defender;
            quarterBack = thrower;
        }
    }
}
