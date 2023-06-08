using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;


public class Unit : MonoBehaviour
{
    // Values for the Unit
    public float UnitHealth = 100;

    public GameObject Target;
    public event Action<GameObject> OnEnemyFound;

    public Faction UnitFaction;
    List<Unit> UnitList = new List<Unit>();
    List<Unit> PotentialEnemies = new List<Unit>();

    //Death Info
    public event Action<GameObject> OnDeath;

    private void Start()
    {
        if(Target != null)
        {
            OnEnemyFound?.Invoke(Target);
        }

       TargetCheck();
    }
    
    public void TargetCheck()
    {
        if (Target == null)
        {
            // Find Enemies
            FindEnemy();
            // Find the ClosestEnemies
        }
    }

    public void TargetDied(GameObject target)
    {
        // Unsubscribes from the previous target, then goes to find the next target
        Target.GetComponent<Unit>().OnDeath -= TargetDied;
        TargetCheck();
    }

    public void FindEnemy()
    {
        // Creates a list of potential enemies
       UnitList.AddRange(GameObject.FindObjectsOfType<Unit>());

        // Cuts down List to only include enemies
        foreach (Unit dude in UnitList)
        {
            if (dude.UnitFaction != UnitFaction)
            {
             PotentialEnemies.Add(dude);
            }
        }

        // Select an enemy
        Unit chosenEnemy;
        chosenEnemy = PotentialEnemies[UnityEngine.Random.Range(0, PotentialEnemies.Count)];


       // Debug.Log("Enemy identified as " + chosenEnemy.name);
        // Set the Chosen Enemy as the target for the player
        Target = chosenEnemy.gameObject;


        // Subcribe to Enemies "On Death Event"
        Target.GetComponent<Unit>().OnDeath += TargetDied;

        // Broadcast new Target (Closest Enemy)
        OnEnemyFound?.Invoke(Target);
    }

    public void TakeDamage(float damage)
    {
        UnitHealth -= damage;

        if(UnitHealth <= 0)
        {
            // Death Event (To update their target)
            OnDeath?.Invoke(this.gameObject);

        }
    }
}



// Resources
// https://learn.unity.com/tutorial/working-with-navmesh-agents#