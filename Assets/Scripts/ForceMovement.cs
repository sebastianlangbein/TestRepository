using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }
}
