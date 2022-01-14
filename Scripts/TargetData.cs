using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData : MonoBehaviour
{

    public int health = 3;
    public ParticleSystem destroyParticle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(health <= 0) {
            Instantiate(destroyParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }
}
