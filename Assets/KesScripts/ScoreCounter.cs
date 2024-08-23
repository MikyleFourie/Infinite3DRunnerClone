using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI Score;
    private int number = 0;
    private bool canIncrement = false;

    private const string HighscoreKey = "Highscore";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartIncrementingAfterDelay());
        Score.text = number.ToString("000000000");

        // Load the highscore when the game starts
        int highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
        // Optionally use this value to display or use later
    }

    // Coroutine to wait for a certain time before starting the increment process
    private IEnumerator StartIncrementingAfterDelay()
    {
        yield return new WaitForSeconds(0);
        canIncrement = true;
        StartCoroutine(IncrementNumber());
    }

    // Coroutine to increment the number every second
    private IEnumerator IncrementNumber()
    {
        while (canIncrement)
        {
            yield return new WaitForSeconds(0.05f);
            number++;
            Score.text = number.ToString("000000000");

            // Check if the current score is higher than the highscore
            int highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
            if (number > highscore)
            {
                PlayerPrefs.SetInt(HighscoreKey, number);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartCount();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ContinueCount();
        }
    }

    // Method to restart the count
    private void RestartCount()
    {
        StopCoroutine(IncrementNumber());
        number = 0;
        Score.text = number.ToString("000000000");
        canIncrement = false;
        StartCoroutine(StartIncrementingAfterDelay());
    }

    private void ContinueCount()
    {
        if (!canIncrement)
        {
            canIncrement = true;
            StartCoroutine(IncrementNumber());
        }
    }

    private void OnApplicationQuit()
    {
        // Save the highscore when the application quits
        PlayerPrefs.Save();
    }
}
