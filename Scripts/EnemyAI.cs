using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	public GameObject playerObject;
	Vector3 playerPos;
	public enum behaveMode {
		patrol,
		attack
	}
	public behaveMode curMode;

	public float moveSpeed = 1;
	public Vector3 patrolPoint0;
	public Vector3 patrolPoint1;
	int curPatrol = 0;

	Rigidbody myRigidbody;

	// Start is called before the first frame update
	void Start()
    {

		myRigidbody = GetComponent<Rigidbody>();

		patrolPoint0 = transform.position;
		patrolPoint1 = transform.position + transform.forward * 10;

		playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

		playerPos = playerObject.transform.position;

		switch (curMode) {

			case behaveMode.patrol:

				Patrol();

				if (Vector3.Distance(transform.position, playerPos) < 20)
					curMode = behaveMode.attack;

			break;

			case behaveMode.attack:

				myRigidbody.position = Vector3.MoveTowards(myRigidbody.position, playerPos, moveSpeed * Time.deltaTime);
				transform.LookAt(playerPos);

				break;



		}


    }

	void Patrol() {

		if(curPatrol == 0) {

			myRigidbody.position = Vector3.MoveTowards(myRigidbody.position, patrolPoint0, moveSpeed * Time.deltaTime);
			transform.LookAt(patrolPoint0);

			if (Vector3.Distance(myRigidbody.position, patrolPoint0) < 1) {
				curPatrol = 1;
			}

		}
		if (curPatrol == 1) {

			myRigidbody.position = Vector3.MoveTowards(myRigidbody.position, patrolPoint1, moveSpeed * Time.deltaTime);
			transform.LookAt(patrolPoint1);

			if (Vector3.Distance(myRigidbody.position, patrolPoint1) < 1) {
				curPatrol = 0;
			}

		}

	}


}
