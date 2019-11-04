using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Represents a crew member on the ship
 */
public class CrewMember
{
    // Attributes
    public string crewName;
    public string role;
    public bool isSpecialist = false;
    
    // Constructor
    public CrewMember(string nm, string rl, bool sp)
    {
        crewName = nm;
        role = rl;
        isSpecialist = sp;
    }
}
