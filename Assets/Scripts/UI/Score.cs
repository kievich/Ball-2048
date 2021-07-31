using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _maxScoreText;

        private int _score;
        private int _maxScore;

        private BallUnifier _ballUnifier;

        public event Action ScoreChanged;

        private void Start()
        {
            _ballUnifier = FindObjectOfType<BallUnifier>();
            _ballUnifier.BallUnited += onScoreChanged;
            _score = AppData.Score;
            _maxScore = AppData.MaxScore;
            DisplayScore();
        }
        private void DisplayScore()
        {
            _scoreText.text = _score.ToString();
            _maxScoreText.text = "Max: " + _maxScore.ToString();
        }

        private void onScoreChanged(int ballValue)
        {
            _score += BallValueToRealValue(ballValue);
            AppData.SetScore(_score);
            _maxScore = AppData.MaxScore;
            DisplayScore();
            ScoreChanged?.Invoke();

        }

        private void OnDisable()
        {
            _ballUnifier.BallUnited -= onScoreChanged;

        }

        private int BallValueToRealValue(int ballValue)
        {
            return (int)Mathf.Pow(2, ballValue + 1);
        }


    }

}


