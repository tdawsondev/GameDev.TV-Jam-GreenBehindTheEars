using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverRock : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;

    public float lifeTime;
    float timer = 0f;

    public void Update()
    {
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
        timer += Time.deltaTime;
        if(timer > lifeTime)
        {
            Destroy(gameObject);
        }

    }
}
