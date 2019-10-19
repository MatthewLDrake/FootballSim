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
            String[] arr = str.Split('/');
            return new Player(arr[1], arr[0], GetRatings(arr[0], arr[5], arr[6]), int.Parse(arr[3]), int.Parse(arr[4]), int.Parse(arr[7]),(CollegeList) Enum.Parse(typeof (CollegeList), arr[2]), 0);            
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
                    arr = KickerRatings(style, talent, position == "K");
                    break;
                default:
                    return DealWithIronmanPlayer(position, style, talent);
            }

            return arr;
        }
        public static int balanced = 0, pocket = 0, scrambler = 0;
        private static int[] QBRatings(String style, String talent)
        {
            switch(style)
            {
                case "Balanced":
                    balanced++;
                    return QBFactory.CreateBalancedQB(talent);
                case "Pocket":
                    pocket++;
                    return QBFactory.CreatePocketQB(talent);
                case "Scrambler":
                    scrambler++;
                    return QBFactory.CreateScramblerQB(talent);
                default:
                    throw new NotImplementedException(style);
            }
        }
        private static int[] HBRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] FBRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] WRRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] TERatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] OLRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] DERatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] DTRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] OLBRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] MLBRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] CBRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] SRatings(String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        private static int[] KickerRatings(String style, String talent, bool kicker)
        {
            switch (style)
            {
                case "Balanced":
                    balanced++;
                    return KickerFactory.CreateBalancedKicker(talent, kicker);
                case "Power":
                    pocket++;
                    return KickerFactory.CreatePowerKicker(talent, kicker);
                case "Accurate":
                    scrambler++;
                    return KickerFactory.CreateAccurateKicker(talent, kicker);
                default:
                    throw new NotImplementedException(style);
            }
        }
        private static int[] DealWithIronmanPlayer(String positions, String style, String talent)
        {
            int[] arr = new int[36];
            return arr;
        }
        public static List<int> GetNonAthleticThrower()
        {
            return null;
        }
    }
    static class KickerFactory
    {
        public static int[] CreatePowerKicker(String talent, bool kicker)
        {
            int overall, legStrength, puntingAim, fieldGoalAim;
            
            Random random = Random.GetInstance();

            switch (talent)
            {
                case "Generational":
                    int num = random.Next(100);

                    if (num < 35)
                        legStrength = random.Next(95, 100);
                    else if (num < 55)
                        legStrength = random.Next(90, 95);
                    else if (num < 70)
                        legStrength = random.Next(85, 90);
                    else if (num < 80)
                        legStrength = random.Next(80, 85);
                    else if (num < 90)
                        legStrength = random.Next(75, 80);
                    else if (num < 95)
                        legStrength = random.Next(70, 75);
                    else
                        legStrength = random.Next(65, 70);

                    break;
                case "Great":
                    overall = random.Next(70, 77);
                    break;
                case "Good":
                    overall = random.Next(65, 72);
                    break;
                case "Average":
                    overall = random.Next(60, 67);
                    break;
                case "Below Average":
                    overall = random.Next(55, 62);
                    break;
                case "Bad":
                    overall = random.Next(50, 57);
                    break;
                case "Awful":
                    overall = random.Next(45, 52);
                    break;
                case "Random":

                    num = random.Next(100);

                    if(num < 2)
                        return CreatePowerKicker("Generational", kicker);
                    else if (num < 10)
                        return CreatePowerKicker("Great", kicker);
                    else if (num < 25)
                        return CreatePowerKicker("Good", kicker);
                    else if (num < 50)
                        return CreatePowerKicker("Average", kicker);
                    else if (num < 65)
                        return CreatePowerKicker("Below Average", kicker);
                    else if (num < 80)
                        return CreatePowerKicker("Bad", kicker);
                    else
                        return CreatePowerKicker("Awful", kicker);

            }
            List<int> ratings = new List<int>();

            int[] arr = new int[36];

            return arr;        
        }
        public static int[] CreateAccurateKicker(String talent, bool kicker)
        {
            int overall;

            Random random = Random.GetInstance();

            switch (talent)
            {
                case "Generational":
                    overall = random.Next(75, 85);
                    break;
                case "Great":
                    overall = random.Next(70, 77);
                    break;
                case "Good":
                    overall = random.Next(65, 72);
                    break;
                case "Average":
                    overall = random.Next(60, 67);
                    break;
                case "Below Average":
                    overall = random.Next(55, 62);
                    break;
                case "Bad":
                    overall = random.Next(50, 57);
                    break;
                case "Awful":
                    overall = random.Next(45, 52);
                    break;
                case "Random":

                    int num = random.Next(100);

                    if (num < 2)
                        return CreateAccurateKicker("Generational", kicker);
                    else if (num < 10)
                        return CreateAccurateKicker("Great", kicker);
                    else if (num < 25)
                        return CreateAccurateKicker("Good", kicker);
                    else if (num < 50)
                        return CreateAccurateKicker("Average", kicker);
                    else if (num < 65)
                        return CreateAccurateKicker("Below Average", kicker);
                    else if (num < 80)
                        return CreateAccurateKicker("Bad", kicker);
                    else
                        return CreateAccurateKicker("Awful", kicker);

            }
            int[] arr = new int[36];

            return arr;
        }
        public static int[] CreateBalancedKicker(String talent, bool kicker)
        {
            int overall;

            Random random = Random.GetInstance();

            switch (talent)
            {
                case "Generational":
                    overall = random.Next(75, 85);
                    break;
                case "Great":
                    overall = random.Next(70, 77);
                    break;
                case "Good":
                    overall = random.Next(65, 72);
                    break;
                case "Average":
                    overall = random.Next(60, 67);
                    break;
                case "Below Average":
                    overall = random.Next(55, 62);
                    break;
                case "Bad":
                    overall = random.Next(50, 57);
                    break;
                case "Awful":
                    overall = random.Next(45, 52);
                    break;
                case "Random":

                    int num = random.Next(100);

                    if (num < 2)
                        return CreateBalancedKicker("Generational", kicker);
                    else if (num < 10)
                        return CreateBalancedKicker("Great", kicker);
                    else if (num < 25)
                        return CreateBalancedKicker("Good", kicker);
                    else if (num < 50)
                        return CreateBalancedKicker("Average", kicker);
                    else if (num < 65)
                        return CreateBalancedKicker("Below Average", kicker);
                    else if (num < 80)
                        return CreateBalancedKicker("Bad", kicker);
                    else
                        return CreateBalancedKicker("Awful", kicker);

            }
            int[] arr = new int[36];

            return arr;
        }
    }
    static class QBFactory
    {
        public static int[] CreateBalancedQB(String talent)
        {           

            int overall;
            
            Random random = Random.GetInstance();

            switch (talent)
            {
                case "Generational":
                    overall = random.Next(75, 85);
                    break;
                case "Great":
                    overall = random.Next(70, 77);
                    break;
                case "Good":
                    overall = random.Next(65, 72);
                    break;
                case "Average":
                    overall = random.Next(60, 67);
                    break;
                case "Below Average":
                    overall = random.Next(55, 62);
                    break;
                case "Bad":
                    overall = random.Next(50, 57);
                    break;
                case "Awful":
                    overall = random.Next(45, 52);
                    break;
                case "Random":

                    int num = random.Next(100);

                    if(num < 2)
                        return CreateBalancedQB("Generational");
                    else if (num < 10)
                        return CreateBalancedQB("Great");
                    else if (num < 25)
                        return CreateBalancedQB("Good");
                    else if (num < 50)
                        return CreateBalancedQB("Average");
                    else if (num < 65)
                        return CreateBalancedQB("Below Average");
                    else if (num < 80)
                        return CreateBalancedQB("Bad");
                    else
                        return CreateBalancedQB("Awful");

            }
            int[] arr = new int[36];

            return arr;
        }
        public static int[] CreatePocketQB(String talent)
        {

            int overall;

            Random random = Random.GetInstance();

            switch (talent)
            {
                case "Generational":
                    overall = random.Next(75, 85);
                    break;
                case "Great":
                    overall = random.Next(70, 77);
                    break;
                case "Good":
                    overall = random.Next(65, 72);
                    break;
                case "Average":
                    overall = random.Next(60, 67);
                    break;
                case "Below Average":
                    overall = random.Next(55, 62);
                    break;
                case "Bad":
                    overall = random.Next(50, 57);
                    break;
                case "Awful":
                    overall = random.Next(45, 52);
                    break;
                case "Random":

                    int num = random.Next(100);

                    if (num < 2)
                        return CreatePocketQB("Generational");
                    else if (num < 10)
                        return CreatePocketQB("Great");
                    else if (num < 25)
                        return CreatePocketQB("Good");
                    else if (num < 50)
                        return CreatePocketQB("Average");
                    else if (num < 65)
                        return CreatePocketQB("Below Average");
                    else if (num < 80)
                        return CreatePocketQB("Bad");
                    else
                        return CreatePocketQB("Awful");

            }
            int[] arr = new int[36];

            return arr;
        }
        public static int[] CreateScramblerQB(String talent)
        {

            int overall;

            Random random = Random.GetInstance();

            switch (talent)
            {
                case "Generational":
                    overall = random.Next(75, 85);
                    break;
                case "Great":
                    overall = random.Next(70, 77);
                    break;
                case "Good":
                    overall = random.Next(65, 72);
                    break;
                case "Average":
                    overall = random.Next(60, 67);
                    break;
                case "Below Average":
                    overall = random.Next(55, 62);
                    break;
                case "Bad":
                    overall = random.Next(50, 57);
                    break;
                case "Awful":
                    overall = random.Next(45, 52);
                    break;
                case "Random":

                    int num = random.Next(100);

                    if (num < 2)
                        return CreateScramblerQB("Generational");
                    else if (num < 10)
                        return CreateScramblerQB("Great");
                    else if (num < 25)
                        return CreateScramblerQB("Good");
                    else if (num < 50)
                        return CreateScramblerQB("Average");
                    else if (num < 65)
                        return CreateScramblerQB("Below Average");
                    else if (num < 80)
                        return CreateScramblerQB("Bad");
                    else
                        return CreateScramblerQB("Awful");

            }
            int[] arr = new int[36];

            return arr;
        }
    }
}

