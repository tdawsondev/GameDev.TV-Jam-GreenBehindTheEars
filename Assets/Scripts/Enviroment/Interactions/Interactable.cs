using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{

    private Transform player;
    public Outline outline;

    public abstract void Interact();


    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerInteraction.instance.AddInteract(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerInteraction.instance.RemoveInteract(this);
        }
    }


}
