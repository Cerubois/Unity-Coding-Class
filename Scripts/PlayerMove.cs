using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

	
	CharacterController controller;
	Vector3 moveVector;

	

    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

		moveVector.x = Input.GetAxis("Horizontal");
		moveVector.z = Input.GetAxis("Vertical");
		controller.Move(moveVector);


    }
}
