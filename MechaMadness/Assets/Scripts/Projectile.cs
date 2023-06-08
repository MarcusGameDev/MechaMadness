using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10;

    public float projectileLife = 10;
    
    Faction bulletFaction;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDelete", projectileLife);
    }

    void SelfDelete()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        //  the other object has the "Unit Script & Their faction is different from this objects faction. Run the code.
        if(other.gameObject.GetComponent<Unit>() != null && other.gameObject.GetComponent<Factions>().faction != GetComponent<Factions>().faction)
        {
            other.gameObject.GetComponent<Unit>().TakeDamage(damage);
        }

        // If bullet hits an enemy
        // Deal damage to the target



        // After hitting anything, SelfDelete();
        SelfDelete();
    }

    public void GetFaction(Faction spawnerFaction)
    {
        bulletFaction = spawnerFaction;
    }
}
