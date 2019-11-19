using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    // Attributes
    public GameManager gameManager;

    public GameObject foodBar;
    public GameObject energyBar;

    public CombatEntity ship;
    public CombatEntity enemy;

    public string currRoom;

    public float gatherInterval;
    float lastGatherTime;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        lastGatherTime = 0;
        currRoom = "Bridge";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastGatherTime > gatherInterval)
        {
            lastGatherTime = Time.time;

            switch (currRoom)
            {
                case "Storage":
                    //added ceiling for ship variables here, will have to change with specialists
                    if (gameManager.fuelCount >= 100)
                    {
                        gameManager.fuelCount = 100;
                        break;
                    }
                    gameManager.fuelCount += 4;
                    break;

                case "Galley":
                    if (gameManager.foodCount >= 100)
                    {
                        gameManager.foodCount = 100;
                        break;
                    }
                    gameManager.foodCount += 4;
                    break;

                case "EngineRoom":
                    if (ship.Health >= 20.0f)
                    {
                        ship.Health = 20.0f;
                        break;
                    }
                    ship.Health += 0.25f;
                    break;

                case "WeaponStation":
                    ship.Attack(enemy);
                    break;

                default:
                    break;
            }

            gameManager.fuelCount -= 1;
            gameManager.foodCount -= 1;

            if (gameManager.fuelCount < 0)
            {
                gameManager.fuelCount = 0;
            }
            if (gameManager.foodCount < 0)
            {
                gameManager.foodCount = 0;
            }
        }

        Vector3 foodScale = foodBar.transform.localScale;
        foodScale.x = gameManager.foodCount / 100;
        foodBar.transform.localScale = foodScale;

        Vector3 energyScale = energyBar.transform.localScale;
        energyScale.x = gameManager.fuelCount / 100;
        energyBar.transform.localScale = energyScale;

    }
}
