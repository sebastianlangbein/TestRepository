using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/Player/Movement")]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character")]
    public Vector3 moveDir;
    private CharacterController _charC;
    [Header("Character Speeds")]
    public float speed = 5f;
    public float jumpSpeed = 8, gravity = 20, crouch = 2.5f, walk = 5, run = 10;
   
    void Start()
    {
        _charC = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), moveDir.y, Input.GetAxis("Vertical"));
        moveDir = transform.TransformDirection(moveDir);
        moveDir.x *= speed;
        moveDir.z *= speed;
        if (_charC.isGrounded)
        {
            //moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDir = transform.TransformDirection(moveDir);
            //moveDir *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        _charC.Move(moveDir * Time.deltaTime);
    }
}
