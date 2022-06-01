using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    #region Singleton

    const float GRAVITY = -9.8f;

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

    [Header("Input")]
    private PlayerInputActions inputActions;
    private InputAction movement;
    [SerializeField] CharacterController controller;
    public float speed = 5f;
    float valx, valz; // used in input smoothing. 
    public bool movementDisabled = false;

    [Header("Graphics")]
    public Transform graphics;
    public Animator animator;

    

    [Header("Ground Stuff")]
    [SerializeField] Transform groundCheck = null;
    [SerializeField] float groundDistance = 0.2f;
    public LayerMask groundMask;
    [SerializeField] bool isGrounded = true;
    Vector3 velocity;
    

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

            Vector3 camForward = Camera.main.transform.forward;
            camForward.y = 0;
            camForward.Normalize(); // get camera forward diretion ignoring y
            Vector3 camRight = Camera.main.transform.right;
            camRight.y = 0;
            camRight.Normalize();// get camera right diretion ignoring y

            Vector3 moveVec = camRight * x + camForward * z;

            if (input.magnitude > 0)
            {
                RotateGraphics(new Vector2(moveVec.normalized.x, moveVec.normalized.z));
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            

            if (moveVec.magnitude != 0f)
            {
                controller.Move(moveVec * speed * Time.deltaTime);

            }

        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
            // resets velocity. kept at -2 to keep player tied to the ground
        }
        velocity.y += GRAVITY * Time.deltaTime * 4f; // the extra 2f is to speed up the fall.

        if (!isGrounded)
        {
             controller.Move(velocity * Time.deltaTime);
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
