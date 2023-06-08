using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public float Sum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            IPressedAKey();

            Sum = Addition(10, 5);
        }
    }

    void IPressedAKey()
    {
        Debug.Log("I pressed a key");
    }

    float Addition(float num1, float num2)
    {
        return num1 + num2;
    }

   

   
}
