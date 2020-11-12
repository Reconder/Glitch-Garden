using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    float score;
    Text scoreText;
    float scoreMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        AdjustDifficulty();
        UpdateText();
    }



    private void AdjustDifficulty() => scoreMultiplier = 0.5f + 0.1f * PlayerPrefsController.MasterDifficulty;

    private void UpdateText() => scoreText.text = "Score: " +score.ToString("0.");

    public void AddScore(int addscore)
    {
        score += addscore * scoreMultiplier;
        UpdateText();
    }

}
