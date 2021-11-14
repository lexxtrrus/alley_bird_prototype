using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private HeroMovement _heroMovement;
    private int _currentScore = 0;

    [Inject]
    private void Costrust(HeroMovement heroMovement)
    {
        _heroMovement = heroMovement;
    }

    private void Awake() 
    {
        UpdateScorePoints();
        _heroMovement.OnHeroLandedNewPlatform += IncreaseScore;
    }

    private void OnDestroy() 
    {
        _heroMovement.OnHeroLandedNewPlatform -= IncreaseScore;
    }

    private void IncreaseScore()
    {        
        _currentScore++;
        if(_currentScore > Profile.BestScore) UpdateBestScore();
        UpdateScorePoints();
    }

    private void UpdateBestScore()
    {
        Profile.BestScore = _currentScore;
    }

    private void UpdateScorePoints()
    {
        scoreText.text = $"SCORE: {_currentScore}\nBest: {Profile.BestScore}";
    }
}
