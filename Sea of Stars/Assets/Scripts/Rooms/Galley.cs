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

    // 
    public void PrepareFood(int mult)
    {
        //Debug.Log("Prepared food");

        bonusActive = true;

        gameManager.foodCount += (5 * mult);

        // Display an encouraging message if things are going well
        if (combatScript.Health > 10 && combatScript.stress < 50 && bonusActive && dialogueManager.allowMessage)
        {
            dialogueManager.EncouragingMessage("Galley");
        }
    }
}
