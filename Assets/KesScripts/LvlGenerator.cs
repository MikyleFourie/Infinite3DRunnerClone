using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{

    public List<GameObject> roadSections = new List<GameObject>();
    private GameObject lastInstantiatedSection;

    GameObject selectedSection;
    int randomIndex;

    // Reference to SpeedTracker (you need to assign this in the Inspector)
    public SpeedTracker speedTracker;

    private void Start()
    {
        randomIndex = Random.Range(0, roadSections.Count);
        selectedSection = roadSections[randomIndex];

        GameObject instantiatedSection = Instantiate(selectedSection, new Vector3(0, 0, 140f), Quaternion.identity);
        Debug.Log("Intantiated: " + selectedSection.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger on " + this.transform.gameObject.name + " by " + other.name + " at " + other.transform.position.z);
        if (other.gameObject.CompareTag("Load"))
        {


            // Prevent back-to-back instantiation of the same GameObject
            do
            {
                randomIndex = Random.Range(0, roadSections.Count);
                selectedSection = roadSections[randomIndex];
            } while (selectedSection == lastInstantiatedSection && Random.value < 0.7f); // 70% chance to re-roll

            // Instantiate the selected road section
            //GameObject instantiatedSection = Instantiate(selectedSection, new Vector3(0, 3, 31.2f), Quaternion.identity);

            GameObject instantiatedSection = Instantiate(selectedSection, new Vector3(0, 0, 140f + other.transform.position.z), Quaternion.identity);
            Debug.Log("Intantiated: " + selectedSection.name);

            // Apply the current speed to the new PlatformMove component
            PlatformMove platformMove = instantiatedSection.GetComponent<PlatformMove>();
            if (platformMove != null && speedTracker != null)
            {
                platformMove.SetSpeed(speedTracker.GetCurrentSpeed());
            }

            // Update the last instantiated section
            lastInstantiatedSection = selectedSection;
        }
    }
}
