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

    // ===== TODO: reimplement crewNames as a stack/queue =====
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

            // Pick a random name and role for the crew member being added
            int nameNum = Random.Range(0, crewNames.Count - 1);

            // Give name and role
            cScript.crewName = crewNames[nameNum];
            cScript.role = crewRoles[i]; // Assign their role
            cScript.jobTime = 20; // Set time it takes for crewmember to do a job
            cm.name = crewRoles[i];
            cScript.crewManager = this;

            // position them correctly in the scene
            AssignToRoom(cm, cScript, false);

            cm.layer = 8; // Crew Layer

            cScript.isSpecialist = false;

            crew.Add(cm);   // save ref in list

            crewNames.RemoveAt(nameNum); // Don't use the same name for multiple crew memebers
        }

        crewTotal += 5;
    }

    // Adds a sailor to the crew - can be normal or a specialist
    public void RecruitCrew(bool isSpecialist = false)
    {
        GameObject cm;
        CrewMember cScript; // used so GetComponent is only called once per new crewmember

        // Pick a random name and role for the crew member being added
        int nameNum = Random.Range(0, crewNames.Count - 1);
        int roleNum = Random.Range(0, 4);

        cm = Instantiate(crewPrefab);    // Create gameobject
        cScript = cm.GetComponent<CrewMember>();
        cScript.crewManager = this;

        cm.layer = 8; // Assign Crew Layer

        // Give name and role
        cScript.crewName = crewNames[nameNum];
        cScript.role = crewRoles[roleNum];
        cm.name = crewRoles[roleNum];

        if (isSpecialist)
        {
            cScript.jobTime = 10; // Set time it takes for crewmember to do a job

            // position them correctly in the scene
            AssignToRoom(cm, cScript, true);

            cScript.isSpecialist = true;

            specialistCrew.Add(cm); // save ref in list
        }
        else
        {
            cScript.jobTime = 20; // Set time it takes for crewmember to do a job

            // position them correctly in the scene
            AssignToRoom(cm, cScript, false);

            cScript.isSpecialist = false;

            crew.Add(cm);   // save ref in list
        }        

        crewNames.RemoveAt(nameNum); // Don't use the same name for multiple crew memebers
    }

    // Moves a crewmember at the appropriate location and gives a reference to the room's script
    private void AssignToRoom(GameObject cm, CrewMember cs, bool isSpec)
    {
        switch(cm.GetComponent<CrewMember>().role)
        {
            case "Quartermaster":
                cm.transform.position = new Vector3(storage.transform.position.x + 0.25f, storage.transform.position.y + 0.4f, storage.transform.position.z - 1);
                Storage st = storage.GetComponent<Storage>();
                cs.assignedRoom = st;
                if (isSpec) st.hasSpecialist = true;
                break;
            case "Cook":
                cm.transform.position = new Vector3(galley.transform.position.x, galley.transform.position.y + 0.4f, galley.transform.position.z - 1);
                Galley gal = galley.GetComponent<Galley>();
                cs.assignedRoom = gal;
                if (isSpec) gal.hasSpecialist = true;
                break;
            case "Engineer":
                cm.transform.position = new Vector3(engineRoom.transform.position.x, engineRoom.transform.position.y + 0.4f, engineRoom.transform.position.z - 1);
                EngineRoom er = engineRoom.GetComponent<EngineRoom>();
                cs.assignedRoom = er;
                if (isSpec) er.hasSpecialist = true;
                break;
            case "Gunner":
                cm.transform.position = new Vector3(weaponsStation.transform.position.x, weaponsStation.transform.position.y + 0.4f, weaponsStation.transform.position.z - 1);
                WeaponStations ws = weaponsStation.GetComponent<WeaponStations>();
                cs.assignedRoom = ws;
                if (isSpec) ws.hasSpecialist = true;
                break;
            case "Loader":
                cm.transform.position = new Vector3(magazine.transform.position.x, magazine.transform.position.y + 0.4f, magazine.transform.position.z - 1);
                Magazine mg = magazine.GetComponent<Magazine>();
                cs.assignedRoom = mg;
                if (isSpec) mg.hasSpecialist = true;
                break;
        }
    }
}
