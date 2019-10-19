using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Field
    {
        private static Field instance;
        private int[,] field;
        private Field()
        {
            field = new int[300, 160];
        }
        public static Field GetInstance()
        {
            if (instance == null)
                instance = new Field();
            return instance;
        }
    }
    public class BallLocation
    {
        private int length, width;
        public BallLocation(int length, int width)
        {
            this.length = length;
            this.width = width;
        }
        public int GetLength()
        {
            return length;
        }
        public int GetWidth()
        {
            return width;
        }
        public void SetLocation(int length, int width)
        {            
            this.length = length;

            if (width < 70)
                this.width = 70;
            else if (width > 90)
                this.width = 90;
            else
                this.width = width;
        }

    }
}
