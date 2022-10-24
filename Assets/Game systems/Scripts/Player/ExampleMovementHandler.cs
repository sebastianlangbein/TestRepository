using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleMovementHandler : MonoBehaviour
{
    public Animator anim;
    public Vector3 moveDir;
    private CharacterController _charC;
    public float speed, jumpSpeed = 8, gravity = 20, crouch = 2.5f, walk = 5, run = 10;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _charC = GetComponent<CharacterController>();
        anim.SetFloat("isCrouching", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_charC.isGrounded)
        {
            anim.SetFloat("isCrouching", 1);
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (moveDir == Vector3.zero)
            {
                speed = 0;
            }
            else
            {
                //if sprinting
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = run;
                }
                //if crouching
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    speed = crouch;
                    anim.SetFloat("isCrouching", 0);
                }
                //else we are walking
                else
                {
                    speed = walk;
                }
            }
            anim.SetFloat("moveSpeed", speed);
            anim.SetFloat("Horizontal", moveDir.x);
            anim.SetFloat("Vertical", moveDir.z);

            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }
        moveDir.y -= gravity * Time.deltaTime;
        _charC.Move(moveDir * Time.deltaTime);
    }
}
