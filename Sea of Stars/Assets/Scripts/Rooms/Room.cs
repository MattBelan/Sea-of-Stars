using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Parent Class: Defines a generic room on the ship
 */
public class Room : MonoBehaviour
{
    [Header("Managers")]
    public GameManager gameManager;
    public DialogueManager dialogueManager;

    public TestPlayerScript player;
    public string roomName;

    public CombatShip combatScript;
    public List<CrewMember> crew; // Crew members assigned to the room
    public bool hasSpecialist; // Does the room have a crewmember that is a specialist?

    [Header("Room Bonus Data")]
    public bool bonusActive;
    public float timer;
    public int seconds; // time elapsed in seconds
    public int crewBonus;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!dialogueManager) dialogueManager = GameObject.Find("GameManager").GetComponent<DialogueManager>();

        combatScript = GameObject.Find("Ship").GetComponent<CombatShip>();
        crew = new List<CrewMember>();
        hasSpecialist = false;

        bonusActive = false;
        timer = 0f;
        seconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = transform.position;

            if(roomName != "Bridge")
            {
                newPos.y -= .3f;
            }

            player.transform.position = newPos;
            player.currRoom = roomName;
        }
    }
}
