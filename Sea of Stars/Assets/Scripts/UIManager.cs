using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    public CrewManager crewManager;

    [Header("Text Objects")]
    public GameObject roomTextObj;
    public GameObject foodTextObj;
    public GameObject energyTextObj;
    public GameObject healthTextObj;
    public GameObject enemyHealthTextObj;
    public GameObject stressTextObj;

    public TestPlayerScript player;
    public CombatShip ship;
    public CombatEntity enemy;

    [Header("Button Objects")]
    public GameObject sosButton;
    public bool showSOS;

    // Start is called before the first frame update
    void Start()
    {
        foodTextObj.GetComponent<Text>().text = "Food: ";
        energyTextObj.GetComponent<Text>().text = "Fuel: ";

        if (!crewManager) crewManager = GetComponent<CrewManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            roomTextObj.GetComponent<Text>().text = "Current Room: " + player.currRoom;
            healthTextObj.GetComponent<Text>().text = "Health: " + ship.Health;
            enemyHealthTextObj.GetComponent<Text>().text = "Enemy Health: " + enemy.Health;
            stressTextObj.GetComponent<Text>().text = "Stress: " + ship.stress;
        }

        if (showSOS) sosButton.SetActive(true);
    }

    // Updates the UI in response to an event
    public void AnnounceEvent(string message)
    {

    }

    // Called when SOS button is pressed
    public void SOS()
    {
        // Decrease stress to leave SOS state
        // ===== TODO: Could add a cooldown for using SOS again rather than subtracting stress ====    
        ship.stress -= 10;
        ship.SOSState = false;

        // Hide the button again
        showSOS = false;
        sosButton.gameObject.SetActive(false);
        
        // Recruit a random specialist crewmember
        if(crewManager.crewTotal < 10)
        {
            crewManager.RecruitCrew(true);
        }
        else
        {
            // Alert the player the ship does not have room for more crew

        }
    }
}
