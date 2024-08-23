using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public float rotationSpeed = 360f;
    public TextMeshProUGUI sessionCoinCount; // Display for current session coin count
    public AudioClip collectSound;
    private AudioSource audioSource;

    // This variable tracks coins collected during the current session
    private static int sessionScore = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Initialize session coin count display
        sessionScore = 0;
        if (sessionCoinCount != null)
        {
            sessionCoinCount.text = sessionScore.ToString();
        }
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            // Increment session coins and update display
            sessionScore++;
            if (sessionCoinCount != null)
            {
                sessionCoinCount.text = sessionScore.ToString();
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }


    void OnDestroy()
    {
        // Update the total coin count in PlayerPrefs when a coin is destroyed
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        PlayerPrefs.SetInt("TotalCoins", totalCoins + sessionScore);
        PlayerPrefs.Save();
    }
}
