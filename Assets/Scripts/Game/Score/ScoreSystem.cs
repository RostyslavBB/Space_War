using Game.DI;
using Game.Enemies;
using Interfaces.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Score
{
    public class ScoreSystem : MonoBehaviour, IScoreService
    {
        [SerializeField] private TMP_Text _scoreText;

        private int _currentScore = 0;

        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void AddScore(int score)
        {
            _currentScore += score;

            _signalBus.Fire(new OnEnemyDeadSignal { Score = _currentScore });

            UpdateView();
        }

        private void UpdateView()
        {
            _scoreText.text = _currentScore.ToString();
        }
    }
}