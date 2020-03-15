using System.Collections.Generic;

namespace BlazorApp2.Shared
{
    public class Match {
        public string winner { get; set; }
        public bool isTiebreakMode { get; set; }
        public int player1Score { get; set; }
        public int player2Score { get; set; }
        public List<Set> sets { get; set; } = new List<Set>();
        public string[] errors { get; set; }
        
        public void Play(string[] wins) {
            string[] futureWins = wins;
            while (this.winner == null) {
                Set set = new Set();
                futureWins = set.Play(false, futureWins);
                this.sets.Add(set);
                this.ScoreWinner(set.winner);
                this.UpdateWinner();
            }
            this.errors = futureWins;
        }
        private void UpdateWinner() {
            if (this.player1Score == 2) {this.winner = "1";}
            if (this.player2Score == 2) {this.winner = "2";}
        }

        private void ScoreWinner(string setWinner) {
            if (setWinner == "1") { this.player1Score++; } 
            else { this.player2Score++; }
        }
    }
}