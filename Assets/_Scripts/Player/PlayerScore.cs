using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerScore : MonoBehaviour
    {
        public int Score;
        public int Highscore;

        public void AddScore(int amount)
        {
            Score += amount;

            if (Score > Highscore)
            {
                Highscore = Score;
            }
        }

        public void RemoveScore(int amount)
        {
            Score -= amount;
        }

        public void ResetScore()
        {
            Score = 0;
        }
    }
}
