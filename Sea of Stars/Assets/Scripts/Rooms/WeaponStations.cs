using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Child class: Defines the functions of the weapons stations of the ship
 * Interacts with CombatShip.cs
 */
public class WeaponStations : Room
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(bonusActive)
        {
            timer += Time.deltaTime;
            seconds = (int)timer % 60;

            if (seconds == 5) // end the bonus
            {
                Debug.Log("Weapon damage bonus ended");
                timer = 0f;
                seconds = 0;
                combatScript.Damage /= 2;
                bonusActive = false; // stop timer
            }
        }
    }

    // Provides a bonus to the ship's weapons - doubles damage
    public void ManBattlestations()
    {
        //Debug.Log("Manning battlestations!");

        bonusActive = true; // start timer
        combatScript.Damage *= 2;
    }
}
