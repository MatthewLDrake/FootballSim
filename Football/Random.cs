using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Random
    {
        private System.Random r;
        private static Random instance;
        public static Random GetInstance()
        {
            if(instance == null)
            {
                instance = new Random();
            }
            return instance;
        }
        private Random()
        {
            r = new System.Random();
        }

        public bool GetBool()
        {
            return r.Next() > (Int32.MaxValue / 2);
            // Next() returns an int in the range [0..Int32.MaxValue]
            
        }
        public double GetDouble()
        {
            return r.NextDouble();
        }
        public double GetGaussian(double mu = 0, double sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }
        public int Next()
        {
            return r.Next();
        }
        public int Next(int max)
        {
            return r.Next(max);
        }
        public int Next(int min, int max)
        {
            return r.Next(min, max);
        }
    }
}
