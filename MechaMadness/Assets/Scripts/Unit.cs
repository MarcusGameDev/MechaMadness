using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    NavMeshAgent Agent;

    public GameObject Target;

    public float ShootingDistance = 1;
    public Vector3 distance;

    public GameObject Bullet;
    public Transform ShootPosition;
    bool canshoot = true;
    public float ShootTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
                // Calcs to see if the player should be chasing its target
           distance = new Vector3(transform.position.x - Target.transform.position.x, transform.position.y - Target.transform.position.y, transform.position.z - Target.transform.position.z);
           if (distance.x < 0) distance.x *= -1;
           if (distance.z < 0) distance.z *= -1;

            if (distance.x > ShootingDistance || distance.z > ShootingDistance)
            {
                // Player moves towards their target
                Agent.isStopped = false;
                Agent.destination = Target.transform.position;
            }
            else
            {
                // PLayer Starts Shooting
                if (canshoot)
                {
                    StartCoroutine(Shoot());
                }
              

                // Player stops movement
                Agent.isStopped = true;
            }
          
        }
    }

    public IEnumerator Shoot()
    {
        canshoot = false;

        GameObject bulletInstance = Instantiate(Bullet, ShootPosition.position, ShootPosition.rotation);
        Debug.Log("Shoot");

        yield return new WaitForSeconds(ShootTimer);

        canshoot = true;
    }
}



// Resources
// https://learn.unity.com/tutorial/working-with-navmesh-agents#