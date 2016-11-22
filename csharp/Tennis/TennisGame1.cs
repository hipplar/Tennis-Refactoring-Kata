using System;

namespace Tennis
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
        }
    }

    class TennisGame1 : ITennisGame
    {
        private Player player1;
        private Player player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (this.player1.Name == playerName)
            {
                this.player1.Score++;
            }
            else if (this.player2.Name == playerName)
            {
                this.player2.Score++;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Unable to assign point. Invalid player name: {playerName}.");
            }
        }

        public string GetScore()
        {
            string score = "";

            if (this.player1.Score == this.player2.Score)
            {
                switch (this.player1.Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (this.player1.Score >= 4 || this.player2.Score >= 4)
            {
                int scoreDifference = this.player1.Score - this.player2.Score;
                Player playerAhead = (scoreDifference > 0) ? this.player1 : this.player2;
                string result = (Math.Abs(scoreDifference) == 1) ? "Advantage" : "Win for";

                score = $"{result} {playerAhead.Name}";
            }
            else
            {
                int tempScore;
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = this.player1.Score;
                    else { score += "-"; tempScore = this.player2.Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

