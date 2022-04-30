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

	public GameObject pauseScreen;

	public int xp = 0;
	public int level = 1;
	public int skillPoints = 0;

	public float bonusDmg = 0;

	// Start is called before the first frame update
	void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		camTransform = Camera.main.transform;

		playerWeapon = transform.GetComponent<PlayerWeapon>();

		pauseScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeedX, 0);

		camTransform.Rotate(Input.GetAxis("Mouse Y") * -rotateSpeedY, 0, 0);

		if (Input.GetKeyDown(KeyCode.Escape)) {

			PauseGame();

		}

		aimVector = camTransform.forward;

		Debug.DrawRay(camTransform.position, aimVector * 50, Color.red);

		Physics.Raycast(camTransform.position, aimVector, out aimHit, 100, aimLayerMask);

		if (Input.GetButtonDown("Fire1")) {

			if (aimHit.transform != null) {

				if (aimHit.transform.GetComponent<TargetData>() != null) {

					aimHit.transform.GetComponent<TargetData>().health -= playerWeapon.weaponDamage + bonusDmg;

					if(aimHit.transform.GetComponent<TargetData>().health <= 0) {
						xp += 5;
						aimHit.transform.GetComponent<TargetData>().SelfDestruct();
					}

				}
				else {
					// Temp until we access the EnemyAI script instead
					xp += 10;
					Destroy(aimHit.transform.gameObject);
				}
			}

		}

		// Level Up!
		// TODO: Change how xp we need per level, maybe we don't skill points every level
		if(xp >= 20) {
			level += 1;
			xp -= 20;
			skillPoints += 1;
		}


    }

	public void PauseGame() {

		if (Cursor.lockState == CursorLockMode.Locked) {
			Cursor.lockState = CursorLockMode.None;
			pauseScreen.SetActive(true);
		}
		else {
			Cursor.lockState = CursorLockMode.Locked;
			pauseScreen.SetActive(false);
		}

	}


}
