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
    public enum RouteTypes
    {
        GO, FADE, IN, OUT, CURL, DRAG, BACK_CURL, SLANT
    }
}
