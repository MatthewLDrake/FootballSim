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
            return arr;
        }
    }
}
