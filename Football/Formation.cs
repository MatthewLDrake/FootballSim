using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    enum Constants
    {// 0 = WR, 1 = HB, 2 = FB, 3 = TE
        TE = 3, HB = 1, WR = 0, FB = 2,
        // 0 = MLB, 1 = LOLB, 2 = ROLB, 3 = DT, 4 = RE, 5 = LE, 6 = CB, 7 = SS. 8 = FS
        MLB = 0, LOLB = 1, ROLB = 2, DT = 3, RE = 4, LE = 5, CB = 6, SS = 7, FS = 8
    }
    public interface Formation
    {        
        Player[] GetPlayers(DepthChart chart);
    }
    public class PlayBook
    {
        // IFormations, Strong and Weak
        public OffensiveFormation iFormTwoWR, iFormTwoTE, iFormTwinTE;
        // Single back and pistol
        public OffensiveFormation singleBackFourWR, singleBackBunch, singleBackTwoTE, singleBackTwinTE;

        public DefensiveFormation fourThree, fourFour, threeFour, nickel, nickelStrong, threeThreeFive, twoFourFive, dime, threeTwoSix, quarter, goalline;

        private static PlayBook instance;
        private PlayBook()
        {

            iFormTwoWR = new OffensiveFormation(new EligibleRecieverLayout[]{
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.FB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.TE, true, EligibleLocation.ON_LINE) }, PassPlays.GetIFormTwoWRPassPlays());

            iFormTwoTE = new OffensiveFormation(new EligibleRecieverLayout[]{
                 new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.OFF_LINE),             
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.FB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.TE, false, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.TE, true, EligibleLocation.ON_LINE) }, new Dictionary<String, OffensivePlay>()
            );

            iFormTwinTE = new OffensiveFormation(new EligibleRecieverLayout[]{
                 new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.ON_LINE),             
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.FB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.TE, false, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.TE, false, EligibleLocation.OFF_LINE) }, new Dictionary<String, OffensivePlay>()
            );

            singleBackFourWR = new OffensiveFormation(new EligibleRecieverLayout[]{                             
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.ON_LINE) }, new Dictionary<String, OffensivePlay>()
            );

            singleBackBunch = new OffensiveFormation(new EligibleRecieverLayout[]{                             
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.OFF_LINE, (int)Constants.TE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.ON_LINE) }, new Dictionary<String, OffensivePlay>()
            );

            singleBackTwoTE = new OffensiveFormation(new EligibleRecieverLayout[]{                             
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.TE, true, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, true, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.TE, false, EligibleLocation.ON_LINE) }, new Dictionary<String, OffensivePlay>()
            );

            singleBackTwinTE = new OffensiveFormation(new EligibleRecieverLayout[]{                             
            new EligibleRecieverLayout((int)Constants.HB, false, EligibleLocation.CENTER_BACKFIELD), 
            new EligibleRecieverLayout((int)Constants.TE, true, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout((int)Constants.TE, true, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout((int)Constants.WR, false, EligibleLocation.ON_LINE) }, new Dictionary<String, OffensivePlay>()
            );

            fourThree = new DefensiveFormation(2, 2, 3, 2, 2);
            fourFour = new DefensiveFormation(2, 1, 4, 2, 2);
            threeFour = new DefensiveFormation(2, 2, 4, 2, 1);
            nickel = new DefensiveFormation(3, 2, 2, 2, 2);
            threeThreeFive = new DefensiveFormation(3, 2, 3, 2, 1);
            twoFourFive = new DefensiveFormation(3, 2, 4, 2, 0);
            nickelStrong = new DefensiveFormation(2, 3, 2, 2, 2);
            threeTwoSix = new DefensiveFormation(4, 2, 2, 2, 1);
            dime = new DefensiveFormation(4, 2, 1, 2, 2);
            quarter = new DefensiveFormation(5, 2, 1, 2, 1);
            goalline = new DefensiveFormation(2, 1, 3, 2, 3);


        }
        public static PlayBook GetInstance()
        {
            if (instance == null)
                instance = new PlayBook();
            return instance;
        }
    }
    public class DefensiveFormation : Formation
    {
        private Dictionary<String, DefensivePlay> plays;
        private DefensivePlayerLayout[] players;
        public readonly int corners, safties, linebackers, ends, tackles;
        public DefensiveFormation(int corners, int safties, int linebackers, int ends, int tackles)
        {
            plays = new Dictionary<string, DefensivePlay>();
            this.corners = corners;
            this.safties = safties;
            this.linebackers = linebackers;
            this.ends = ends;
            this.tackles = tackles;

            players = new DefensivePlayerLayout[11];
            int loc = corners;
            // 0 = MLB, 1 = LOLB, 2 = ROLB, 3 = DT, 4 = RE, 5 = LE, 6 = CB, 7 = SS. 8 = FS
            for (int i = 0; i < corners; i++ )
            {
                players[i] = new DefensivePlayerLayout((int)Constants.CB);
            }
            for (int i = 0; i < safties; i++)
            {
                players[loc] = new DefensivePlayerLayout(i % 2 == 0 ? (int)Constants.SS : (int)Constants.FS);
                loc++;
            }
            if(linebackers > 2)
            {
                for (int i = 2; i < linebackers; i++)
                {
                    players[loc] = new DefensivePlayerLayout((int)Constants.MLB);
                    loc++;
                }
                players[loc] = new DefensivePlayerLayout((int)Constants.LOLB);
                loc++;
                players[loc] = new DefensivePlayerLayout((int)Constants.ROLB);
                loc++;
                
            }
            else if(linebackers == 2)
            {
                players[loc] = new DefensivePlayerLayout((int)Constants.MLB);
                loc++;
                players[loc] = new DefensivePlayerLayout((int)Constants.LOLB);
                loc++;
            }
            else if(linebackers == 1)
            {
                players[loc] = new DefensivePlayerLayout((int)Constants.MLB);
                loc++;
            }

            if(ends == 1)
            {
                players[loc] = new DefensivePlayerLayout((int)Constants.RE);
                loc++;
            }
            else if(ends == 2)
            {
                players[loc] = new DefensivePlayerLayout((int)Constants.RE);
                loc++;
                players[loc] = new DefensivePlayerLayout((int)Constants.LE);
                loc++;
            }

            for (int i = 0; i < tackles; i++ )
            {
                players[loc] = new DefensivePlayerLayout((int)Constants.DT);
                loc++;
            }


            plays.Add("Man Two Under", new DefensivePlay(DefensivePlayType.MAN_TWO_UNDER, this));
        }
        public DefensivePlay GetPlay(String name)
        {
            return plays[name];
        }
        public Player[] GetPlayers(DepthChart chart)
        {
            Player[] retVal = new Player[11];

            int mlbCount = 0, lolbCount = 0, rolbCount = 0, dtCount = 0, reCount = 0, leCount = 0, cbCount = 0, ssCount = 0, fsCount = 0;
            for (int i = 0; i < players.Length; i++)
            {
                Player temp;
                switch (players[i].GetPosition())
                {
                    //MLB = 0, LOLB = 1, ROLB = 2, DT = 3, RE = 4, LE = 5, CB = 6, SS = 7, FS = 8
                    case (int)Constants.MLB:
                        temp = chart.middleLinebackers[mlbCount++];
                        break;
                    case (int)Constants.LOLB:
                        temp = chart.leftOutsideLinebackers[lolbCount++];
                        break;
                    case (int)Constants.ROLB:
                        temp = chart.rightOutsideLinebackers[rolbCount++];
                        break;
                    case (int)Constants.DT:
                        temp = chart.defensiveTackles[dtCount++];
                        break;
                    case (int)Constants.RE:
                        temp = chart.rightEnds[reCount++];
                        break;
                    case (int)Constants.LE:
                        temp = chart.leftEnds[leCount++];
                        break;
                    case (int)Constants.CB:
                        temp = chart.cornerBacks[cbCount++];
                        break;
                    case (int)Constants.SS:
                        temp = chart.strongSafeties[ssCount++];
                        break;
                    default:
                        temp = chart.freeSafeties[fsCount++];
                        break;
                }


                retVal[i] = temp;
            }

            // TODO: Make it so that the coach can sub in/out players
            // Also check to make sure no duplicates exist



            return retVal;
        }
    }
    public class OffensiveFormation : Formation
    {
        private Dictionary<String, OffensivePlay> plays;
        private EligibleRecieverLayout[] players;
        private bool shotGun;
        public OffensiveFormation(EligibleRecieverLayout[] players, Dictionary<String, OffensivePlay> passPlays, bool shotGun = false)
        {
            plays = new Dictionary<String, OffensivePlay>();
            plays.Add("Dive Right", new OffensivePlay(OffensivePlayType.DIVE_RIGHT, this));
            plays.Add("Slam Right", new OffensivePlay(OffensivePlayType.SLAM_RIGHT, this));
            plays.Add("Stretch Right", new OffensivePlay(OffensivePlayType.STRETCH_RIGHT, this));
            plays.Add("Pitch Right", new OffensivePlay(OffensivePlayType.PITCH_RIGHT, this));
            plays.Add("Dive Left", new OffensivePlay(OffensivePlayType.DIVE_LEFT, this));
            plays.Add("Slam Left", new OffensivePlay(OffensivePlayType.SLAM_LEFT, this));
            plays.Add("Stretch Left", new OffensivePlay(OffensivePlayType.STRETCH_LEFT, this));
            plays.Add("Pitch Left", new OffensivePlay(OffensivePlayType.PITCH_LEFT, this));

            foreach (KeyValuePair<String, OffensivePlay> pair in passPlays)
            {
                plays.Add(pair.Key, pair.Value);
                pair.Value.SetFormation(this);
            }

            this.players = players;

            this.shotGun = shotGun;

        }
        public Player[] GetPlayers(DepthChart chart)
        {
            Player[] retVal = new Player[11];

            // TODO: Make it so that the coach can sub in/out players
            // Also check to make sure no duplicates exist

            retVal[0] = chart.quarterbacks[0];
            retVal[1] = chart.leftTackles[0];
            retVal[2] = chart.leftGuards[0];
            retVal[3] = chart.centers[0];
            retVal[4] = chart.rightGuards[0];
            retVal[5] = chart.rightTackles[0];


            int wrCount = 0 , teCount = 0, hbCount = 0, fbCount = 0;
            for (int i = 0; i < players.Length;i++ )
            {
                Player temp;

                switch(players[i].GetActualPosition())
                {
                    case (int)Constants.WR:
                        temp = chart.wideRecievers[wrCount++];
                        break;
                    case (int)Constants.HB:
                        temp = chart.halfbacks[hbCount++];
                        break;
                    case (int)Constants.FB:
                        temp = chart.fullbacks[fbCount++];
                        break;
                    default:
                        temp = chart.tightEnds[teCount++];
                        break;
                }
                retVal[6 + i] = temp;
            }

            return retVal;
        }
        public EligibleRecieverLayout[] GetLocations()
        {
            return players;
        }
        public bool GetShotGun()
        {
            return shotGun;
        }
        public OffensivePlay GetPlay(String playName)
        {
            return plays[playName];
        }
    }
    public class EligibleRecieverLayout
    {
        // 0 = WR, 1 = HB, 2 = FB, 3 = TE
        private int position, actualPosition;
        private bool leftOfBall;
        private EligibleLocation location;
        public EligibleRecieverLayout(int position, bool leftOfBall, EligibleLocation location, int actualPosition = -1)
        {
            this.position = position;
            this.leftOfBall = leftOfBall;
            this.location = location;
            if (actualPosition == -1)
                this.actualPosition = position;
            else
                this.actualPosition = actualPosition;
        }
        public int GetActualPosition()
        {
            return actualPosition;
        }
        public int GetPosition()
        {
            return position;
        }
        public bool GetLeft()
        {
            return leftOfBall;
        }
        public EligibleLocation GetLocation()
        {
            return location;
        }
    }
    public class DefensivePlayerLayout
    {
        // 0 = MLB, 1 = LOLB, 2 = ROLB, 3 = DT, 4 = RE, 5 = LE, 6 = CB, 7 = SS. 8 = FS
        private int position;
        // 0 = Blitz, 1 = Man Coverage, 2 = Low Zone, 3 = Mid Zone, 4 = Deep Zone
        private int assignment;
        public DefensivePlayerLayout(int position, int assignment = 0)
        {
            this.position = position;
            this.assignment = assignment;
        }
        public int GetPosition()
        {
            return position;
        }
        public int GetAssignment()
        {
            return assignment;
        }
    }
    public enum EligibleLocation
    {
        ON_LINE, BACKFIELD, CENTER_BACKFIELD, OFF_LINE
    }
}
