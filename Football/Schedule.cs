using System;
using System.Collections.Generic;

namespace Football
{
    internal class Schedule
    {
        private int crossOrientation, interOrientation;
        private bool crossBool, interBool;
        private List<Week> games;
        public Schedule()
        {
            crossOrientation = 0;
            interOrientation = 0;
        }
        public List<Week> CreateNewSchedule()
        {
            games = new List<Week>();
            for(int i = 0; i < 16; i++)
            {
                games.Add(new Week());
            }

            AddDivisionGames();
            switch(crossOrientation)
            {
                case 0:
                    CrossOne();
                    break;
                case 1:
                    CrossTwo();
                    break;
                case 2:
                    CrossThree();
                    break;
                case 3:
                    CrossFour();
                    break;
            }
            if (!crossBool)
            {
                games[6].Flip();
                games[7].Flip();
                games[8].Flip();
                games[9].Flip();
            }
            switch (interOrientation)
            {
                case 0:
                    InterOne();
                    break;
                case 1:
                    InterTwo();
                    break;
                case 2:
                    InterThree();
                    break;
            }
            if (!interBool)
            {
                games[10].Flip();
                games[11].Flip();
                games[12].Flip();
                games[13].Flip();
                games[14].Flip();
                games[15].Flip();
            }

            crossOrientation = (crossOrientation + 1) % 4;
            if (crossOrientation == 0)
                crossBool = !crossBool;

            interOrientation = (interOrientation + 1) % 3;
            if (interOrientation == 0)
                interBool = !interBool;

            games.Shuffle();

            return games;
        }
#region Cross Play
        private void CrossOne()
        {
            
            for(int i = 0; i < 16; i += 4)
            {
                games[6].AddGame(i, i + 16);
                games[6].AddGame(i + 1, i + 17);
                games[6].AddGame(i + 2, i + 18);
                games[6].AddGame(i + 3, i + 19);

                games[7].AddGame(i, i + 17);
                games[7].AddGame(i + 1, i + 18);
                games[7].AddGame(i + 2, i + 19);
                games[7].AddGame(i + 3, i + 16);

                games[8].AddGame(i + 18, i);
                games[8].AddGame(i + 19, i + 1);
                games[8].AddGame(i + 16, i + 2);
                games[8].AddGame(i + 17, i +3);

                games[9].AddGame(i + 19, i);
                games[9].AddGame(i + 16, i + 1);
                games[9].AddGame(i + 17, i + 2);
                games[9].AddGame(i + 18, i + 3);
            }
            
        }
        private void CrossTwo()
        {
            for (int i = 0; i < 12; i += 4)
            {
                games[6].AddGame(i, i + 20);
                games[6].AddGame(i + 1, i + 21);
                games[6].AddGame(i + 2, i + 22);
                games[6].AddGame(i + 3, i + 23);

                games[7].AddGame(i, i + 21);
                games[7].AddGame(i + 1, i + 22);
                games[7].AddGame(i + 2, i + 23);
                games[7].AddGame(i + 3, i + 20);

                games[8].AddGame(i + 22, i);
                games[8].AddGame(i + 23, i + 1);
                games[8].AddGame(i + 20, i + 2);
                games[8].AddGame(i + 21, i + 3);

                games[9].AddGame(i + 23, i);
                games[9].AddGame(i + 20, i + 1);
                games[9].AddGame(i + 21, i + 2);
                games[9].AddGame(i + 22, i + 3);
            }
            games[6].AddGame(12, 16);
            games[6].AddGame(13, 17);
            games[6].AddGame(14, 18);
            games[6].AddGame(15, 19);

            games[7].AddGame(12, 17);
            games[7].AddGame(13, 18);
            games[7].AddGame(14, 19);
            games[7].AddGame(15, 16);

            games[8].AddGame(18, 12);
            games[8].AddGame(19, 13);
            games[8].AddGame(16, 14);
            games[8].AddGame(17, 15);

            games[9].AddGame(19, 12);
            games[9].AddGame(16, 13);
            games[9].AddGame(17, 14);
            games[9].AddGame(18, 15);
           
        }
        private void CrossThree()
        {
            
            for (int i = 0; i < 8; i += 4)
            {
                games[6].AddGame(i, i + 24);
                games[6].AddGame(i + 1, i + 25);
                games[6].AddGame(i + 2, i + 26);
                games[6].AddGame(i + 3, i + 27);

                games[7].AddGame(i, i +25);
                games[7].AddGame(i + 1, i + 26);
                games[7].AddGame(i + 2, i + 27);
                games[7].AddGame(i + 3, i + 24);

                games[8].AddGame(i + 26, i);
                games[8].AddGame(i + 27, i + 1);
                games[8].AddGame(i + 24, i + 2);
                games[8].AddGame(i + 25, i + 3);

                games[9].AddGame(i + 27, i);
                games[9].AddGame(i + 24, i + 1);
                games[9].AddGame(i + 25, i + 2);
                games[9].AddGame(i + 26, i + 3);
            }
            games[6].AddGame(12, 20);
            games[6].AddGame(13, 21);
            games[6].AddGame(14, 22);
            games[6].AddGame(15, 23);

            games[7].AddGame(12, 21);
            games[7].AddGame(13, 22);
            games[7].AddGame(14, 23);
            games[7].AddGame(15, 20);

            games[8].AddGame(22, 12);
            games[8].AddGame(23, 13);
            games[8].AddGame(20, 14);
            games[8].AddGame(21, 15);

            games[9].AddGame(23, 12);
            games[9].AddGame(20, 13);
            games[9].AddGame(21, 14);
            games[9].AddGame(22, 15);

            games[6].AddGame(8, 16);
            games[6].AddGame(9, 17);
            games[6].AddGame(10, 18);
            games[6].AddGame(11, 19);

            games[7].AddGame(8, 17);
            games[7].AddGame(9, 18);
            games[7].AddGame(10, 19);
            games[7].AddGame(11, 16);

            games[8].AddGame(18, 8);
            games[8].AddGame(19, 9);
            games[8].AddGame(16, 10);
            games[8].AddGame(17, 11);

            games[9].AddGame(19, 8);
            games[9].AddGame(16, 9);
            games[9].AddGame(17, 10);
            games[9].AddGame(18, 11);

        }
        private void CrossFour()
        {
            games[6].AddGame(0, 28);
            games[6].AddGame(1, 29);
            games[6].AddGame(2, 30);
            games[6].AddGame(3, 31);
        
            games[7].AddGame(0, 29);
            games[7].AddGame(1, 30);
            games[7].AddGame(2, 31);
            games[7].AddGame(3, 28);

            games[8].AddGame(0, 30);
            games[8].AddGame(1, 31);
            games[8].AddGame(2, 28);
            games[8].AddGame(3, 29);

            games[9].AddGame(0, 31);
            games[9].AddGame(1, 28);
            games[9].AddGame(2, 29);
            games[9].AddGame(3, 30);

            for (int i = 4; i < 16; i += 4)
            {
                games[6].AddGame(i, i + 12);
                games[6].AddGame(i + 1, i + 13);
                games[6].AddGame(i + 2, i + 14);
                games[6].AddGame(i + 3, i + 15);

                games[7].AddGame(i, i + 13);
                games[7].AddGame(i + 1, i + 14);
                games[7].AddGame(i + 2, i + 15);
                games[7].AddGame(i + 3, i + 12);

                games[8].AddGame(i + 14, i);
                games[8].AddGame(i + 15, i + 1);
                games[8].AddGame(i + 12, i + 2);
                games[8].AddGame(i + 13, i + 3);

                games[9].AddGame(i + 15, i);
                games[9].AddGame(i + 12, i + 1);
                games[9].AddGame(i + 13, i + 2);
                games[9].AddGame(i + 14, i + 3);
            }
        }
        #endregion
#region InterPlay
        private void InterOne()
        {
            games[10].AddGame(0, 4);
            games[10].AddGame(1, 5);
            games[10].AddGame(2, 6);
            games[10].AddGame(3, 7);
            games[10].AddGame(8, 12);
            games[10].AddGame(9, 13);
            games[10].AddGame(10, 14);
            games[10].AddGame(11, 15);
            games[10].AddGame(16, 20);
            games[10].AddGame(17, 21);
            games[10].AddGame(18, 22);
            games[10].AddGame(19, 23);
            games[10].AddGame(24, 28);
            games[10].AddGame(25, 29);
            games[10].AddGame(26, 30);
            games[10].AddGame(27, 31);

            games[11].AddGame(0, 5);
            games[11].AddGame(1, 6);
            games[11].AddGame(2, 7);
            games[11].AddGame(3, 4);
            games[11].AddGame(8, 13);
            games[11].AddGame(9, 14);
            games[11].AddGame(10, 15);
            games[11].AddGame(11, 12);
            games[11].AddGame(16, 21);
            games[11].AddGame(17, 22);
            games[11].AddGame(18, 23);
            games[11].AddGame(19, 20);
            games[11].AddGame(24, 29);
            games[11].AddGame(25, 30);
            games[11].AddGame(26, 31);
            games[11].AddGame(27, 28);

            games[12].AddGame(6, 0);
            games[12].AddGame(7, 1);
            games[12].AddGame(4, 2);
            games[12].AddGame(5, 3);
            games[12].AddGame(14, 8);
            games[12].AddGame(15, 9);
            games[12].AddGame(12, 10);
            games[12].AddGame(13, 11);
            games[12].AddGame(22, 16);
            games[12].AddGame(23, 17);
            games[12].AddGame(20, 18);
            games[12].AddGame(21, 19);
            games[12].AddGame(30, 24);
            games[12].AddGame(31, 25);
            games[12].AddGame(28, 26);
            games[12].AddGame(29, 27);

            games[13].AddGame(7, 0);
            games[13].AddGame(4, 1);
            games[13].AddGame(5, 2);
            games[13].AddGame(6, 3);
            games[13].AddGame(15, 8);
            games[13].AddGame(12, 9);
            games[13].AddGame(13, 10);
            games[13].AddGame(14, 11);
            games[13].AddGame(23, 16);
            games[13].AddGame(20, 17);
            games[13].AddGame(21, 18);
            games[13].AddGame(22, 19);
            games[13].AddGame(31, 24);
            games[13].AddGame(28, 25);
            games[13].AddGame(29, 26);
            games[13].AddGame(30, 27);

            games[14].AddGame(0, 8);
            games[14].AddGame(1, 9);
            games[14].AddGame(2, 10);
            games[14].AddGame(3, 11);
            games[14].AddGame(4, 12);
            games[14].AddGame(5, 13);
            games[14].AddGame(6, 14);
            games[14].AddGame(7, 15);
            games[14].AddGame(16, 24);
            games[14].AddGame(17, 25);
            games[14].AddGame(18, 26);
            games[14].AddGame(19, 27);
            games[14].AddGame(20, 28);
            games[14].AddGame(21, 29);
            games[14].AddGame(22, 30);
            games[14].AddGame(23, 31);

            games[15].AddGame(12, 0);
            games[15].AddGame(13, 1);
            games[15].AddGame(14, 2);
            games[15].AddGame(15, 3);
            games[15].AddGame(8, 4);
            games[15].AddGame(9, 5);
            games[15].AddGame(10, 6);
            games[15].AddGame(11, 7);
            games[15].AddGame(28, 16);
            games[15].AddGame(29, 17);
            games[15].AddGame(30, 18);
            games[15].AddGame(31, 19);
            games[15].AddGame(24, 20);
            games[15].AddGame(25, 21);
            games[15].AddGame(26, 22);
            games[15].AddGame(27, 23);
        }
        private void InterTwo()
        {
            games[10].AddGame(0, 8);
            games[10].AddGame(1, 9);
            games[10].AddGame(2, 10);
            games[10].AddGame(3, 11);
            games[10].AddGame(4, 12);
            games[10].AddGame(5, 13);
            games[10].AddGame(6, 14);
            games[10].AddGame(7, 15);
            games[10].AddGame(16, 24);
            games[10].AddGame(17, 25);
            games[10].AddGame(18, 26);
            games[10].AddGame(19, 27);
            games[10].AddGame(20, 28);
            games[10].AddGame(21, 29);
            games[10].AddGame(22, 30);
            games[10].AddGame(23, 31);

            games[11].AddGame(0, 9);
            games[11].AddGame(1, 10);
            games[11].AddGame(2, 11);
            games[11].AddGame(3, 8);
            games[11].AddGame(4, 13);
            games[11].AddGame(5, 14);
            games[11].AddGame(6, 15);
            games[11].AddGame(7, 12);
            games[11].AddGame(16, 25);
            games[11].AddGame(17, 26);
            games[11].AddGame(18, 27);
            games[11].AddGame(19, 24);
            games[11].AddGame(20, 29);
            games[11].AddGame(21, 30);
            games[11].AddGame(22, 31);
            games[11].AddGame(23, 28);

            games[12].AddGame(10, 0);
            games[12].AddGame(11, 1);
            games[12].AddGame(8, 2);
            games[12].AddGame(9, 3);
            games[12].AddGame(14, 4);
            games[12].AddGame(15, 5);
            games[12].AddGame(12, 6);
            games[12].AddGame(13, 7);
            games[12].AddGame(26, 16);
            games[12].AddGame(27, 17);
            games[12].AddGame(24, 18);
            games[12].AddGame(25, 19);
            games[12].AddGame(30, 20);
            games[12].AddGame(31, 21);
            games[12].AddGame(28, 22);
            games[12].AddGame(29, 23);

            games[13].AddGame(11, 0);
            games[13].AddGame(8, 1);
            games[13].AddGame(9, 2);
            games[13].AddGame(10, 3);
            games[13].AddGame(15, 4);
            games[13].AddGame(12, 5);
            games[13].AddGame(13, 6);
            games[13].AddGame(14, 7);
            games[13].AddGame(27, 16);
            games[13].AddGame(24, 17);
            games[13].AddGame(25, 18);
            games[13].AddGame(26, 19);
            games[13].AddGame(31, 20);
            games[13].AddGame(28, 21);
            games[13].AddGame(29, 22);
            games[13].AddGame(30, 23);

            games[14].AddGame(0, 4);
            games[14].AddGame(1, 5);
            games[14].AddGame(2, 6);
            games[14].AddGame(3, 7);
            games[14].AddGame(8, 12);
            games[14].AddGame(9, 13);
            games[14].AddGame(10, 14);
            games[14].AddGame(11, 15);
            games[14].AddGame(16, 20);
            games[14].AddGame(17, 21);
            games[14].AddGame(18, 22);
            games[14].AddGame(19, 23);
            games[14].AddGame(24, 28);
            games[14].AddGame(25, 29);
            games[14].AddGame(26, 30);
            games[14].AddGame(27, 31);

            games[15].AddGame(12, 0);
            games[15].AddGame(13, 1);
            games[15].AddGame(14, 2);
            games[15].AddGame(15, 3);
            games[15].AddGame(4, 8);
            games[15].AddGame(5, 9);
            games[15].AddGame(6, 10);
            games[15].AddGame(7, 11);
            games[15].AddGame(28, 16);
            games[15].AddGame(29, 17);
            games[15].AddGame(30, 18);
            games[15].AddGame(31, 19);
            games[15].AddGame(20, 24);
            games[15].AddGame(21, 25);
            games[15].AddGame(22, 26);
            games[15].AddGame(23, 27);
        }
        private void InterThree()
        {
            games[10].AddGame(0, 12);
            games[10].AddGame(1, 13);
            games[10].AddGame(2, 14);
            games[10].AddGame(3, 15);
            games[10].AddGame(4, 8);
            games[10].AddGame(5, 9);
            games[10].AddGame(6, 10);
            games[10].AddGame(7, 11);
            games[10].AddGame(16, 28);
            games[10].AddGame(17, 29);
            games[10].AddGame(18, 30);
            games[10].AddGame(19, 31);
            games[10].AddGame(20, 24);
            games[10].AddGame(21, 25);
            games[10].AddGame(22, 26);
            games[10].AddGame(23, 27);

            games[11].AddGame(0, 13);
            games[11].AddGame(1, 14);
            games[11].AddGame(2, 15);
            games[11].AddGame(3, 12);
            games[11].AddGame(4, 9);
            games[11].AddGame(5, 10);
            games[11].AddGame(6, 11);
            games[11].AddGame(7, 8);
            games[11].AddGame(16, 29);
            games[11].AddGame(17, 30);
            games[11].AddGame(18, 31);
            games[11].AddGame(19, 28);
            games[11].AddGame(20, 25);
            games[11].AddGame(21, 26);
            games[11].AddGame(22, 27);
            games[11].AddGame(23, 24);

            games[12].AddGame(14, 0);
            games[12].AddGame(15, 1);
            games[12].AddGame(12, 2);
            games[12].AddGame(13, 3);
            games[12].AddGame(10, 4);
            games[12].AddGame(11, 5);
            games[12].AddGame(8, 6);
            games[12].AddGame(9, 7);
            games[12].AddGame(30, 16);
            games[12].AddGame(31, 17);
            games[12].AddGame(28, 18);
            games[12].AddGame(29, 19);
            games[12].AddGame(26, 20);
            games[12].AddGame(27, 21);
            games[12].AddGame(24, 22);
            games[12].AddGame(25, 23);

            games[13].AddGame(15, 0);
            games[13].AddGame(12, 1);
            games[13].AddGame(13, 2);
            games[13].AddGame(14, 3);
            games[13].AddGame(11, 4);
            games[13].AddGame(8, 5);
            games[13].AddGame(9, 6);
            games[13].AddGame(10, 7);
            games[13].AddGame(31, 16);
            games[13].AddGame(28, 17);
            games[13].AddGame(29, 18);
            games[13].AddGame(30, 19);
            games[13].AddGame(27, 20);
            games[13].AddGame(24, 21);
            games[13].AddGame(25, 22);
            games[13].AddGame(26, 23);

            games[14].AddGame(4, 0);
            games[14].AddGame(5, 1);
            games[14].AddGame(6, 2);
            games[14].AddGame(7, 3);
            games[14].AddGame(8, 12);
            games[14].AddGame(9, 13);
            games[14].AddGame(10, 14);
            games[14].AddGame(11, 15);
            games[14].AddGame(20, 16);
            games[14].AddGame(21, 17);
            games[14].AddGame(22, 18);
            games[14].AddGame(23, 19);
            games[14].AddGame(24, 28);
            games[14].AddGame(25, 29);
            games[14].AddGame(26, 30);
            games[14].AddGame(27, 31);

            games[15].AddGame(0, 8);
            games[15].AddGame(1, 9);
            games[15].AddGame(2, 10);
            games[15].AddGame(3, 11);
            games[15].AddGame(12, 4);
            games[15].AddGame(13, 5);
            games[15].AddGame(14, 6);
            games[15].AddGame(15, 7);
            games[15].AddGame(16, 24);
            games[15].AddGame(17, 25);
            games[15].AddGame(18, 26);
            games[15].AddGame(19, 27);
            games[15].AddGame(28, 20);
            games[15].AddGame(29, 21);
            games[15].AddGame(30, 22);
            games[15].AddGame(31, 23);

        }
#endregion
        private void  AddDivisionGames()
        {
            for (int i = 0; i < 32; i += 4)
            {
                games[0].AddGame(i, i + 1);
                games[0].AddGame(i + 2, i + 3);

                games[1].AddGame(i, i + 2);
                games[1].AddGame(i + 1, i + 3);

                games[2].AddGame(i, i + 3);
                games[2].AddGame(i + 1, i + 2);

                games[3].AddGame(i + 1, i);
                games[3].AddGame(i + 3, i + 2);

                games[4].AddGame(i + 2, i);
                games[4].AddGame(i + 3, i + 1);

                games[5].AddGame(i + 3, i);
                games[5].AddGame(i + 2, i + 1);
            }
        }
    }

    class Week
    {
        private List<Tuple<int, int>> games;
        public Week()
        {
            games = new List<Tuple<int, int>>();
        }
        public void AddGame(int awayTeam, int homeTeam)
        {
            games.Add(new Tuple<int, int>(awayTeam, homeTeam));
        }
        public void Flip()
        {
            List<Tuple<int, int>> newGames = new List<Tuple<int, int>>();
            foreach(Tuple<int, int> game in games)
            {
                newGames.Add(new Tuple<int, int>(game.Item2, game.Item1));
            }
            games = newGames;
        }
        public List<Tuple<int, int>> GetGames()
        {
            return games;
        }
    }
    [Serializable]
    public static class IEnumerableExtensions
    {

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.GetInstance().Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
