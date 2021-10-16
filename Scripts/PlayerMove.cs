using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	
	CharacterController controller;
	Vector3 moveVector;
	public float moveSpeed = 0.1f;
	

    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		
		moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
		moveVector.z = Input.GetAxis("Vertical") * moveSpeed;
		moveVector.y = Physics.gravity.y;

		controller.Move(moveVector);


    }
}
