using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    Quaternion orignalRotation;

    // Start is called before the first frame update
    void Start()
    {
        orignalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation * orignalRotation;
    }
}
