using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Score;
        private int player1Score;
        private string player1Name;
        private string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score;

            if ((player1Score < 4 && player2Score < 4) && (player1Score + player2Score < 6))
            {
                string[] scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };
                score = scoreNames[player1Score];

                if (this.player1Score == this.player2Score)
                {
                    score += "-All";
                }
                else
                {
                    score += $"-{scoreNames[this.player2Score]}";
                }
            }
            else
            {
                if (player1Score == player2Score)
                {
                    return "Deuce";
                }
                string playerAhead = player1Score > player2Score ? player1Name : player2Name;
                string gameStatus = Math.Abs(player1Score - player2Score) == 1 ? "Advantage" : "Win for";

                score = $"{gameStatus} {playerAhead}";
            }

            return score;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this.player1Name)
            {
                this.player1Score++;
            }
            else if (playerName == this.player2Name)
            {
                this.player2Score++;
            }
        }

    }
}

