using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    #region Singleton

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one PlayerMovement Object");
        }
        instance = this;
        AfterAwake();
    }
    #endregion


    private PlayerInputActions inputActions;
    private InputAction movement;

    public Transform graphics;
    public Animator animator;


    [SerializeField] CharacterController controller;
    public float speed = 5f;
    float valx, valz; // used in input smoothing. 

    public bool movementDisabled = false;
    

    private void AfterAwake()
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

    public void DisableMovement()
    {
        movementDisabled = true;
    }
    public void EnableMovement()
    {
        movementDisabled = false;
    }

    private void Update()
    {
        if (!movementDisabled)
        {
            // Basic Movement
            float x, z;
            Vector2 input = movement.ReadValue<Vector2>();

            x = GetSmoothRawAxis("Horizontal", input);
            z = GetSmoothRawAxis("Vertical", input);

            if (input.magnitude > 0)
            {
                RotateGraphics(input);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            Vector3 moveVec = transform.right * x + transform.forward * z;

            if (moveVec.magnitude != 0f)
            {
                controller.Move(moveVec * speed * Time.deltaTime);

            }

        }
    }

    private void RotateGraphics(Vector2 input)
    {
        Quaternion rot = Quaternion.LookRotation(new Vector3(input.x, 0, input.y), Vector3.up);
        graphics.rotation = Quaternion.RotateTowards(graphics.rotation, rot, 350f * Time.deltaTime);
    }

    /// <summary>
    /// Gets a smoothed input from the Input system. Makes the character move around smoothly.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private float GetSmoothRawAxis(string name, Vector2 input)
    {
        float sensitivity = 5f;
        float dead = 0.001f;
        
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
