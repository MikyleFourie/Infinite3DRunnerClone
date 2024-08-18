using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeTest : MonoBehaviour
{
    private PlayerControls _controls;

    [SerializeField] private float minimumSwipeMagnitude = 10f;
    [SerializeField] private float directionThreshold = 1.5f;
    private Vector2 _swipeDirection;

    private void Start()
    {
        _controls = new PlayerControls();

        _controls.Player.Enable();

        _controls.Player.Touch.canceled += ProcessTouchComplete;
        _controls.Player.Swipe.performed += ProcessSwipeDelta;
    }

    private void ProcessSwipeDelta(InputAction.CallbackContext context)
    {
        _swipeDirection = context.ReadValue<Vector2>();
    }

    private void ProcessTouchComplete(InputAction.CallbackContext context)
    {
        //check if the magnitude is high enough
        //Debug.Log("Touch Complete");
        if (Mathf.Abs(_swipeDirection.magnitude) < minimumSwipeMagnitude) return;
        //Debug.Log("Swipe Detected");

        //Determine whether the swipe is more horizontal or vertical
        if (Mathf.Abs(_swipeDirection.x) > Mathf.Abs(_swipeDirection.y) * directionThreshold)
        {
            //Horizontal Swipe
            if (_swipeDirection.x > 0)
            {
                Debug.Log("Swiping Right");
            }
            else
            {
                Debug.Log("Swiping Left");
            }
        }
        else if (Mathf.Abs(_swipeDirection.y) > Mathf.Abs(_swipeDirection.x) * directionThreshold)
        {
            //Vertical Swipe
            if (_swipeDirection.y > 0)
            {
                Debug.Log("Swiping Up");
            }
            else
            {
                Debug.Log("Swiping Down");
            }
        }

        // Reset swipe Direction
        _swipeDirection = Vector2.zero;

        //var position = Vector3.zero;

        ////check horizontal direction
        //if (_swipeDirection.x > 0)
        //{
        //    Debug.Log("Swiping Right");
        //    position.x = 1;
        //} else if (_swipeDirection.x < 0)
        //{
        //    Debug.Log("Swiping Left");
        //    position.x = -1;
        //}

        ////check vertical direction
        //if (_swipeDirection.y > 0)
        //{
        //    Debug.Log("Swiping Up");
        //    position.y = 1;
        //}
        //else if (_swipeDirection.y < 0)
        //{
        //    Debug.Log("Swiping Down");
        //    position.y = -1;
        //}

        //transform.position = position;  
    }
}
