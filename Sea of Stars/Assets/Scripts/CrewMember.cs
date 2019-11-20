using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Represents a crew member on the ship
 */
public class CrewMember : MonoBehaviour
{
    // Attributes
    public string crewName;
    public string role;
    public bool isSpecialist = false;

    // Movement
    private Vector3 startPos;
    private int direction;

    private void Start()
    {
        startPos = transform.position;
        direction = 1;
    }

    private void Update()
    {
        if(transform.position.x < startPos.x - 1)
        {
            direction = 1;
        }
        else if(transform.position.x > startPos.x + 1)
        {
            direction = -1;
        }

        Move();
    }

    // Moves the Crew member back and forth
    private void Move()
    {
        transform.position = new Vector3(transform.position.x + (0.025f * direction), transform.position.y, transform.position.z);
    }
}
