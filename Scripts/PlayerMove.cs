using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    CharacterController controller;
    Vector3 moveVector;
    public float moveSpeed = 0.5f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        moveVector = transform.forward * Input.GetAxis("Vertical") * moveSpeed + transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.y = Physics.gravity.y;
                
        controller.Move(moveVector);

        if (Input.GetAxis("Vertical") > 0) {
            anim.SetBool("Running", true);
            anim.SetInteger("Direction", 0);
        }
        else if (Input.GetAxis("Vertical") < 0) {
            anim.SetBool("Running", true);
            anim.SetInteger("Direction", 2);
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            anim.SetBool("Running", true);
            anim.SetInteger("Direction", 1);
        }
        else if (Input.GetAxis("Horizontal") < 0) {
            anim.SetBool("Running", true);
            anim.SetInteger("Direction", 3);
        }
        else {
            anim.SetBool("Running", false);
            anim.SetInteger("Direction", 0);
        }




    }
}
