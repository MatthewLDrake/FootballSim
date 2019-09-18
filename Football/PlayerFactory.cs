using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    
    class PlayerFactory
    {
        public PlayerFactory()
        {
            
        }
        public static Player GeneratePlayer(String str)
        {
            Random random = Random.GetInstance();
            String[] arr = str.Split('/');
            return new Player(arr[1], GetRatings(arr[0], arr[5], arr[6]), int.Parse(arr[3]), int.Parse(arr[4]), int.Parse(arr[7]),(CollegeList) Enum.Parse(typeof (CollegeList), arr[2]));            
        }
        private static int[] GetRatings(String position, String style, String talent)
        {
            int[] arr = new int[35];

            switch(position)
            {
                case "QB":
                    arr = QBRatings(style, talent);
                    break;
                case "HB":
                    arr = HBRatings(style, talent);
                    break;
                case "FB":
                    arr = FBRatings(style, talent);
                    break;
                case "WR":
                    arr = WRRatings(style, talent);
                    break;
                case "TE":
                    arr = TERatings(style, talent);
                    break;
                case "T":
                case "G":
                case "C":
                    arr = OLRatings(style, talent);
                    break;
                case "DE":
                    arr = DERatings(style, talent);
                    break;
                case "DT":
                    arr = DTRatings(style, talent);
                    break;
                case "OLB":
                    arr = OLBRatings(style, talent);
                    break;
                case "MLB":
                    arr = MLBRatings(style, talent);
                    break;
                case "CB":
                    arr = CBRatings(style, talent);
                    break;
                case "FS":
                case "SS":
                    arr = SRatings(style, talent);
                    break;
                case "P":
                case "K":
                    arr = KickerRatings(style, talent);
                    break;
                default:
                    return DealWithIronmanPlayer(position, style, talent);
            }

            return arr;
        }
        private static int[] QBRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] HBRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] FBRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] WRRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] TERatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] OLRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] DERatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] DTRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] OLBRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] MLBRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] CBRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] SRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] KickerRatings(String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
        private static int[] DealWithIronmanPlayer(String positions, String style, String talent)
        {
            int[] arr = new int[35];
            return arr;
        }
    }
}
