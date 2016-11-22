using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{

    public class RobsTennisGame : ITennisGame
    {
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        public RobsTennisGame(string player1Name, string player2Name)
        {
            this.Player1 = new Player(player1Name);
            this.Player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            string score;

            int scoreDifference = this.Player1.Score - this.Player2.Score;

            // tie game
            if (scoreDifference == 0)
            {
                score = (this.Player1.Score >= 3) ?
                    "Deuce" :
                    this.Player1.Score.ToTennisScore() + "-All";
            }
            // advantage and win conditions
            else if (this.Player1.Score >= 4 || this.Player2.Score >= 4)
            {
                string outcome = (Math.Abs(scoreDifference) == 1) ? "Advantage" : "Win for";
                Player leadingPlayer = (scoreDifference > 0) ? this.Player1 : this.Player2;
                score = $"{outcome} {leadingPlayer.Name}";
            }
            // "standard" conditions
            else
            {
                score = $"{this.Player1.Score.ToTennisScore()}-{this.Player2.Score.ToTennisScore()}";
            }

            return score;
        }

        public void WonPoint(string playerName)
        {
            if (this.Player1.Name == playerName)
            {
                this.Player1.Score++;
            }
            else if (this.Player2.Name == playerName)
            {
                this.Player2.Score++;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Unable to assign point. Invalid player name: {playerName}.");
            }
        }
    }

    public static class ExtensionMethods { 
        public static string ToTennisScore(this int rawScore)
        {
            string result;

            switch (rawScore)
            {
                case 0: result = "Love";    break;
                case 1: result = "Fifteen"; break;
                case 2: result = "Thirty";  break;
                case 3: result = "Forty";   break;
                default: throw new ArgumentOutOfRangeException($"Unable to determine tennis score from raw score: {rawScore}.");
            }

            return result;
        }
    }
}
