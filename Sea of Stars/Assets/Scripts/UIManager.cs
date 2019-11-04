using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject roomTextObj;
    public GameObject foodTextObj;
    public GameObject energyTextObj;
    public GameObject healthTextObj;
    public GameObject enemyHealthTextObj;

    public TestPlayerScript player;
    public CombatEntity ship;
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
        }
    }
}
