using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    //public Faction[] factions;

    List<GameObject> AllUnits;
    public List<GameObject> Team1;
    public List<GameObject> Team2;

   // public event Action<ThisFaction> OnCheckingUnits;

    // Start is called before the first frame update
    void Start()
    {
        // Broadcast Message for Units that exist
   //     OnCheckingUnits?.Invoke(ThisFaction);

        // Inc Argument that sends back a receivers event?

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveUnitExists()
    {
        //Listen for Units that claim they exist

        //Add Those units to this List of all Units

        // Sort the Units to their respective teams
    }
}
