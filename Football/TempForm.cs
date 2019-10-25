using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football
{
    public partial class TempForm : Form
    {
        private Dictionary<BlockingResult, int> counter;
        private Team Packers, Raiders;
        public TempForm()
        {
            InitializeComponent();

            counter = new Dictionary<BlockingResult, int>();
            foreach(BlockingResult result in Enum.GetValues(typeof(BlockingResult)))
            {
                counter.Add(result, 0);
            }
            Form1 form = new Form1();
            Packers = form.GetTeam(0);
            Raiders = form.GetTeam(29);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DefenseCreator d = new DefenseCreator();
            d.Show();
            //Game game = new Game(Packers, Raiders, false, this);           

            /*
            foreach (BlockingResult result in Enum.GetValues(typeof(BlockingResult)))
            {
                counter[result] = 0;
            }
            Blocking doubleTeamer = new Blocking();
            doubleTeamer.SetUpBlocker(new int[]{75, 75});
            for(int i = 0; i < 1000; i++)
            {
                BlockingResult result = Game.RunBlock((int)blockerRating.Value, (int)defenderRating.Value, i % 2 == 0, doubleTeamer);
                counter[result]++;
            }
            results.Text = "Results:\n";
            foreach(BlockingResult result in Enum.GetValues(typeof(BlockingResult)))
            {
                results.Text += result.ToString() + ": " + string.Format("{0:N2}%", (double)counter[result]/10.0) + "\n"; 
            }*/
        }
        private void RunPlay(Play player, OffensiveFormation offense, DefensiveFormation defense)
        {
            Field field = Field.GetInstance();
        }
    }
    class Blocking : Blocker
    {
        int runBlocking, passBlocking;
        public void SetUpBlocker(int[] ratings)
        {
            runBlocking = ratings[0];
            passBlocking = ratings[1];
        }

        public double GetRunBlocking()
        {
            return runBlocking;
        }

        public double GetPassBlocking()
        {
            return passBlocking;
        }

        public double GetBlockerOverall()
        {
            throw new NotImplementedException();
        }
    }
}
