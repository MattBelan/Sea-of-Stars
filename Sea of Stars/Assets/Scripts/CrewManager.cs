using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Manages interaction with crewmembers
 */
public class CrewManager : MonoBehaviour
{
    // Attributes
    public List<GameObject> crew;
    public List<GameObject> specialistCrew;
    public int crewTotal;

    public GameObject crewPrefab;

    private List<string> crewNames = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }; // Used to pick names when creating crew, uses List<> to remove names when used
    private string[] crewRoles = { "Quartermaster", "Cook", "Engineer", "Gunner", "Loader"};

    [Header("Room Obj Refs")]
    public GameObject storage;
    public GameObject engineRoom;
    public GameObject galley;
    public GameObject magazine;
    public GameObject weaponsStation;

    // Start is called before the first frame update
    void Start()
    {
        // Recruit a crew member for each room at the start of the game
        RecruitStartingCrew();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Creates the initial crew
    private void RecruitStartingCrew()
    {
        GameObject cm;
        CrewMember cScript; // used so GetComponent is only called once per new crewmember

        for (int i = 0; i < 5; i++)
        {
            cm = Instantiate(crewPrefab);    // Create gameobject
            cScript = cm.GetComponent<CrewMember>();

            // position them correctly in the scene
            AssignToRoom(cm);

            // Give name and role
            cScript.name = crewNames[i];
            cScript.role = crewRoles[i];

            cScript.isSpecialist = false;

            crew.Add(cm);   // save ref in list

            crewNames.RemoveAt(i); // Don't use the same name for multiple crew memebers
        }
    }

    // Adds a sailor to the crew
    public void RecruitCrew(bool isSpecialist = false)
    {
        GameObject cm;
        CrewMember cScript; // used so GetComponent is only called once per new crewmember

        // Pick a random name and role for the crew member being added
        int nameNum = Random.Range(0, crewNames.Count - 1);
        int roleNum = Random.Range(0, 4);

        cm = Instantiate(crewPrefab);    // Create gameobject
        cScript = cm.GetComponent<CrewMember>();

        // position them correctly in the scene
        AssignToRoom(cm); 

        // Give name and role
        cScript.name = crewNames[nameNum];
        cScript.role = crewRoles[roleNum];

        if (isSpecialist)
        {            
            cScript.isSpecialist = true;

            specialistCrew.Add(cm); // save ref in list
        }
        else
        {
            cScript.isSpecialist = false;

            crew.Add(cm);   // save ref in list
        }        

        crewNames.RemoveAt(nameNum); // Don't use the same name for multiple crew memebers
    }

    // Moves a crewmember at the appropriate location
    private void AssignToRoom(GameObject cm)
    {
        switch(cm.GetComponent<CrewMember>().role)
        {
            case "Quartermaster":
                cm.transform.position = storage.transform.position;
                break;
            case "Cook":
                cm.transform.position = galley.transform.position;
                break;
            case "Engineer":
                cm.transform.position = engineRoom.transform.position;
                break;
            case "Gunner":
                cm.transform.position = weaponsStation.transform.position;
                break;
            case "Loader":
                cm.transform.position = magazine.transform.position;
                break;
        }
    }
}
