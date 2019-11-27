using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Child class: Defines the functions of the magazine of the ship
 * Interacts with CombatShip.cs
 */
public class Magazine : Room
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

            if (seconds == 5) // end the bonus
            {
                Debug.Log("Fire rate bonus ended");
                timer = 0f;
                seconds = 0;
                combatScript.FireRate /= 1.5f;
                bonusActive = false; // stop timer
            }
        }
    }

    // Provides a bonus to the ship's fire rate
    public void RestockAmmo()
    {
        //Debug.Log("Restocking ammunition");

        bonusActive = true; // start timer
        combatScript.FireRate *= 1.5f;
    }
}
