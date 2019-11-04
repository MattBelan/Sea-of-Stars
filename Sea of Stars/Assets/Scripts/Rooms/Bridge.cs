using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Child class: Defines functions of the bridge of the ship
 */
public class Bridge : Room
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

    // 
    public void Navigate()
    {
        Debug.Log("Plotting our course");
    }
}
