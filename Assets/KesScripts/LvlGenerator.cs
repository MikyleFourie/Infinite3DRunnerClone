using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{

    public List<GameObject> roadSections = new List<GameObject>();
    private GameObject lastInstantiatedSection;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger on " + this.transform.gameObject.name + " by " + other.name);
        if (other.gameObject.CompareTag("Load"))
        {
            GameObject selectedSection;
            int randomIndex;

            // Prevent back-to-back instantiation of the same GameObject
            do
            {
                randomIndex = Random.Range(0, roadSections.Count);
                selectedSection = roadSections[randomIndex];
            } while (selectedSection == lastInstantiatedSection && Random.value < 0.7f); // 70% chance to re-roll

            // Instantiate the selected road section
            //Instantiate(selectedSection, new Vector3(0, 0/*3*/, 43.36f), Quaternion.identity); //For one space apart
            Instantiate(selectedSection, new Vector3(0, 0, 73f), Quaternion.identity); //For two spaces apart
            Debug.Log("Intantiated: " + selectedSection.name);

            // Update the last instantiated section
            lastInstantiatedSection = selectedSection;
        }
    }
}
