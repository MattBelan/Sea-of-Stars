using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Child class: Defines the functions of the galley of the ship
 */
public class Galley : Room
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
    public void PrepareFood(int mult)
    {
        //Debug.Log("Prepared food");

        gameManager.foodCount += (5 * mult);
    }
}
