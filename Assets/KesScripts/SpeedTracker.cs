using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTracker : MonoBehaviour
{
    public float SpeedMultiplier = 1.25f;
    [SerializeField] private float currentSpeed = -10f; // Initial speed

    void Start()
    {
        StartCoroutine(IncreaseSpeedOverTime());
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);

            // Increase the speed
            currentSpeed *= SpeedMultiplier;

            // Find all instances of PlatformMove in the scene and update their speed
            PlatformMove[] platformMoves = FindObjectsOfType<PlatformMove>();
            foreach (PlatformMove platformMove in platformMoves)
            {
                platformMove.SetSpeed(currentSpeed);
            }
        }
    }

    // Method to get the current speed
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}