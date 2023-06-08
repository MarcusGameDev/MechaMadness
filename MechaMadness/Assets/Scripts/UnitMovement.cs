using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class UnitMovement : MonoBehaviour
{
    NavMeshAgent Agent;
    public GameObject Target;

    public float stopDistance = 5;
    private Vector3 distance;

    public UnityEvent OnInRange;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        // Subscribe to the TargetSet event                         ~~  Disable this to remove dependencies on other scripts ~~
        Unit unit = GetComponent<Unit>();
        unit.OnEnemyFound += TargetSet;
    
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

            if (distance.x > stopDistance || distance.z > stopDistance)
            {
                // Player moves towards their target
                Agent.isStopped = false;
                Agent.destination = Target.transform.position;
            }
            else
            {
                // Face the Target
                transform.LookAt(Target.transform.position);

                // Player stops movement
                Agent.isStopped = true;

                OnInRange.Invoke();
            }
        }
    }

    public void TargetSet(GameObject target)
    {
        // Get "Target" from sender, and set it as the target
        Target = target;
    }
}
