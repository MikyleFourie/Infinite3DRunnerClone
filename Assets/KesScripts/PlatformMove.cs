using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    //public float currentSpeed;

    float platformMoveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, currentSpeed) * Time.deltaTime;
        //Debug.Log(currentSpeed);
    }

    // Public method to modify the speed
    public void SetSpeed(float newSpeed)
    {
        //currentSpeed = newSpeed; new
        //transform.position += new Vector3(0, 0, -platformMoveSpeed) * Time.deltaTime; old

    }

    // Destroys the previous road section
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
