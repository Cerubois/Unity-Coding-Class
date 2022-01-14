using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{

    float rotateSpeed = 1.0f;

    Vector3 aimVector = new Vector3();
    RaycastHit aimHit;
    public LayerMask aimLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        Camera.main.transform.Rotate(Input.GetAxis("Mouse Y") * -rotateSpeed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }

        aimVector = Camera.main.transform.forward;

        Debug.DrawRay(Camera.main.transform.position, aimVector * 100, Color.red);

        Physics.Raycast(Camera.main.transform.position, aimVector, out aimHit, 100, aimLayerMask);

        if (Input.GetButtonDown("Fire1")) {

            if(aimHit.transform != null) {

                TargetData target = aimHit.transform.GetComponent<TargetData>();
                target.health -= 1;

            }

        }

    }





}
