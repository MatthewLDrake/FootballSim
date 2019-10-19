using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
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
            new EligibleRecieverLayout(0, true, EligibleLocation.OFF_LINE), 
            new EligibleRecieverLayout(0, false, EligibleLocation.ON_LINE), 
            new EligibleRecieverLayout(1, false, EligibleLocation.BACKFIELD), 
            new EligibleRecieverLayout(2, false, EligibleLocation.BACKFIELD), 
            new EligibleRecieverLayout(3, true, EligibleLocation.ON_LINE) }, new Dictionary<String, OffensivePlay>());

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
        private int corners, safties, linebackers, ends, tackles;
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
                players[i] = new DefensivePlayerLayout(6);
            }
            for (int i = 0; i < safties; i++)
            {
                players[loc] = new DefensivePlayerLayout(i % 2 == 0 ? 7 : 8);
                loc++;
            }
            if(linebackers > 2)
            {
                for (int i = 2; i < linebackers; i++)
                {
                    players[loc] = new DefensivePlayerLayout(0);
                    loc++;
                }
                players[loc] = new DefensivePlayerLayout(1);
                loc++;
                players[loc] = new DefensivePlayerLayout(2);
                loc++;
                
            }
            else if(linebackers == 2)
            {
                players[loc] = new DefensivePlayerLayout(0);
                loc++;
                players[loc] = new DefensivePlayerLayout(1);
                loc++;
            }
            else if(linebackers == 1)
            {
                players[loc] = new DefensivePlayerLayout(0);
                loc++;
            }

            if(ends == 1)
            {
                players[loc] = new DefensivePlayerLayout(4);
                loc++;
            }
            else if(ends == 2)
            {
                players[loc] = new DefensivePlayerLayout(4);
                loc++;
                players[loc] = new DefensivePlayerLayout(5);
                loc++;
            }

            for (int i = 0; i < tackles; i++ )
            {
                players[loc] = new DefensivePlayerLayout(3);
                loc++;
            }
            

            plays.Add("Cover Three", new DefensivePlay(DefensivePlayType.COVER_THREE, this));
        }
        public DefensivePlay GetPlay(String name)
        {
            return plays[name];
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


            int wrCount = 0, teCount = 0, hbCount = 0, fbCount = 0;
            for (int i = 0; i < players.Length; i++)
            {
                Player temp;

                switch (players[i].GetPosition())
                {
                    case 0:
                        temp = chart.wideRecievers[wrCount++];
                        break;
                    case 1:
                        temp = chart.wideRecievers[hbCount++];
                        break;
                    case 2:
                        temp = chart.wideRecievers[fbCount++];
                        break;
                    default:
                        temp = chart.tightEnds[teCount++];
                        break;
                }
                retVal[6 + i] = temp;
            }

            return retVal;
        }
    }
    public class OffensiveFormation : Formation
    {
        private Dictionary<String, OffensivePlay> plays;
        private EligibleRecieverLayout[] players;
        public OffensiveFormation(EligibleRecieverLayout[] players, Dictionary<String, OffensivePlay> passPlays)
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
                plays.Add(pair.Key, pair.Value);

            this.players = players;

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

                switch(players[i].GetPosition())
                {
                    case 0:
                        temp = chart.wideRecievers[wrCount++];
                        break;
                    case 1:
                        temp = chart.wideRecievers[hbCount++];
                        break;
                    case 2:
                        temp = chart.wideRecievers[fbCount++];
                        break;
                    default:
                        temp = chart.tightEnds[teCount++];
                        break;
                }
                retVal[6 + i] = temp;
            }

            return retVal;
        }
        public OffensivePlay GetPlay(String playName)
        {
            return plays[playName];
        }
    }
    public class EligibleRecieverLayout
    {
        // 0 = WR, 1 = HB, 2 = FB, 3 = TE
        private int position;
        private bool leftOfBall;
        private EligibleLocation location;
        public EligibleRecieverLayout(int position, bool leftOfBall, EligibleLocation location)
        {
            this.position = position;
            this.leftOfBall = leftOfBall;
            this.location = location;
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
        ON_LINE, BACKFIELD, OFF_LINE
    }
}
