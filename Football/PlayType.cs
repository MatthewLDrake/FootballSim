using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    public class PlayType
    {

    }
    public class OffensivePlayType : PlayType
    {
        private String value;
        public OffensivePlayType(String value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
        public static readonly OffensivePlayType PITCH_LEFT = new OffensivePlayType("Pitch Left");
        public static readonly OffensivePlayType STRETCH_LEFT = new OffensivePlayType("Stretch Left");
        public static readonly OffensivePlayType SLAM_LEFT = new OffensivePlayType("Slam Left");
        public static readonly OffensivePlayType DIVE_LEFT = new OffensivePlayType("Dive Left");
        public static readonly OffensivePlayType PITCH_RIGHT = new OffensivePlayType("Pitch Right");
        public static readonly OffensivePlayType STRETCH_RIGHT = new OffensivePlayType("Stretch Right");
        public static readonly OffensivePlayType SLAM_RIGHT = new OffensivePlayType("Slam Right");
        public static readonly OffensivePlayType DIVE_RIGHT = new OffensivePlayType("Dive Right");
        public static readonly OffensivePlayType PASS = new OffensivePlayType("Pass"); 
        }
    public class DefensivePlayType : PlayType
    {
        private String value;
        public DefensivePlayType(String value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return value;
        }

        public static readonly DefensivePlayType COVER_THREE = new DefensivePlayType("Cover Three");
        public static readonly DefensivePlayType COVER_TWO = new DefensivePlayType("Cover Two");
        public static readonly DefensivePlayType MAN_TWO_UNDER = new DefensivePlayType("Man Two Under");
        public static readonly DefensivePlayType MAN_BLITZ = new DefensivePlayType("Man Blitz");
        public static readonly DefensivePlayType ZONE_BLITZ = new DefensivePlayType("Zone Blitz");
        public static readonly DefensivePlayType CORNER_BLITZ = new DefensivePlayType("Corner Blitz");
    }
    public enum SpecialTeamsPlayType
    {
        PUNT, KICKOFF, PUNT_RETURN, KICKOFF_RETURN, FIELD_GOAL
    }
    public class RouteTypes
    {
        private List<Tuple<Direction, int, bool>> route;
        private int location, currDirectionX, currDirectionY, currSpeed;
        public RouteTypes(List<Tuple<Direction, int, bool>> route)
        {
            // Make a copy
            this.route = new List<Tuple<Direction, int, bool>>(route);
        }
        public RouteTypes(RouteTypes copy)
        {
            this.route = new List<Tuple<Direction,int,bool>>(copy.route);
            location = 0;
            currDirectionX = 0;
            currDirectionY = 0;
            currSpeed = 0;
        }
        public int Location
        {
            get { return location; }
            set { this.location = value;  }
        }
        public int CurrDirectionX
        {
            get { return currDirectionX; }
            set { this.currDirectionX = value; }
        }
        public int CurrDirectionY
        {
            get { return currDirectionY; }
            set { this.currDirectionY = value; }
        }
        public int CurrSpeed
        {
            get { return currSpeed; }
            set { this.currSpeed = value; }
        }
        public List<Tuple<Direction, int, bool>> GetTuple()
        {
            List<Tuple<Direction, int, bool>> retVal = new List<Tuple<Direction, int, bool>>();
            int currLoc = 0;
            for(int i = 0; i < route.Count; i++)
            {
                if(currLoc + route[i].Item2 > location)
                {
                    if (!route[i].Item3 && i != 0)
                        retVal.Add(route[i - 1]);
                    retVal.Add(route[i]);
                    break;
                }
            }
            return retVal;
        }
        static RouteTypes()
        {
            List<Tuple<Direction, int, bool>> list = new List<Tuple<Direction, int, bool>>();
            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 60, true));
            GO = new RouteTypes(list);            
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FLAG, 60, true));
            FADE = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 20, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.MIDDLE, 20, true));
            IN = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 20, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.SIDE_LINE, 20, true));
            OUT = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 20, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.BACK, 1, true));
            CURL = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 0, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.MIDDLE, 6, false));
            list.Add(new Tuple<Direction, int, bool>(Direction.MIDDLE, 20, true));
            DRAG = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FLAG, 20, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.BACK, 1, true));
            BACK_CURL = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 3, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.MIDDLE, 15, false));
            SLANT = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.FORWARD, 15, true));
            list.Add(new Tuple<Direction, int, bool>(Direction.MIDDLE, 15, false));
            POST = new RouteTypes(list);
            list.Clear();

            list.Add(new Tuple<Direction, int, bool>(Direction.PASS_BLOCK, 0, true));
            PASS_BLOCK = new RouteTypes(list);
            
        }
        public static readonly RouteTypes GO;
        public static readonly RouteTypes FADE;
        public static readonly RouteTypes IN;
        public static readonly RouteTypes OUT;
        public static readonly RouteTypes CURL;
        public static readonly RouteTypes DRAG;
        public static readonly RouteTypes BACK_CURL;
        public static readonly RouteTypes SLANT;
        public static readonly RouteTypes POST;
        public static readonly RouteTypes PASS_BLOCK;
        public static readonly RouteTypes RUN_BLOCK;
    }
    public enum Direction
    {
        FORWARD, BACK, MIDDLE, SIDE_LINE, FLAG, PASS_BLOCK, RUN_BLOCK
    }
}
