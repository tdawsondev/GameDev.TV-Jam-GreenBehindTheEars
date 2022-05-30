using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public Interactable interactable;
    public NavMeshAgent agent;
    bool destinationReached = false;
    Transform target = null;
    public Animator animator;
    Callback afterArrive;

    public float DistanceToTarget
    {
        get
        {
            if(target != null)
                return Vector3.Distance(transform.position, target.position);
            return 0f;
        }
    }

    public delegate void Callback();

    protected virtual void Start()
    {
        if (agent != null)
        {
            agent.enabled = false;
        }
        destinationReached = false;
    }

    public void SetDialog(DialogObject dObj)
    {
        DialogueInteractable di = null;
        if (interactable.GetType() == typeof(DialogueInteractable))
        {
            di = (DialogueInteractable)interactable;
        }
        if (di != null)
        {
            di.dialog = dObj;
        }
    }
    public void SetDestination(Transform destination, Callback callback = null)
    {
        Debug.Log("SetDestination");
        afterArrive = callback;
        target = destination;
        agent.enabled = true;
        agent.SetDestination(destination.position);
        destinationReached = false;
        animator.SetBool("isWalking", true);
        interactable.SetDisable();
    }
    public void OnArrive()
    {
        Debug.Log("OnArrive");
        destinationReached = true;
        interactable.SetEnable();
        agent.enabled=false;
        animator.SetBool("isWalking", false);
        if (afterArrive != null)
        {
            afterArrive();
        }
    }

    protected virtual void Update()
    {
        if (agent !=  null && agent.enabled)
        {
            if (DistanceToTarget <= 1f)
            {
                if (!destinationReached)
                {
                    OnArrive();
                }
            }
        }
    }
}
