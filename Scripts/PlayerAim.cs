using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

	public PlayerWeapon playerWeapon;

	public float rotateSpeedX = 1.0f;
	public float rotateSpeedY = 1.0f;

	Vector3 aimVector = Vector3.zero;
	Transform camTransform;
	RaycastHit aimHit;
	public LayerMask aimLayerMask;

	// Start is called before the first frame update
	void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		camTransform = Camera.main.transform;

		playerWeapon = transform.GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeedX, 0);

		camTransform.Rotate(Input.GetAxis("Mouse Y") * -rotateSpeedY, 0, 0);

		if (Input.GetKeyDown(KeyCode.Escape)) {

			if (Cursor.lockState == CursorLockMode.Locked)
				Cursor.lockState = CursorLockMode.None;
			else
				Cursor.lockState = CursorLockMode.Locked;

		}

		aimVector = camTransform.forward;

		Debug.DrawRay(camTransform.position, aimVector * 50, Color.red);

		Physics.Raycast(camTransform.position, aimVector, out aimHit, 100, aimLayerMask);

		if (Input.GetButtonDown("Fire1")) {

			if (aimHit.transform != null) {

				if (aimHit.transform.GetComponent<TargetData>() != null)
					aimHit.transform.GetComponent<TargetData>().health -= playerWeapon.weaponDamage;
				else
					Destroy(aimHit.transform.gameObject);
			}

		}

    }
}
