using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public float rotationSpeed = 360f;
    public TextMeshProUGUI coinCount; 
    public AudioClip collectSound; // Sound to play on collection
    private AudioSource audioSource; // Audio source component
    private int score = 0; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Rotate the coin
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Play the collection sound
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
            // Increment the coins count
            score++;
            coinCount.text =  score.ToString();

            Destroy(gameObject);
        }
    }
}
