using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("Score " + SceneManager.GetActiveScene().name, 0);
        scoreText.text = "SKOR : " + score.ToString();

        int highScore = PlayerPrefs.GetInt("High Score " + SceneManager.GetActiveScene().name, 0);
        highScoreText.text = "EN YÜKSEK SKOR : " + highScore.ToString();
    }
}
