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



    private List<Interactable> interactables = new List<Interactable>();
    private Interactable closestInteractable;
    private bool interactionDisabled = false;

    // Start is called before the first frame update


    public void DisableInteraction()
    {
        interactionDisabled = true;
    }
    public void EnableInteraction()
    {
        interactionDisabled = false;
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
        if (HUDController.instance)
            HUDController.instance.HideInteractionMessage();
        CheckCloset();
    }

    private void CheckCloset()
    {
        Interactable closest = null;
        foreach(Interactable i in interactables)
        {
            i.outline.enabled = false;
            if (closest == null)
            {
                closest = i;
                continue;
            }
            if(Vector3.Distance(transform.position, closest.transform.position) > Vector3.Distance(transform.position, i.transform.position))
            {
                closest = i;
            }
        }
        if (closest != null)
        {
            closest.outline.enabled = true;
            if (HUDController.instance)
            {
                HUDController.instance.ShowInteractionMessage(closest);
            }
            closestInteractable = closest;
        }
    }

    private void Update()
    {
        if(interactables.Count >= 2) // if in range of 2 interactable objects, constantly check which object is closer
        {
            CheckCloset();
        }
    }


    void OnInteract(InputValue value)
    {
        if (!interactionDisabled)
        {
            if(interactables.Count == 0)
            {
                closestInteractable = null;
            }

            if (closestInteractable != null)
            {
                closestInteractable.Interact();
            }
            CheckCloset();
        }
    }


}
