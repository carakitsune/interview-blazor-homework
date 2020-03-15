using System.Collections.Generic;

namespace BlazorApp2.Shared
{
    public class Game {
        public string winner { get; set; }
        public bool isOngoing { get; set; } = true;
        public int player1Score { get; set; }
        public int player2Score { get; set; }

        public int minPointsForWin { get; set; }

        public List<string> Play(List<string> wins, int minPointsForWin) {
            List<string> futureWins = new List<string>();
            this.minPointsForWin = minPointsForWin;

            foreach (var win in wins)
            {
                if(this.isOngoing) {
                    this.PlayRound(win); 
                    this.UpdateWinner(win);
                }
                else { futureWins.Add(win); }
            }
            return futureWins;
        }
        private void PlayRound (string winningPlayer) {
            System.Console.Write("WinningPlayer: " + winningPlayer + "\n");
            if (winningPlayer == "1") { this.player1Score++; } 
            else { this.player2Score++; }
        }

        private void UpdateWinner(string win) {
            if (this.HasWon(win)) {
                this.isOngoing = false;
                this.winner = win;
            }
        }

        private bool HasWon(string player) {
            if (this.minPointsForWin <= this.ScoreOf(player) && this.ScoreOf(player) > this.ScoreOfEnemy(player)+1) { return true; }
            return false;
        }

        private int ScoreOf(string player) {
            if (player == "1") { return this.player1Score; }
            else { return this.player2Score; }
        }

        private int ScoreOfEnemy(string player) {
            if (player == "1") { return this.player2Score; }
            else { return this.player1Score; }
        }
    }
}