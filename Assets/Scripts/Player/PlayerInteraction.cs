using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    #region Singleton

    public static PlayerInteraction instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one PlayerInteraction Object");
        }
        instance = this;
    }
    #endregion



    public List<Interactable> interactables;
    private Interactable closestInteractable;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInteract(Interactable i)
    {
        interactables.Add(i);
        CheckCloset();
    }
    public void RemoveInteract(Interactable i)
    {
        interactables.Remove(i); 
        i.outline.enabled = false;
    }

    private void CheckCloset()
    {
        Interactable closest = null;
        foreach(Interactable i in interactables)
        {
            if(closest == null)
            {
                closest = i;
                continue;
            }
            if(Vector3.Distance(transform.position, closest.transform.position) < Vector3.Distance(transform.position, i.transform.position))
            {
                closest = i;
            }
        }
        if (closest != null)
        {
            closest.outline.enabled = true;
            closestInteractable = closest;
        }
    }


    void OnInteract(InputValue value)
    {
        Debug.Log("Interact");
        if(closestInteractable != null)
        {
            closestInteractable.Interact();
        }
        CheckCloset();
    }


}
