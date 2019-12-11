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
        if (bonusActive)
        {
            timer += Time.deltaTime;
            seconds = (int)timer % 60;

            if (seconds == 5) // end the bonus
            {
                timer = 0f;
                seconds = 0;
                bonusActive = false; // stop timer
            }
        }
    }

    public void Refuel(int mult)
    {
        //Debug.Log("Refueling");

        bonusActive = true;
        
        gameManager.fuelCount += (5 * mult);

        // Display an encouraging message if things are going well
        if (combatScript.Health > 10 && combatScript.stress < 50 && bonusActive)
        {
            dialogueManager.EncouragingMessage("Storage");
        }
    }
}
