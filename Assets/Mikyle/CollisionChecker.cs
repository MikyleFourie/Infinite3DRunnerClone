using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    public GameObject GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameOverMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        //Check if the object collided with has the tag "obstacle"
        if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Trigger of " + this.transform.gameObject.name +
          " & " + other.transform.name +
          " (Parent: " + other.transform.parent?.gameObject.name + ")");


            //   Find all instances of PlatformMove in the scene and update their speed
            PlatformMove[] platformMoves = FindObjectsOfType<PlatformMove>();
            foreach (PlatformMove platformMove in platformMoves)
            {
                platformMove.SetSpeed(0f);
            }

            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }



    }
}
