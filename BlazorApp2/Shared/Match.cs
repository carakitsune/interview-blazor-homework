using System.Collections.Generic;

namespace BlazorApp2.Shared
{
    public class Match {
        public string winner;
        public bool isTiebreakMode;
        public int player1Score;
        public int player2Score;
        public List<Set> sets = new List<Set>();
        public string[] errors;
        
        public void Play(string[] wins) {
            string[] futureWins = wins;
            while (this.winner == null) {
                Set set = new Set();
                futureWins = set.Play(true, futureWins);
                this.sets.Add(set);
                this.UpdateWinner();
            }
            errors = futureWins;
        }
        private void UpdateWinner() {
            if (player1Score == 3) {this.winner = "1";}
            if (player2Score == 3) {this.winner = "2";}
        }
    }
}