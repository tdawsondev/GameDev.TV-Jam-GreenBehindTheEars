using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private InputAction movement;

    public CharacterController controller;
    public float speed = 5f;
    float valx, valz; // used in input smoothing. 
    

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        movement = inputActions.Player.Movement;
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

        

        // Basic Movement
        float x, z;

        x = GetSmoothRawAxis("Horizontal");
        z = GetSmoothRawAxis("Vertical");

        Vector3 moveVec = transform.right * x + transform.forward * z;

        if (moveVec.magnitude != 0f)
        {
            controller.Move(moveVec * speed * Time.deltaTime);

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    /// <summary>
    /// Gets a smoothed input from the Input system. Makes the character move around smoothly.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private float GetSmoothRawAxis(string name)
    {
        float sensitivity = 5f;
        float dead = 0.001f;
        Vector2 input = movement.ReadValue<Vector2>();
        if (name == "Horizontal")
        {
            float target = input.x;
            valx = Mathf.MoveTowards(valx, target, sensitivity * Time.unscaledDeltaTime);
            return (Mathf.Abs(valx) < dead) ? 0f : valx;

        }
        if (name == "Vertical")
        {
            float target = input.y;
            valz = Mathf.MoveTowards(valz, target, sensitivity * Time.unscaledDeltaTime);
            return (Mathf.Abs(valz) < dead) ? 0f : valz;

        }

        return 0;

    }


}
