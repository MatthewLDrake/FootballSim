namespace Football
{
    public class Record
    {
        private int wins, losses, ties;
        public Record()
        {

        }
        public void AddWin()
        {
            wins++;
        }
        public void AddLoss()
        {
            losses++;
        }
        public void AddTie()
        {
            ties++;
        }
        public void AddWins(int num)
        {
            wins += num;
        }
        public void AddLosses(int num)
        {
            losses += num;
        }
        public void AddTies(int num)
        {
            ties += num;
        }
        public int GetWins()
        {
            return wins;
        }
        public int GetLosses()
        {
            return losses;
        }
        public int GetTies()
        {
            return ties;
        }
        public int GetResult()
        {
            return losses - wins;
        }
    }
}