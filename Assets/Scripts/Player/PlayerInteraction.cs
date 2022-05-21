using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.Player.Interact.performed += Interact;
        inputActions.Player.Interact.Enable(); 
    }
    private void OnDisable()
    {
        inputActions.Player.Interact.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Interact(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact");
    }


}
