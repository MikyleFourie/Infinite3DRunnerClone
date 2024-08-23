using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform character;
    [SerializeField] Vector3 cameraOffSet;
    Vector3 followPos;
    RaycastHit hit;
    float y;
    float followSpeed = 5f;
    void Start()
    {
        cameraOffSet = transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        followPos = character.position + cameraOffSet;

        if (Physics.Raycast(character.position, Vector3.down, out hit, 5f))
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * followSpeed);
        else y = Mathf.Lerp(y, character.position.y, Time.deltaTime * followSpeed);

        followPos.y = cameraOffSet.y + y;
        transform.position = followPos;
    }
}
