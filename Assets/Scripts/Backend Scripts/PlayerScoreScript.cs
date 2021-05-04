using System;

namespace PlayerScoreScript
{
    public class PlayerScore : IComparable<PlayerScore>
    {
        public string playerName;
        public int highScore;
        public int highestCombo;

        public PlayerScore(string playerName, int highScore, int highestCombo)
        {
            this.playerName = playerName;
            this.highScore = highScore;
            this.highestCombo = highestCombo;
        }

        public int CompareTo(PlayerScore otherScore)
        {
            if (otherScore == null)
                return 1;
            if (this.highScore > otherScore.highScore)
                return 1;
            if (this.highScore < otherScore.highScore)
                return -1;
            if (this.highScore == otherScore.highScore)
            {
                if (this.highestCombo > otherScore.highestCombo)
                    return 1;
                if (this.highestCombo < otherScore.highestCombo)
                    return -1;
            }

            return 0;
        }
    }
}
