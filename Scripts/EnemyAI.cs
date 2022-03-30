using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject playerObject;
    private Vector3 playerPos;
    public enum behaveMode {
        patrol,
        attack
    }
    public behaveMode curMode = behaveMode.patrol;

    Vector3 patrolPoint0;
    Vector3 patrolPoint1;
    int curPatrolPoint = 1;
    public float moveSpeed = 10;

    private Rigidbody myRigidbody;

    public float shootTimer = 0;
    public float timeBetweenShots = 2.0f;

    public float health = 10;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = transform.GetComponent<Rigidbody>();

        patrolPoint0 = transform.position;
        patrolPoint1 = transform.position + Vector3.forward * 10;

        playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        playerPos = playerObject.transform.position;

        switch (curMode) {

            case behaveMode.patrol:

                Patrol();

                if (Vector3.Distance(transform.position, playerPos) < 25)
                    curMode = behaveMode.attack;

            break;

            case behaveMode.attack:

                MoveTowardsPlayer();

                shootTimer += Time.deltaTime;

                if (Vector3.Distance(transform.position, playerPos) < 20) {
                    
                    if (shootTimer > timeBetweenShots) {
                        FireLaser();
                        shootTimer = 0;
                    }

                }
                else if (Vector3.Distance(transform.position, playerPos) > 30)
                    curMode = behaveMode.patrol;

                break;

        }

        if (health <= 0) {
            Destroy(this.gameObject);
        }


    }

    void Patrol() {

        if(curPatrolPoint == 0) {

            myRigidbody.position = Vector3.MoveTowards(transform.position, patrolPoint0, moveSpeed * Time.deltaTime);
            transform.LookAt(patrolPoint0);

            if (Vector3.Distance(transform.position, patrolPoint0) < 1)
                curPatrolPoint = 1;

        }

        else if(curPatrolPoint == 1) {

            myRigidbody.position = Vector3.MoveTowards(transform.position, patrolPoint1, moveSpeed * Time.deltaTime);
            transform.LookAt(patrolPoint1);

            if (Vector3.Distance(transform.position, patrolPoint1) < 1)
                curPatrolPoint = 0;

        }

    }

    void MoveTowardsPlayer() {

        myRigidbody.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        transform.LookAt(playerPos);

    }

    void FireLaser() {

        print("Pew");

    }

}
