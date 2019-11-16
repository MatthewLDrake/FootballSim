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
        private double location, currDirectionX, currDirectionY, currSpeed;
        private int changeInX, changeInY, currLocationX, currLocationY, nextChange;
        private bool ended;
        public RouteTypes(List<Tuple<Direction, int, bool>> route)
        {
            // Make a copy
            this.route = new List<Tuple<Direction, int, bool>>(route);
        }
        public RouteTypes(RouteTypes copy, int currLocationX, int currLocationY)
        {
            this.route = new List<Tuple<Direction,int,bool>>(copy.route);
            this.currLocationX = currLocationX;
            this.currLocationY = currLocationY;
            location = 0;
            currDirectionX = 0;
            currDirectionY = 0;
            currSpeed = 0;
            ended = false;
            ChangeDirection(route[nextChange].Item1, route[nextChange].Item3);
            nextChange = 1;
        }
        public void ChangeDirection()
        {
            if(nextChange > route.Count)
                return;
            ChangeDirection(route[nextChange].Item1, route[nextChange].Item3);
        }
        private void ChangeDirection(Direction direction, bool completeOveride)
        {
            if(completeOveride)
            {
                switch(direction)
                {
                    case Direction.BACK:
                        currDirectionX = 0;
                        currDirectionY = -1;
                        break;
                    case Direction.FORWARD:
                        currDirectionX = 0;
                        currDirectionY = 1;
                        break;
                    case Direction.FLAG:
                        throw new NotImplementedException("Implement Flag");
                        //break;
                    case Direction.MIDDLE:
                        currDirectionY = 0;
                        currDirectionX = currLocationX > 80 ? -1 : 1;
                        break;
                    case Direction.SIDE_LINE:
                        currDirectionY = 0;
                        currDirectionX = currLocationX > 80 ? 1 : -1;
                        break;
                }
            }
            else
                throw new NotImplementedException("Implement Non Complete Changes");
        }
        public void ResetChanges()
        {
            changeInX = 0;
            changeInY = 0;
        }
        public bool Ended
        {
            get { return ended; }
            set { this.ended = value; }
        }
        public int ChangeInX
        {
            get 
            {
                currLocationX += changeInX;
                return changeInX; 
            }
        }
        public int ChangeInY
        {
            get 
            {
                currLocationY += changeInY;
                return changeInY; 
            }
        }
        public double Location
        {
            get { return location; }
            set 
            {
                changeInX = (int)Math.Round(value * currDirectionX);
                changeInY = (int)Math.Round(value * currDirectionY);
                this.location = value; 
            }
        }
        public double CurrDirectionX
        {
            get { return currDirectionX; }
            set { this.currDirectionX = value; }
        }
        public double CurrDirectionY
        {
            get { return currDirectionY; }
            set { this.currDirectionY = value; }
        }
        public double CurrSpeed
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
                currLoc += route[i].Item2;
            }
            return retVal;
        }
        public double GetDistanceLeftOnCurrentBranch()
        {
            int currLoc = 0;
            for (int i = 0; i < route.Count; i++)
            {
                if (currLoc + route[i].Item2 > location)
                {
                    return currLoc + route[i].Item2 - location;
                }
                currLoc += route[i].Item2;
            }
            return -1;
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
