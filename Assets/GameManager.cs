using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreText;

    private float score = 0f;

    private void Start()
    {
        UpdateScore();
    }

    public void AddScore(float score)
    {
        this.score += score;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
