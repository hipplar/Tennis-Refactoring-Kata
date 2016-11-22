using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string player1Result = "";
        private string player2Result = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (p1point == p2point)
            {
                switch (this.p1point)
                {
                    case 0: score = "Love"; break;
                    case 1: score = "Fifteen"; break;
                    case 2: score = "Thirty"; break;
                    default: score = "Deuce"; break;
                }
                if (p1point < 3)
                {
                    score += "-All";
                }
            }
            else
            {
                switch (this.p1point)
                {
                    case 0: this.player1Result = "Love"; break;
                    case 1: this.player1Result = "Fifteen"; break;
                    case 2: this.player1Result = "Thirty"; break;
                    case 3: this.player1Result = "Forty"; break;
                    default: break;
                }
                switch (this.p2point)
                {
                    case 0: this.player2Result = "Love"; break;
                    case 1: this.player2Result = "Fifteen"; break;
                    case 2: this.player2Result = "Thirty"; break;
                    case 3: this.player2Result = "Forty"; break;
                    default: break;
                }

                if (this.p1point <= 3 && this.p2point <= 3)
                {
                    score = $"{this.player1Result}-{this.player2Result}";
                }
                else
                {
                    int scoreDifference = this.p1point - this.p2point;
                    
                    if (p1point > p2point && p2point >= 3)
                    {
                        score = $"Advantage {this.player1Name}";
                    }

                    if (p2point > p1point && p1point >= 3)
                    {
                        score = $"Advantage {this.player2Name}";
                    }

                    if (p1point >= 4 && (p1point - p2point) >= 2)
                    {
                        score = $"Win for {this.player1Name}";
                    }
                    if (p2point >= 4 && (p2point - p1point) >= 2)
                    {
                        score = $"Win for {this.player2Name}";
                    }
                }
            }
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == this.player1Name)
            {
                this.p1point++;
            }
            else if (player == this.player2Name)
            {
                this.p2point++;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Unable to assign point. Invalid player name: {player}.");
            }
        }

    }
}

