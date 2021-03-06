using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{

    private Transform player;
    public Outline outline;

    public string message;

    public abstract void Interact();


    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
        if(outline != null)
        {
            outline.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled)
        {
            return;
        }
        if(other.tag == "Player")
        {
            PlayerInteraction.instance.AddInteract(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!enabled)
        {
            return;
        }

        if (other.tag == "Player")
        {
            PlayerInteraction.instance.RemoveInteract(this);
        }
    }

    public void SetDisable()
    {
        PlayerInteraction.instance.RemoveInteract(this);
        outline.enabled = false;
        this.enabled = false;
    }
    public void SetEnable()
    {
        this.enabled = true;
    }


}
