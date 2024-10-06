using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public int score;

    public void AddScore()
    {
        score++;
        scoretext.text = score.ToString();
    }
}
