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

    [Header("Job Variables")]
    public int baseRate;
    public int multiplier;
    private float timer;

    private void Start()
    {
        if (!crewManager) crewManager = GameObject.Find("GameManager").GetComponent<CrewManager>();

        startPos = transform.position;
        direction = 1;
    }

    private void Update()
    {
        

        Move();
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

        transform.position = new Vector3(transform.position.x + (0.025f * direction), transform.position.y, transform.position.z);
    }

    // Crew member performs a task associated with their role in the room they are assigned to
    private void DoJob()
    {
        switch(role)
        {
            case "Quartermaster":
                
                break;
            case "Cook":
                
                break;
            case "Engineer":
                

                break;
            case "Gunner":
                
                break;
            case "Loader":
                
                break;
        }
    }
}
