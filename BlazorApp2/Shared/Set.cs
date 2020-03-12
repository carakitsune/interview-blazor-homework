using BlazorApp2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp2.Shared
{
    public class Set {
        public string winner;
        public bool isOngoing;
        public int player1Score;
        public int player2Score;
        public List<Game> games = new List<Game>();
        public Game tiebreak;
        public bool inTiebreak;

        public string[] Play(bool isTiebreakMode, string[] wins) {
            List<string> futureWins = new List<string>(wins);
            while (winner == null) {
                if (this.inTiebreak) { futureWins = PlayTiebreak(futureWins); }
                else { 
                    futureWins = PlayGame(futureWins);
                    this.UpdateWinner();
                    this.UpdateTiebreak(isTiebreakMode);
                }
            }
            return futureWins.ToArray();
        }

        private void UpdateWinner() {
            if (Math.Abs(this.player1Score - this.player2Score) > 1) {
                if (player1Score > player2Score && player1Score > 5) {this.winner = "1";}
                if (player2Score > player1Score && player2Score > 5) {this.winner = "2";}
            }
        }

        private void UpdateTiebreak(bool isTiebreakMode) {
            if ( isTiebreakMode && this.player1Score == 6 && this.player2Score == 6) 
            { this.inTiebreak = true; }
        }

        private List<string> PlayGame(List<string> wins) {
            List<string> futureWins = new List<string>(wins);
            Game game = new Game();
            futureWins = game.Play(futureWins, 4);
            this.ScoreWinner(game.winner);
            this.games.Add(game);
            return futureWins;
        }

        private void ScoreWinner(String winner) {
            if (winner == "1") { this.player1Score++; } 
            else { this.player2Score++; }
        }

        private List<string> PlayTiebreak(List<string> wins) {
            Game game = new Game();
            List<string> futureWins = game.Play(wins, 6);
            this.tiebreak = game;
            this.isOngoing = false;
            this.winner = tiebreak.winner;
            return futureWins;
        }
    }
}