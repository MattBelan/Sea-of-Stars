using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Holds key game data and methods
 */
public class GameManager : MonoBehaviour
{
    [Header("Resource Data")]
    // Food for thought: Condense these as a Vector3 called 'shipStats'?
    public int fuelCount = 10; // This is separate to prevent the header from appearing above all 3 attributes
    public int foodCount = 10, luminosityCount = 10, minLuminosity = 0;

    private int foodCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
