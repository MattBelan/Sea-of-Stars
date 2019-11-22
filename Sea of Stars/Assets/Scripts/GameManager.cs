using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Holds key game data and methods
 */
public class GameManager : MonoBehaviour
{
    [Header("Resource Data")]
    public int fuelCount = 10; // This is separate to prevent the header from appearing above all 3 attributes
    public int foodCount = 10, luminosityCount = 10, minLuminosity = 0;
    public int crewCount = 0;

    private int foodCost;

    public bool inCombat;
    public CombatShip ship;
    public CombatEnemy enemy;

    //used for progression
    public int currLevel;

    //used for map
    public int currNode;

    public GameObject map;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = true;

        if (PlayerPrefs.GetFloat("InCombat") > 0)
        {
            enemy.Health = PlayerPrefs.GetFloat("EnemyHealth");
        }

        ship.Health = PlayerPrefs.GetFloat("ShipHealth");
        //Debug.Log(PlayerPrefs.GetFloat("ShipHealth"));
        currLevel = PlayerPrefs.GetInt("CurrLevel");
        currNode = PlayerPrefs.GetInt("CurrNode");
    }

    // Update is called once per frame
    void Update()
    {
        //once specialists/crew are added up crewCount

        ship.inCombat = inCombat;
        enemy.inCombat = inCombat;

        //saving in-game data
        PlayerPrefs.SetFloat("ShipHealth", ship.Health);
        PlayerPrefs.SetFloat("EnemyHealth", enemy.Health);


        if (inCombat)
        {
            //Put combat specific function calls here
            PlayerPrefs.SetInt("InCombat", 1);
        }
        else
        {
            //Put non-combat specific functions here
            PlayerPrefs.SetInt("InCombat", 0);

            if (Input.GetKeyDown(KeyCode.M))
            {
                //bring up map
                if (map.activeSelf)
                {
                    map.SetActive(false);
                    canvas.SetActive(true);
                }
                else
                {
                    map.SetActive(true);
                    canvas.SetActive(false);
                }
            }
        }

        //Getting out of combat
        if (enemy.Health <= 0)
        {
            inCombat = false;
        }

        //foodCount -= crewCount;
        //for some reason subtracts 10 every frame
    }

    public void MoveToNode(MapNode node)
    {
        currLevel++;
        currNode = node.nodeNum;

        PlayerPrefs.SetInt("CurrLevel", currLevel);
        PlayerPrefs.SetInt("CurrNode", currNode);
        PlayerPrefs.SetFloat("InCombat", 1);
        PlayerPrefs.SetFloat("EnemyHealth", 10);

        SceneManager.LoadScene("TestScene");
    }
}
