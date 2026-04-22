using Interfaces.Score;
using TMPro;
using UnityEngine;

namespace Game.Score
{
    public class ScoreSystem : MonoBehaviour, IScoreService
    {
        [SerializeField] private TMP_Text _scoreText;

        private int _currentScore = 0;

        public void AddScore(int score)
        {
            _currentScore += score;

            UpdateView();
        }

        private void UpdateView()
        {
            _scoreText.text = _currentScore.ToString();
        }
    }
}