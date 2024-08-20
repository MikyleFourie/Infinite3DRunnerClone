using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform character;
    [SerializeField] float cameraOffSet;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffSet = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, character.position.z + cameraOffSet);
    }
}
