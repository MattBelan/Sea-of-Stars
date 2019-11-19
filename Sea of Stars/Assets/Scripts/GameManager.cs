using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Holds key game data and methods
 */
public class GameManager : MonoBehaviour
{
    [Header("Resource Data")]
    // Food for thought: Condense these as a Vector3 called 'shipStats'?
    public int fuelCount = 10; // This is separate to prevent the header from appearing above all 3 attributes
    public int foodCount = 10, luminosityCount = 10, minLuminosity = 0;
    public int crewCount = 0;

    private int foodCost;

    public bool inCombat;
    public CombatShip ship;
    public CombatEnemy enemy;

    //used for progression
    public int currLevel;

    //used for map
    public int currNode;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = true;
    }

    // Update is called once per frame
    void Update()
    {
        //once specialists/crew are added up crewCount

        ship.inCombat = inCombat;
        enemy.inCombat = inCombat;

        if (inCombat)
        {
            //Put combat specific function calls here

        }
        else
        {
            //Put non-combat specific functions here
            if (Input.GetKeyDown(KeyCode.M))
            {
                //bring up map

            }
        }

        //Getting out of combat
        if (enemy.Health <= 0)
        {
            inCombat = false;
        }

        //foodCount -= crewCount;
        //for some reason subtracts 10 every frame
    }
}
