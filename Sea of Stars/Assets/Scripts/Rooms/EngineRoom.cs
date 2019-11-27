using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Child class: Defines the functions of the engine room of the ship
 * Interacts with CombatShip.cs
 */
public class EngineRoom : Room
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (bonusActive)
        {
            timer += Time.deltaTime;
            seconds = (int)timer % 60;

            if (seconds == 15) // end the bonus
            {
                timer = 0f;
                seconds = 0;

                // Removed b/c doesn't make much sense for the restored health to go away
                //combatScript.Health -= 5;
                
                //// Make sure the ship's health doesn't go below 0
                //if(combatScript.Health <= 0)
                //{
                //    combatScript.Health = 1;
                //}

                bonusActive = false; // stop timer
            }
        }
    }

    // Provides a bonus to the ship's health
    public void RepairEngine()
    {
        //Debug.Log("Repairing engine");

        bonusActive = true; // start timer
        combatScript.Health += 2;
    }
}
