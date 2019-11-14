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

    float energy;
    float food;

    public string currRoom;

    public float gatherInterval;
    float lastGatherTime;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        energy = 0;
        food = 0;
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
                    if (energy >= 100.0f)
                    {
                        energy = 100.0f;
                        break;
                    }
                    energy += 4;
                    break;

                case "Galley":
                    if (food >= 100.0f)
                    {
                        food = 100.0f;
                        break;
                    }
                    food += 4;
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

            energy -= 2;
            food -= 2;

            if (energy < 0)
            {
                energy = 0;
            }
            if (food < 0)
            {
                food = 0;
            }
        }

        Vector3 foodScale = foodBar.transform.localScale;
        foodScale.x = food / 100;
        foodBar.transform.localScale = foodScale;

        Vector3 energyScale = energyBar.transform.localScale;
        energyScale.x = energy / 100;
        energyBar.transform.localScale = energyScale;

    }
}
