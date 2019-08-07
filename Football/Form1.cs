using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football
{
    public partial class Form1 : Form
    {
        private List<Team> teams, nfcPlayoffTeams, afcPlayoffTeams;
        private Team higherRankedNFCTeam, higherRankedAFCTeam, lowerRankedNFCTeam, lowerRankedAFCTeam;
        private Schedule schedule;
        private Division nfcNorth, nfcEast, nfcSouth, nfcWest, afcNorth, afcEast, afcSouth, afcWest;
        private int stage;

        public Form1()
        {
            InitializeComponent();

            schedule = new Schedule();

            nfcNorth = new Division("NFC North");
            nfcEast = new Division("NFC East");
            nfcSouth = new Division("NFC South");
            nfcWest = new Division("NFC West");

            afcNorth = new Division("AFC North");
            afcEast = new Division("AFC East");
            afcSouth = new Division("AFC South");
            afcWest = new Division("AFC West");

            teams = new List<Team>
            {
                new Team("Green Bay Packers"),
                new Team("Detroit Lions"),
                new Team("Minnesota Vikings"),
                new Team("Chicago Bears"),

                new Team("Dallas Cowboys"),
                new Team("Washington Redskins"),
                new Team("Philadelphia Eagles"),
                new Team("New York Giants"),

                new Team("New Orleans Saints"),
                new Team("Tampa Bay Buccaneers"),
                new Team("Carolina Panthers"),
                new Team("Atlanta Falcons"),

                new Team("Arizona Cardinals"),
                new Team("Los Angeles Rams"),
                new Team("Seattle Seahawks"),
                new Team("San Francisco 49ers"),

                new Team("Cleveland Browns"),
                new Team("Cincinatti Bengals"),
                new Team("Baltimore Ravens"),
                new Team("Pittsburgh Steelers"),

                new Team("New England Patriots"),
                new Team("Miami Dolphins"),
                new Team("New York Jets"),
                new Team("Buffalo Bills"),

                new Team("Houston Texans"),
                new Team("Indianapolis Colts"),
                new Team("Jacksonville Jaguars"),
                new Team("Tennesee Titans"),

                new Team("Los Angeles Chargers"),
                new Team("Oakland Raiders"),
                new Team("Denver Broncos"),
                new Team("Kansas City Chiefs")                

                
            };
            for(int i = 0; i < teams.Count; i++)
            {
                teams[i].SetTeamNum(i);
            }
            nfcNorth.AddTeams(teams[0], teams[1], teams[2], teams[3]);
            nfcEast.AddTeams(teams[4], teams[5], teams[6], teams[7]);
            nfcSouth.AddTeams(teams[8], teams[9], teams[10], teams[11]);
            nfcWest.AddTeams(teams[12], teams[13], teams[14], teams[15]);

            afcNorth.AddTeams(teams[16], teams[17], teams[18], teams[19]);
            afcEast.AddTeams(teams[20], teams[21], teams[22], teams[23]);
            afcSouth.AddTeams(teams[24], teams[25], teams[26], teams[27]);
            afcWest.AddTeams(teams[28], teams[29], teams[30], teams[31]);

            stage = 0;
        }
        private void PlaySeason()
        {
            List<Week> weeks = schedule.CreateNewSchedule();

            foreach (Week week in weeks)
            {
                List<Tuple<int, int>> games = week.GetGames();
                foreach (Tuple<int, int> game in games)
                {
                    Game playTheGame = new Game(teams[game.Item1], teams[game.Item2]);
                    teams[game.Item1].AddResult(teams[game.Item2], playTheGame.GetTeamOneScore(), playTheGame.GetTeamTwoScore());
                    teams[game.Item2].AddResult(teams[game.Item1], playTheGame.GetTeamTwoScore(), playTheGame.GetTeamOneScore());
                }
            }
            nfcNorth.PrintResults();
            nfcEast.PrintResults();
            nfcSouth.PrintResults();
            nfcWest.PrintResults();

            afcNorth.PrintResults();
            afcEast.PrintResults();
            afcSouth.PrintResults();
            afcWest.PrintResults();

            nfcPlayoffTeams = new List<Team>
            {
                nfcNorth.GetDivisionWinner(),
                nfcEast.GetDivisionWinner(),
                nfcSouth.GetDivisionWinner(),
                nfcWest.GetDivisionWinner()
            };

            afcPlayoffTeams = new List<Team>
            {
                afcNorth.GetDivisionWinner(),
                afcEast.GetDivisionWinner(),
                afcSouth.GetDivisionWinner(),
                afcWest.GetDivisionWinner()
            };

            nfcPlayoffTeams.Sort();
            afcPlayoffTeams.Sort();

            List<Team> wildCard = new List<Team>();
            wildCard.AddRange(nfcNorth.GetWildCards());
            wildCard.AddRange(nfcEast.GetWildCards());
            wildCard.AddRange(nfcSouth.GetWildCards());
            wildCard.AddRange(nfcWest.GetWildCards());

            wildCard.Sort();
            nfcPlayoffTeams.Add(wildCard[0]);
            nfcPlayoffTeams.Add(wildCard[1]);

            wildCard = new List<Team>();
            wildCard.AddRange(afcNorth.GetWildCards());
            wildCard.AddRange(afcEast.GetWildCards());
            wildCard.AddRange(afcSouth.GetWildCards());
            wildCard.AddRange(afcWest.GetWildCards());

            wildCard.Sort();
            afcPlayoffTeams.Add(wildCard[0]);
            afcPlayoffTeams.Add(wildCard[1]);

            footballGame1.SetTeamNames(afcPlayoffTeams[2].ToString(), afcPlayoffTeams[5].ToString());
            footballGame2.SetTeamNames(afcPlayoffTeams[3].ToString(), afcPlayoffTeams[4].ToString());
            footballGame3.SetTeamNames(nfcPlayoffTeams[2].ToString(), nfcPlayoffTeams[5].ToString());
            footballGame4.SetTeamNames(nfcPlayoffTeams[3].ToString(), nfcPlayoffTeams[4].ToString());

            footballGame1.Visible = true;
            footballGame2.Visible = true;
            footballGame3.Visible = true;
            footballGame4.Visible = true;

            higherRankedNFCTeam = null;
            higherRankedAFCTeam = null;
            lowerRankedAFCTeam = null;
            lowerRankedNFCTeam = null;
        }
        private void WildCardRound()
        {
            Game afcThreeVsSix = new Game(afcPlayoffTeams[2], afcPlayoffTeams[5], true);
            afcPlayoffTeams[2].AddPlayoffResult(afcPlayoffTeams[5], afcThreeVsSix.GetTeamOneScore(), afcThreeVsSix.GetTeamTwoScore());
            afcPlayoffTeams[5].AddPlayoffResult(afcPlayoffTeams[2], afcThreeVsSix.GetTeamTwoScore(), afcThreeVsSix.GetTeamOneScore());
            footballGame1.SetQuarterScore(1, afcThreeVsSix.GetTeamOneQuarterScore(1), afcThreeVsSix.GetTeamTwoQuarterScore(1));
            footballGame1.SetQuarterScore(2, afcThreeVsSix.GetTeamOneQuarterScore(2), afcThreeVsSix.GetTeamTwoQuarterScore(2));
            footballGame1.SetQuarterScore(3, afcThreeVsSix.GetTeamOneQuarterScore(3), afcThreeVsSix.GetTeamTwoQuarterScore(3));
            footballGame1.SetQuarterScore(4, afcThreeVsSix.GetTeamOneQuarterScore(4), afcThreeVsSix.GetTeamTwoQuarterScore(4));
            footballGame1.SetQuarterScore(5, afcThreeVsSix.GetTeamOneQuarterScore(5), afcThreeVsSix.GetTeamTwoQuarterScore(5));

            if(afcThreeVsSix.GetTeamOneScore() > afcThreeVsSix.GetTeamTwoScore())
            {
                higherRankedAFCTeam = afcPlayoffTeams[2];
            }
            else
            {
                lowerRankedAFCTeam = afcPlayoffTeams[5];
            }


            Game afcFourVsFive = new Game(afcPlayoffTeams[3], afcPlayoffTeams[4], true);
            afcPlayoffTeams[3].AddPlayoffResult(afcPlayoffTeams[4], afcFourVsFive.GetTeamOneScore(), afcFourVsFive.GetTeamTwoScore());
            afcPlayoffTeams[4].AddPlayoffResult(afcPlayoffTeams[3], afcFourVsFive.GetTeamTwoScore(), afcFourVsFive.GetTeamOneScore());
            footballGame2.SetQuarterScore(1, afcFourVsFive.GetTeamOneQuarterScore(1), afcFourVsFive.GetTeamTwoQuarterScore(1));
            footballGame2.SetQuarterScore(2, afcFourVsFive.GetTeamOneQuarterScore(2), afcFourVsFive.GetTeamTwoQuarterScore(2));
            footballGame2.SetQuarterScore(3, afcFourVsFive.GetTeamOneQuarterScore(3), afcFourVsFive.GetTeamTwoQuarterScore(3));
            footballGame2.SetQuarterScore(4, afcFourVsFive.GetTeamOneQuarterScore(4), afcFourVsFive.GetTeamTwoQuarterScore(4));
            footballGame2.SetQuarterScore(5, afcFourVsFive.GetTeamOneQuarterScore(5), afcFourVsFive.GetTeamTwoQuarterScore(5));

            if (afcFourVsFive.GetTeamOneScore() > afcFourVsFive.GetTeamTwoScore())
            {
                if (higherRankedAFCTeam == null)
                    higherRankedAFCTeam = afcPlayoffTeams[3];
                else
                    lowerRankedAFCTeam = afcPlayoffTeams[3];
            }
            else
            {
                if (higherRankedAFCTeam == null)
                    higherRankedAFCTeam = afcPlayoffTeams[4];
                else
                    lowerRankedAFCTeam = afcPlayoffTeams[4];
            }

            Game nfcThreeVsSix = new Game(nfcPlayoffTeams[2], nfcPlayoffTeams[5], true);
            nfcPlayoffTeams[2].AddPlayoffResult(nfcPlayoffTeams[5], nfcThreeVsSix.GetTeamOneScore(), nfcThreeVsSix.GetTeamTwoScore());
            nfcPlayoffTeams[5].AddPlayoffResult(nfcPlayoffTeams[2], nfcThreeVsSix.GetTeamTwoScore(), nfcThreeVsSix.GetTeamOneScore());
            footballGame3.SetQuarterScore(1, nfcThreeVsSix.GetTeamOneQuarterScore(1), nfcThreeVsSix.GetTeamTwoQuarterScore(1));
            footballGame3.SetQuarterScore(2, nfcThreeVsSix.GetTeamOneQuarterScore(2), nfcThreeVsSix.GetTeamTwoQuarterScore(2));
            footballGame3.SetQuarterScore(3, nfcThreeVsSix.GetTeamOneQuarterScore(3), nfcThreeVsSix.GetTeamTwoQuarterScore(3));
            footballGame3.SetQuarterScore(4, nfcThreeVsSix.GetTeamOneQuarterScore(4), nfcThreeVsSix.GetTeamTwoQuarterScore(4));
            footballGame3.SetQuarterScore(5, nfcThreeVsSix.GetTeamOneQuarterScore(5), nfcThreeVsSix.GetTeamTwoQuarterScore(5));

            if (nfcThreeVsSix.GetTeamOneScore() > nfcThreeVsSix.GetTeamTwoScore())
            {
                higherRankedNFCTeam = nfcPlayoffTeams[2];
            }
            else
            {
                lowerRankedNFCTeam = nfcPlayoffTeams[5];
            }

            Game nfcFourVsFive = new Game(nfcPlayoffTeams[3], nfcPlayoffTeams[4], true);
            nfcPlayoffTeams[3].AddPlayoffResult(nfcPlayoffTeams[4], nfcFourVsFive.GetTeamOneScore(), nfcFourVsFive.GetTeamTwoScore());
            nfcPlayoffTeams[4].AddPlayoffResult(nfcPlayoffTeams[3], nfcFourVsFive.GetTeamTwoScore(), nfcFourVsFive.GetTeamOneScore());
            footballGame4.SetQuarterScore(1, nfcFourVsFive.GetTeamOneQuarterScore(1), nfcFourVsFive.GetTeamTwoQuarterScore(1));
            footballGame4.SetQuarterScore(2, nfcFourVsFive.GetTeamOneQuarterScore(2), nfcFourVsFive.GetTeamTwoQuarterScore(2));
            footballGame4.SetQuarterScore(3, nfcFourVsFive.GetTeamOneQuarterScore(3), nfcFourVsFive.GetTeamTwoQuarterScore(3));
            footballGame4.SetQuarterScore(4, nfcFourVsFive.GetTeamOneQuarterScore(4), nfcFourVsFive.GetTeamTwoQuarterScore(4));
            footballGame4.SetQuarterScore(5, nfcFourVsFive.GetTeamOneQuarterScore(5), nfcFourVsFive.GetTeamTwoQuarterScore(5));

            if (nfcFourVsFive.GetTeamOneScore() > nfcFourVsFive.GetTeamTwoScore())
            {
                if (higherRankedNFCTeam == null)
                    higherRankedNFCTeam = nfcPlayoffTeams[3];
                else
                    lowerRankedNFCTeam = nfcPlayoffTeams[3];
            }
            else
            {
                if (higherRankedNFCTeam == null)
                    higherRankedNFCTeam = nfcPlayoffTeams[4];
                else
                    lowerRankedNFCTeam = nfcPlayoffTeams[4];
            }

        }
        private void DivisionalRound()
        {
            Team topTeam = null, lowerTeam = null;


            footballGame1.SetTeamNames(afcPlayoffTeams[0].ToString(), lowerRankedAFCTeam.ToString());
            footballGame2.SetTeamNames(afcPlayoffTeams[1].ToString(), higherRankedAFCTeam.ToString());
            footballGame3.SetTeamNames(nfcPlayoffTeams[0].ToString(), lowerRankedNFCTeam.ToString());
            footballGame4.SetTeamNames(nfcPlayoffTeams[1].ToString(), higherRankedNFCTeam.ToString());

            Game afcThreeVsSix = new Game(afcPlayoffTeams[0], lowerRankedAFCTeam, true);
            afcPlayoffTeams[0].AddPlayoffResult(lowerRankedAFCTeam, afcThreeVsSix.GetTeamOneScore(), afcThreeVsSix.GetTeamTwoScore());
            lowerRankedAFCTeam.AddPlayoffResult(afcPlayoffTeams[0], afcThreeVsSix.GetTeamTwoScore(), afcThreeVsSix.GetTeamOneScore());


            Game afcFourVsFive = new Game(afcPlayoffTeams[1], higherRankedAFCTeam, true);
            afcPlayoffTeams[1].AddPlayoffResult(higherRankedAFCTeam, afcFourVsFive.GetTeamOneScore(), afcFourVsFive.GetTeamTwoScore());
            higherRankedAFCTeam.AddPlayoffResult(afcPlayoffTeams[1], afcFourVsFive.GetTeamTwoScore(), afcFourVsFive.GetTeamOneScore());

            Game nfcThreeVsSix = new Game(nfcPlayoffTeams[0], lowerRankedNFCTeam, true);
            nfcPlayoffTeams[0].AddPlayoffResult(lowerRankedNFCTeam, nfcThreeVsSix.GetTeamOneScore(), nfcThreeVsSix.GetTeamTwoScore());
            lowerRankedNFCTeam.AddPlayoffResult(nfcPlayoffTeams[0], nfcThreeVsSix.GetTeamTwoScore(), nfcThreeVsSix.GetTeamOneScore());


            Game nfcFourVsFive = new Game(nfcPlayoffTeams[1], higherRankedNFCTeam, true);
            nfcPlayoffTeams[1].AddPlayoffResult(higherRankedNFCTeam, nfcFourVsFive.GetTeamOneScore(), nfcFourVsFive.GetTeamTwoScore());
            higherRankedNFCTeam.AddPlayoffResult(nfcPlayoffTeams[1], nfcFourVsFive.GetTeamTwoScore(), nfcFourVsFive.GetTeamOneScore());

            footballGame1.SetQuarterScore(1, afcThreeVsSix.GetTeamOneQuarterScore(1), afcThreeVsSix.GetTeamTwoQuarterScore(1));
            footballGame1.SetQuarterScore(2, afcThreeVsSix.GetTeamOneQuarterScore(2), afcThreeVsSix.GetTeamTwoQuarterScore(2));
            footballGame1.SetQuarterScore(3, afcThreeVsSix.GetTeamOneQuarterScore(3), afcThreeVsSix.GetTeamTwoQuarterScore(3));
            footballGame1.SetQuarterScore(4, afcThreeVsSix.GetTeamOneQuarterScore(4), afcThreeVsSix.GetTeamTwoQuarterScore(4));
            footballGame1.SetQuarterScore(5, afcThreeVsSix.GetTeamOneQuarterScore(5), afcThreeVsSix.GetTeamTwoQuarterScore(5));

            if (afcThreeVsSix.GetTeamOneScore() > afcThreeVsSix.GetTeamTwoScore())
            {
                topTeam = afcPlayoffTeams[0];
            }
            else
            {
                lowerTeam = lowerRankedAFCTeam;
            }

            footballGame2.SetQuarterScore(1, afcFourVsFive.GetTeamOneQuarterScore(1), afcFourVsFive.GetTeamTwoQuarterScore(1));
            footballGame2.SetQuarterScore(2, afcFourVsFive.GetTeamOneQuarterScore(2), afcFourVsFive.GetTeamTwoQuarterScore(2));
            footballGame2.SetQuarterScore(3, afcFourVsFive.GetTeamOneQuarterScore(3), afcFourVsFive.GetTeamTwoQuarterScore(3));
            footballGame2.SetQuarterScore(4, afcFourVsFive.GetTeamOneQuarterScore(4), afcFourVsFive.GetTeamTwoQuarterScore(4));
            footballGame2.SetQuarterScore(5, afcFourVsFive.GetTeamOneQuarterScore(5), afcFourVsFive.GetTeamTwoQuarterScore(5));

            if (afcFourVsFive.GetTeamOneScore() > afcFourVsFive.GetTeamTwoScore())
            {
                if(topTeam == null)
                    topTeam = afcPlayoffTeams[1];
                else
                    lowerTeam = afcPlayoffTeams[1];
            }
            else
            {
                if (topTeam == null)
                    topTeam = higherRankedAFCTeam;
                else
                    lowerTeam = higherRankedAFCTeam;
            }

            lowerRankedAFCTeam = lowerTeam;
            higherRankedAFCTeam = topTeam;

            lowerTeam = topTeam = null;

            footballGame3.SetQuarterScore(1, nfcThreeVsSix.GetTeamOneQuarterScore(1), nfcThreeVsSix.GetTeamTwoQuarterScore(1));
            footballGame3.SetQuarterScore(2, nfcThreeVsSix.GetTeamOneQuarterScore(2), nfcThreeVsSix.GetTeamTwoQuarterScore(2));
            footballGame3.SetQuarterScore(3, nfcThreeVsSix.GetTeamOneQuarterScore(3), nfcThreeVsSix.GetTeamTwoQuarterScore(3));
            footballGame3.SetQuarterScore(4, nfcThreeVsSix.GetTeamOneQuarterScore(4), nfcThreeVsSix.GetTeamTwoQuarterScore(4));
            footballGame3.SetQuarterScore(5, nfcThreeVsSix.GetTeamOneQuarterScore(5), nfcThreeVsSix.GetTeamTwoQuarterScore(5));

            if (nfcThreeVsSix.GetTeamOneScore() > nfcThreeVsSix.GetTeamTwoScore())
            {
                topTeam = nfcPlayoffTeams[0];
            }
            else
            {
                lowerTeam = lowerRankedNFCTeam;
            }

            footballGame4.SetQuarterScore(1, nfcFourVsFive.GetTeamOneQuarterScore(1), nfcFourVsFive.GetTeamTwoQuarterScore(1));
            footballGame4.SetQuarterScore(2, nfcFourVsFive.GetTeamOneQuarterScore(2), nfcFourVsFive.GetTeamTwoQuarterScore(2));
            footballGame4.SetQuarterScore(3, nfcFourVsFive.GetTeamOneQuarterScore(3), nfcFourVsFive.GetTeamTwoQuarterScore(3));
            footballGame4.SetQuarterScore(4, nfcFourVsFive.GetTeamOneQuarterScore(4), nfcFourVsFive.GetTeamTwoQuarterScore(4));
            footballGame4.SetQuarterScore(5, nfcFourVsFive.GetTeamOneQuarterScore(5), nfcFourVsFive.GetTeamTwoQuarterScore(5));

            if (nfcFourVsFive.GetTeamOneScore() > nfcFourVsFive.GetTeamTwoScore())
            {
                if (topTeam == null)
                    topTeam = nfcPlayoffTeams[1];
                else
                    lowerTeam = nfcPlayoffTeams[1];
            }
            else
            {
                if (topTeam == null)
                    topTeam = higherRankedNFCTeam;
                else
                    lowerTeam = higherRankedNFCTeam;
            }


            lowerRankedNFCTeam = lowerTeam;
            higherRankedNFCTeam = topTeam;

        }
        private void ConferenceChampionships()
        {
            footballGame3.Visible = false;
            footballGame4.Visible = false;

            footballGame1.SetTeamNames(higherRankedAFCTeam.ToString(), lowerRankedAFCTeam.ToString());
            footballGame2.SetTeamNames(higherRankedNFCTeam.ToString(), lowerRankedNFCTeam.ToString());

            List<Team> teams = new List<Team>();

            Game afcChampionship = new Game(higherRankedAFCTeam, lowerRankedAFCTeam, true);
            higherRankedAFCTeam.AddPlayoffResult(lowerRankedAFCTeam, afcChampionship.GetTeamOneScore(), afcChampionship.GetTeamTwoScore());
            lowerRankedAFCTeam.AddPlayoffResult(higherRankedAFCTeam, afcChampionship.GetTeamTwoScore(), afcChampionship.GetTeamOneScore());
            footballGame1.SetQuarterScore(1, afcChampionship.GetTeamOneQuarterScore(1), afcChampionship.GetTeamTwoQuarterScore(1));
            footballGame1.SetQuarterScore(2, afcChampionship.GetTeamOneQuarterScore(2), afcChampionship.GetTeamTwoQuarterScore(2));
            footballGame1.SetQuarterScore(3, afcChampionship.GetTeamOneQuarterScore(3), afcChampionship.GetTeamTwoQuarterScore(3));
            footballGame1.SetQuarterScore(4, afcChampionship.GetTeamOneQuarterScore(4), afcChampionship.GetTeamTwoQuarterScore(4));
            footballGame1.SetQuarterScore(5, afcChampionship.GetTeamOneQuarterScore(5), afcChampionship.GetTeamTwoQuarterScore(5));

            if (afcChampionship.GetTeamOneScore() > afcChampionship.GetTeamTwoScore())
            {
                teams.Add(higherRankedAFCTeam);
            }
            else
            {
                teams.Add(lowerRankedAFCTeam);
            }

            Game nfcChampionship = new Game(higherRankedNFCTeam, lowerRankedNFCTeam, true);
            higherRankedNFCTeam.AddPlayoffResult(lowerRankedNFCTeam, nfcChampionship.GetTeamOneScore(), nfcChampionship.GetTeamTwoScore());
            lowerRankedNFCTeam.AddPlayoffResult(higherRankedNFCTeam, nfcChampionship.GetTeamTwoScore(), nfcChampionship.GetTeamOneScore());
            footballGame2.SetQuarterScore(1, nfcChampionship.GetTeamOneQuarterScore(1), nfcChampionship.GetTeamTwoQuarterScore(1));
            footballGame2.SetQuarterScore(2, nfcChampionship.GetTeamOneQuarterScore(2), nfcChampionship.GetTeamTwoQuarterScore(2));
            footballGame2.SetQuarterScore(3, nfcChampionship.GetTeamOneQuarterScore(3), nfcChampionship.GetTeamTwoQuarterScore(3));
            footballGame2.SetQuarterScore(4, nfcChampionship.GetTeamOneQuarterScore(4), nfcChampionship.GetTeamTwoQuarterScore(4));
            footballGame2.SetQuarterScore(5, nfcChampionship.GetTeamOneQuarterScore(5), nfcChampionship.GetTeamTwoQuarterScore(5));

            if (nfcChampionship.GetTeamOneScore() > nfcChampionship.GetTeamTwoScore())
            {
                teams.Add(higherRankedNFCTeam);
            }
            else
            {
                teams.Add(lowerRankedNFCTeam);
            }
            teams.Sort();

            higherRankedNFCTeam = teams[0];
            lowerRankedNFCTeam = teams[1];

        }
        private void SuperBowl()
        {
            Game superBowl = new Game(higherRankedNFCTeam, lowerRankedNFCTeam, true);

            higherRankedNFCTeam.AddPlayoffResult(lowerRankedNFCTeam, superBowl.GetTeamOneScore(), superBowl.GetTeamTwoScore(), true);
            lowerRankedNFCTeam.AddPlayoffResult(higherRankedNFCTeam, superBowl.GetTeamTwoScore(), superBowl.GetTeamOneScore(), true);
            footballGame2.Visible = false;

            footballGame1.SetTeamNames(higherRankedNFCTeam.ToString(), lowerRankedNFCTeam.ToString());

            footballGame1.SetQuarterScore(1, superBowl.GetTeamOneQuarterScore(1), superBowl.GetTeamTwoQuarterScore(1));
            footballGame1.SetQuarterScore(2, superBowl.GetTeamOneQuarterScore(2), superBowl.GetTeamTwoQuarterScore(2));
            footballGame1.SetQuarterScore(3, superBowl.GetTeamOneQuarterScore(3), superBowl.GetTeamTwoQuarterScore(3));
            footballGame1.SetQuarterScore(4, superBowl.GetTeamOneQuarterScore(4), superBowl.GetTeamTwoQuarterScore(4));
            footballGame1.SetQuarterScore(5, superBowl.GetTeamOneQuarterScore(5), superBowl.GetTeamTwoQuarterScore(5));


        }

        private void SeasonOver()
        {
            List<Team> theTeams = new List<Team>();
            nfcNorth.OrderTeams();
            nfcSouth.OrderTeams();
            nfcWest.OrderTeams();
            nfcEast.OrderTeams();
            afcNorth.OrderTeams();
            afcSouth.OrderTeams();
            afcWest.OrderTeams();
            afcEast.OrderTeams();

            theTeams.AddRange(nfcNorth.GetTeams());
            theTeams.AddRange(nfcEast.GetTeams());
            theTeams.AddRange(nfcSouth.GetTeams());
            theTeams.AddRange(nfcWest.GetTeams());

            theTeams.AddRange(afcNorth.GetTeams());
            theTeams.AddRange(afcEast.GetTeams());
            theTeams.AddRange(afcSouth.GetTeams());
            theTeams.AddRange(afcWest.GetTeams());

            teams = theTeams;

            foreach(Team team in teams)
            {
                team.ResetSeason();
            }
            footballGame1.Reset();
            footballGame2.Reset();
            footballGame3.Reset();
            footballGame4.Reset();
        }


        private void PlayGamesButton_Click(object sender, EventArgs e)
        {
            switch(stage)
            {
                case 0:
                    SeasonOver();
                    PlaySeason();
                    break;
                case 1:
                    WildCardRound();
                    break;
                case 2:
                    DivisionalRound();
                    break;
                case 3:
                    ConferenceChampionships();
                    break;
                case 4:
                    SuperBowl();
                    break;
            }
            stage = (stage + 1) % 5;
        }
        private void Play100Seasons(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {                
                SeasonOver();
                PlaySeason();
                WildCardRound();
                DivisionalRound();
                ConferenceChampionships();
                SuperBowl();
                        
            }
            string content = "";

            content += nfcNorth.GetFranchiseResults();
            content += nfcEast.GetFranchiseResults();
            content += nfcSouth.GetFranchiseResults();
            content += nfcWest.GetFranchiseResults();

            content += afcNorth.GetFranchiseResults();
            content += afcEast.GetFranchiseResults();
            content += afcSouth.GetFranchiseResults();
            content += afcWest.GetFranchiseResults();

            File.WriteAllText("results.csv", content);
        }
    }
    
}
