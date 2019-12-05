using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Represents a crew member on the ship
 */
public class CrewMember : MonoBehaviour
{
    [Header("Managers")]
    public CrewManager crewManager;

    // Attributes
    public string crewName;
    public string role;
    public bool isSpecialist = false;
    public Room assignedRoom;

    // Movement
    private Vector3 startPos;
    private int direction;
    public float speedMod;

    [Header("Job Variables")]
    public int multiplier;
    private float timer;
    public int seconds; // time elapsed in seconds
    public int jobTime; // Amount of time required to complete job, shorter time for specialists

    private void Start()
    {
        if (!crewManager) crewManager = GameObject.Find("GameManager").GetComponent<CrewManager>();

        startPos = transform.position;
        direction = 1;
        multiplier = 1;
        speedMod = Random.Range(1, 1.8f);
    }

    private void Update()
    {
        Move();

        timer += Time.deltaTime;
        seconds = (int)timer % 60;

        // Do job every 'jobTime' seconds
        if(seconds >= jobTime)
        {
            timer = 0f;
            seconds = 0;

            DoJob();
        }
    }

    // Moves the Crew member back and forth
    private void Move()
    {
        if (transform.position.x < startPos.x - 1)
        {
            direction = 1;
        }
        else if (transform.position.x > startPos.x + 1)
        {
            direction = -1;
        }

        transform.position = new Vector3(transform.position.x + (0.005f * direction) * speedMod, transform.position.y, transform.position.z);
    }

    // Crew member performs a task associated with their role in the room they are assigned to
    private void DoJob()
    {
        switch(role)
        {
            case "Quartermaster":
                // Generates fuel
                (assignedRoom as Storage).Refuel(multiplier);
                break;
            case "Cook":
                // Generates food
                (assignedRoom as Galley).PrepareFood(multiplier);
                break;
            case "Engineer":
                // Restores health
                (assignedRoom as EngineRoom).RepairEngine(multiplier);
                break;
            case "Gunner":
                // Increases damage
                (assignedRoom as WeaponStations).ManBattlestations(multiplier);
                break;
            case "Loader":
                // Increases fire rate
                (assignedRoom as Magazine).RestockAmmo(multiplier);
                break;
        }
    }
}
