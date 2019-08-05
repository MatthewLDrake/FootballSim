using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football
{
    public partial class FootballGame : UserControl
    {        
        public FootballGame()
        {
            InitializeComponent();
            
        }
        public void SetTeamNames(String teamOne, String teamTwo)
        {
            teamOneLabel.Text = teamOne;
            teamTwoLabel.Text = teamTwo;
        }
        public void SetQuarterScore(int quarter, int teamOneScore, int teamTwoScore)
        {
            switch(quarter)
            {
                case 1:
                    teamOneQ1.Text = "" + teamOneScore;
                    teamTwoQ1.Text = "" + teamTwoScore;
                    break;
                case 2:
                    teamOneQ2.Text = "" + teamOneScore;
                    teamTwoQ2.Text = "" + teamTwoScore;
                    break;
                case 3:
                    teamOneQ3.Text = "" + teamOneScore;
                    teamTwoQ3.Text = "" + teamTwoScore;
                    break;
                case 4:
                    teamOneQ4.Text = "" + teamOneScore;
                    teamTwoQ4.Text = "" + teamTwoScore;
                    break;
                case 5:
                    teamOneOT.Text = "" + teamOneScore;
                    teamTwoOT.Text = "" + teamTwoScore;
                    break;
                default:
                    break;
            }
            teamOneTotal.Text = "" + (int.Parse(teamOneQ1.Text) + int.Parse(teamOneQ2.Text) + int.Parse(teamOneQ3.Text) + int.Parse(teamOneQ4.Text) + int.Parse(teamOneOT.Text));
            teamTwoTotal.Text = "" +( int.Parse(teamTwoQ1.Text) + int.Parse(teamTwoQ2.Text) + int.Parse(teamTwoQ3.Text) + int.Parse(teamTwoQ4.Text) + int.Parse(teamTwoOT.Text));


        }
        public void Reset()
        {
            teamOneLabel.Text = "Team One";
            teamTwoLabel.Text = "Team Two";

            teamOneTotal.Text = "000";
            teamTwoTotal.Text = "000";

            teamOneQ1.Text = "00";
            teamTwoQ1.Text = "00";
            teamOneQ2.Text = "00";
            teamTwoQ2.Text = "00";
            teamOneQ3.Text = "00";
            teamTwoQ3.Text = "00";
            teamOneQ4.Text = "00";
            teamTwoQ4.Text = "00";
            teamOneOT.Text = "00";
            teamTwoOT.Text = "00";
        }
    }
}
