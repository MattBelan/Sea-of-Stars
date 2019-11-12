using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text Objects")]
    public GameObject roomTextObj;
    public GameObject foodTextObj;
    public GameObject energyTextObj;
    public GameObject healthTextObj;
    public GameObject enemyHealthTextObj;
    public GameObject stressTextObj;

    [Header("Dialogue Text Objects")]
    public GameObject playerTextObj;
    public GameObject weaponTextObj;
    public GameObject magazineTextObj;
    public GameObject galleyTextObj;
    public GameObject storageTextObj;
    public GameObject engineTextObj;

    [Header("Button Objects")]
    public GameObject sosButton;

    public TestPlayerScript player;
    public CombatShip ship;
    public CombatEntity enemy;

    // Start is called before the first frame update
    void Start()
    {
        foodTextObj.GetComponent<Text>().text = "Food: ";
        energyTextObj.GetComponent<Text>().text = "Fuel: ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            roomTextObj.GetComponent<Text>().text = "Current Room: " + player.currRoom;
            healthTextObj.GetComponent<Text>().text = "Health: " + ship.Health;
            enemyHealthTextObj.GetComponent<Text>().text = "Health: " + enemy.Health;
            stressTextObj.GetComponent<Text>().text = "Stress: " + ship.stress;
        }
    }

    // Updates the UI in response to an event
    public void AnnounceEvent(string message)
    {

    }
}
