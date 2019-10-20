using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Authors: Jordan Machalek
 * Manages events affecting resources and crewmembers
 */
public class EventManager : MonoBehaviour
{
    // Attributes
    public GameManager gameManager;

    public List<string> fuelEventText;
    public List<string> foodEventText;
    public List<string> crewEventText;
    public List<string> luminosityEventText;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the game manager - should be attached to the same object
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Causes an event to occur affecting the player's resources
    void CauseEvent()
    {
        // Choose a type
        int eventType = Random.Range(0, 3);

        switch(eventType)
        {
            case 0:
                // No Event
                break;
            case 1:
                // Fuel
                gameManager.fuel += GetEventAmount(gameManager.fuel);
                break;
            case 2:
                // Food
                gameManager.food += GetEventAmount(gameManager.food);
                break;
            case 3:
                // Crew
                // Crew events work differently from other events, has a smaller range
                gameManager.crewCount += CrewEvent();
                break;
            case 4:
                // Luminosity
                gameManager.luminosity += GetEventAmount(gameManager.luminosity);
                break;
        }
    }

    // Simulates a crew event - Crew either join or leave the player
    int CrewEvent()
    {
        int changeAmount = Random.Range(0, 2);

        return changeAmount * RandomSign();
    }

    // Gets the amount of a resource that should be taken away
    int GetEventAmount(int affectedResource)
    {
        // Get minimum value of resource
        // For now, keep at least 10% of the current value
        int minVal = Mathf.FloorToInt((affectedResource * 10) / 100);

        return Random.Range(0, affectedResource - minVal) * RandomSign();
    }

    // Helper Method: Returns 1 or -1 to randomly change the sign of a value
    int RandomSign()
    {
        return Random.Range(0, 1) * 2 - 1;
    }
}
