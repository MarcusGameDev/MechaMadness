using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitShooting : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletSpeed = 50;
    public Transform ShootPosition;
    bool canshoot = true;
    public float ShootTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        canshoot = true;
    }

     IEnumerator Shoot()
    {
        if(canshoot)
        {
            GameObject bulletInstance = Instantiate(Bullet, ShootPosition.position, ShootPosition.rotation);
            if (bulletInstance.GetComponent<Rigidbody>() != null) { bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed); }

            // Change the Bullets "Factions" component to This units "Faction"
            bulletInstance.GetComponent<Factions>().faction = GetComponent<Factions>().faction;


            //Debug.Log("Shoot");
            canshoot = false;
        }
       
        yield return new WaitForSeconds(ShootTimer);

        if (!canshoot)
        {
            canshoot = true;
        }
    }

    public void OnShoot()
    {
        if(canshoot)
        {
            StartCoroutine(Shoot());
        } 
    }
}
