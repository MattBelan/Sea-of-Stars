using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Parent Class: Defines a generic room on the ship
 */
public class Room : MonoBehaviour
{
    public TestPlayerScript player;
    public string roomName;

    public List<CrewMember> crew; // Crew members assigned to the room
    public bool hasSpecialist; // Does the room have a crewmember that is a specialist?

    // Start is called before the first frame update
    void Start()
    {
        crew = new List<CrewMember>();
        hasSpecialist = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.transform.position = transform.position;
            player.currRoom = roomName;
        }
    }
}
