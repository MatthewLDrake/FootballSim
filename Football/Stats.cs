using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public interface Stats
    {
        Stats AddStats(List<Stats> list);
    }
    public class Punts : Stats
    {
        private double yardsPunted, yardsReturned, hangTime;
        private int fairCaught, insideTwenty, touchDown;
        public Punts() : this (0, 0, 0, false, false, false)
        {

        }
        public Punts(double yardsPunted, double yardsReturned, double hangTime, int fairCatches, int insideTwenty, int touchDowns)
        {
            this.yardsPunted = yardsPunted;
            this.yardsReturned = yardsReturned;
            this.hangTime = hangTime;
            this.fairCaught = fairCatches;
            this.insideTwenty = insideTwenty;
            this.touchDown = touchDowns;
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
        public Stats AddStats(List<Stats> list)
        {
           Punts retVal = new Punts();
           foreach(Stats item in list)
            {
                if(!(item is Punts))
                {
                    return null;
                }
            }
            return retVal;
           
        }
    }
}
