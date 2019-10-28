using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    public GameObject foodBar;
    public GameObject energyBar;
    public GameObject directionBar;

    float energy;
    float food;
    float direction;

    public string currRoom;

    public float gatherInterval;
    float lastGatherTime;
    // Start is called before the first frame update
    void Start()
    {
        energy = 0;
        food = 0;
        direction = 0;
        lastGatherTime = 0;
        currRoom = "cabin";
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastGatherTime > gatherInterval)
        {
            lastGatherTime = Time.time;

            switch (currRoom)
            {
                case "engine":
                    energy += 4;
                    break;

                case "kitchen":
                    food += 4;
                    break;

                case "cabin":
                    direction += 4;
                    break;

                default:
                    break;
            }

            energy -= 1;
            food -= 1;
            direction -= 1;

            if (energy < 0)
            {
                energy = 0;
            }
            if (food < 0)
            {
                food = 0;
            }
            if(direction < 0)
            {
                direction = 0;
            }
        }

        Vector3 foodScale = foodBar.transform.localScale;
        foodScale.x = food / 100;
        foodBar.transform.localScale = foodScale;

        Vector3 energyScale = energyBar.transform.localScale;
        energyScale.x = energy / 100;
        energyBar.transform.localScale = energyScale;

        Vector3 directionScale = directionBar.transform.localScale;
        directionScale.x = direction / 100;
        directionBar.transform.localScale = directionScale;

    }
}
