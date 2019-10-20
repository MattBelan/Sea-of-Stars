using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Authors: Jordan Machalek
 * Holds key game data and methods
 */
public class GameManager : MonoBehaviour
{
    [Header("Resource Data")]
    // Food for thought: Condense these as a Vector3 called 'shipStats'?
    public int fuel = 10; // This is separate to prevent the header from appearing above all 3 attributes
    public int food = 10, luminosity = 10;

    [Header("Crew Data")]
    public int crewCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
