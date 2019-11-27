using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Room
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refuel()
    {
        //Debug.Log("Refueling");

        gameManager.fuelCount += 5;
    }
}
