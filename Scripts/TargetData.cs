using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData : MonoBehaviour
{

	public float health = 10;
    public Transform deathParticle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		if(health <= 0) {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}


    }
}
