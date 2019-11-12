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

        // Placeholders:
        fuelEventText = new List<string> { "A fuel event happened!" };
        foodEventText = new List<string> { "A food event happened!" };
        crewEventText = new List<string> { "A crew event happened!" };
        luminosityEventText = new List<string> { "A luminosity event happened!" };
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 720 == 0)
        {
            CauseEvent();
        }   
    }

    // Causes an event to occur affecting the player's resources
    void CauseEvent()
    {
        // Choose a type
        int eventType = Random.Range(0, 5);
        int amount = 0;

        switch(eventType)
        {
            case 0:
                // No Event
                Debug.Log("No event");
                //gameManager.AnnounceEvent("");
                break;
            case 1:
                // Fuel
                Debug.Log("Fuel event");
                amount = GetEventAmount(gameManager.fuelCount);
                gameManager.fuelCount += amount;

                // Update UI
                //gameManager.AnnounceEvent(fuelEventText[0] + "\nChanged by " + amount);
                break;
            case 2:
                // Food
                Debug.Log("Food event");
                amount = GetEventAmount(gameManager.foodCount);
                gameManager.foodCount += amount;

                // Update UI
                //gameManager.AnnounceEvent(foodEventText[0] + "\nChanged by " + amount);

                break;
            case 3:
                // Crew
                Debug.Log("Crew event");
                // Crew events work differently from other events, has a smaller range
                amount = GetCrewEventAmount();

                // === TODO: Change logic to: "if no crew to remove do nothing" - make sure to stop the message from appearing as well
                //if (gameManager.crewCount == 0) // If there is no crew to remove, add crew instead
                {
                    amount = Mathf.Abs(amount);
                }

                //gameManager.crewCount += amount;

                // Add or subtract from the minimum luminosity as a crew member has been added
                gameManager.minLuminosity += 1 * RandomSign();

                // Update UI
                //gameManager.AnnounceEvent(crewEventText[0] + "\nChanged by " + amount);
                // === END TODO ======================================================
                break;
            case 4:
                // Luminosity
                Debug.Log("Luminosity event");
                amount = GetEventAmount(gameManager.luminosityCount);
                gameManager.luminosityCount += amount;

                // Update UI
                //gameManager.AnnounceEvent(luminosityEventText[0] + "\nChanged by " + amount);

                break;
        }
    }

    // Gets the amount of crew that join or leave the player
    int GetCrewEventAmount()
    {
        int changeAmount = Random.Range(1, 2);

        return changeAmount * RandomSign();
    }

    // Gets the amount of a resource that should be taken away or added
    int GetEventAmount(int affectedResource)
    {
        // Get minimum value of resource - don't remove (or add) more than 90% of the resource's current value
        int minVal = Mathf.FloorToInt((affectedResource * 10) / 100);

        return Random.Range(1, affectedResource - minVal) * RandomSign();
    }

    // Helper Method: Returns 1 or -1 to randomly change the sign of a value
    int RandomSign()
    {
        return Random.Range(0, 2) * 2 - 1;
    }
}
