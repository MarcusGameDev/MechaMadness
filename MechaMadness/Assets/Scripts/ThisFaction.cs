using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public class ThisFaction : MonoBehaviour
{
    public Faction UnitFaction;

    List<ThisFaction> PotentialEnemies = new List<ThisFaction>();

    // public UnityEvent OnFoundEnemy;
    public event EventHandler OnFoundEnemy;

    public void FindEnemy()
    {
        // Creates a list of potential enemies
        PotentialEnemies.AddRange(GameObject.FindObjectsOfType<ThisFaction>());

        // Cuts down List to only include enemies
        foreach(ThisFaction dude in PotentialEnemies)
        {
            if(dude.UnitFaction == UnitFaction)
            {
                PotentialEnemies.Remove(dude);
            }
        }

        // Select an enemy

        ThisFaction chosenEnemy;
        chosenEnemy = PotentialEnemies[UnityEngine.Random.Range(0, PotentialEnemies.Count)];


       Debug.Log("Enemy identified as " + chosenEnemy.name);
        // Set the Chosen Enemy as the target for the player

        OnFoundEnemy?.Invoke(this, EventArgs.Empty);
    }
}
