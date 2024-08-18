using UnityEngine;
using UnityEngine.InputSystem;

public enum SIDE { Left, Middle, Right }
public class PlayerController : MonoBehaviour
{
    private PlayerControls _controls;
    [SerializeField] SIDE m_Side = SIDE.Middle;
    [SerializeField] float newXPos = 0f;
    [SerializeField] float xValue = 2;
    [SerializeField] float x;
    [SerializeField] float dodgeSpeed = 10f;
    [SerializeField] float jumpPower = 7f;
    [SerializeField] float y;
    [SerializeField] private float minimumSwipeMagnitude = 10f;
    [SerializeField] private float directionThreshold = 1.5f;
    private Vector2 _swipeDirection;


    private CharacterController m_char;
    private void Start()
    {
        transform.position = Vector3.zero;
        m_char = GetComponent<CharacterController>();
        _controls = new PlayerControls();

        _controls.Player.Enable();

        _controls.Player.Touch.canceled += ProcessTouchComplete;
        _controls.Player.Swipe.performed += ProcessSwipeDelta;
    }

    private void Update()
    {
        Vector3 moveVector = new Vector3(x - transform.position.x, (y - 1) * Time.deltaTime, 0);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * dodgeSpeed);
        m_char.Move(moveVector);

        //Brings character back down
        if (y > 0)
            y -= jumpPower * 2 * Time.deltaTime;

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
                MoveRight();
            }
            else
            {
                Debug.Log("Swiping Left");
                MoveLeft();
            }
        }
        else if (Mathf.Abs(_swipeDirection.y) > Mathf.Abs(_swipeDirection.x) * directionThreshold)
        {
            //Vertical Swipe
            if (_swipeDirection.y > 0)
            {
                Debug.Log("Swiping Up");
                Jump();
            }
            else
            {
                Debug.Log("Swiping Down");
            }
        }

        // Reset swipe Direction
        _swipeDirection = Vector2.zero;


    }

    public void Left(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Key Left");
            MoveLeft();
        }
    }

    public void Right(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Key Right");
            MoveRight();
        }
    }

    public void Up(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Key Up");
            Jump();
        }
    }

    public void Down(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Key Down");
        }
    }



    public void MoveLeft()
    {
        if (m_Side == SIDE.Middle)
        {
            newXPos = -xValue;
            m_Side = SIDE.Left;
        }
        else if (m_Side == SIDE.Right)
        {
            newXPos = 0;
            m_Side = SIDE.Middle;
        }
    }

    public void MoveRight()
    {
        if (m_Side == SIDE.Middle)
        {
            newXPos = xValue;
            m_Side = SIDE.Right;
        }
        else if (m_Side == SIDE.Left)
        {
            newXPos = 0;
            m_Side = SIDE.Middle;
        }
    }

    public void Jump()
    {
        if (m_char.isGrounded)
        {
            Debug.Log("Jumped while grounded");
            y = jumpPower;
        }
        //else
        //{
        //    y -= jumpPower * 2 * Time.deltaTime;
        //}
    }
}
