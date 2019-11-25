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
    public float timeLimit;
    private float waitTime;

    private float repairRate;
    private float attackRate;
    private float attackTimer2;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currRoom = "Bridge";
        timeLimit = 1.0f;
        waitTime = 0.0f;
        repairRate = 0.25f;
        attackRate = 1.0f;
        attackTimer2 = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime += timeLimit;

            gameManager.fuelCount -= 1.0f;
            gameManager.foodCount -= 1.0f;

            if (gameManager.fuelCount < 0)
            {
                gameManager.fuelCount = 0;
                attackRate = 1.25f;
            }
            else
            {
                attackRate = 1.0f;
            }
            if (gameManager.foodCount < 0)
            {
                gameManager.foodCount = 0;
                repairRate = 0.05f;
            }
            else
            {
                repairRate = 0.25f;
            }

            switch (currRoom)
            {
                case "Storage":
                    //added ceiling for ship variables here, will have to change with specialists
                    if (gameManager.fuelCount >= 100)
                    {
                        gameManager.fuelCount = 100;
                        break;
                    }
                    gameManager.fuelCount += 5.0f;
                    break;

                case "Galley":
                    if (gameManager.foodCount >= 100)
                    {
                        gameManager.foodCount = 100;
                        break;
                    }
                    gameManager.foodCount += 5.0f;
                    break;

                case "EngineRoom":
                    if (ship.Health >= 20.0f)
                    {
                        ship.Health = 20.0f;
                        break;
                    }
                    ship.Health += repairRate;
                    ship.Health = Mathf.Round(ship.Health * 100.0f) / 100.0f;
                    break;

                case "WeaponStation":
                    if(attackTimer2 == 0.0f)
                    {
                        attackTimer2 = Time.time;
                    }
                    else if (Time.time - (attackTimer2 * attackRate) > 3){
                        ship.Attack(enemy);
                        attackTimer2 = 0.0f;
                    }
                    break;
                default:
                    break;
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
