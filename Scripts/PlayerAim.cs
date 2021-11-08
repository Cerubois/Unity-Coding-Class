using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

	public float rotateSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

		Camera.main.transform.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
    }
}
