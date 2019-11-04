using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Manages interaction with crewmembers
 */
public class CrewManager : MonoBehaviour
{
    // Attributes
    public List<CrewMember> crew;
    public List<CrewMember> specialistCrew;
    public int crewTotal;

    private List<string> crewNames = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }; // Used to pick names when creating crew, uses List<> to remove names when used
    private string[] crewRoles = { "Navigator", "Cook", "Engineer", "Gunner", "Loader"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Adds a sailor to the crew
    public void RecruitCrew(bool isSpecialist = false)
    {
        // Pick a random name and role for the crew member being added
        int nameNum = Random.Range(0, crewNames.Count - 1);
        int roleNum = Random.Range(0, 4);

        if (isSpecialist)
        {
            specialistCrew.Add(new CrewMember(crewNames[nameNum], crewRoles[roleNum], true));
            crewNames.RemoveAt(nameNum);

            return;
        }

        // Non-specialist crew member
        crew.Add(new CrewMember(crewNames[nameNum], crewRoles[roleNum], false));
        crewNames.RemoveAt(nameNum);
    }
}
