using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10;

    public float projectileLife = 10;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDelete", projectileLife);
    }

    void SelfDelete()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Inherit Faction from the parent Unit.
        // Define what an enemy is (or a possible enemy target)


        // If bullet hits an enemy
        // Deal damage to the target



        // After hitting anything, SelfDelete();
        SelfDelete();
    }
}
