using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public CharacterController charC;
    public float speed = 5f;
    void Start()
    {
        charC = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        charC.Move(Vector3.forward * speed * Time.deltaTime);
    }
}
