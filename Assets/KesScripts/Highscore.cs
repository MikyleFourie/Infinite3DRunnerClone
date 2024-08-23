using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI HighscoreText;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        HighscoreText.text = highscore.ToString("000000000");
    }
}
