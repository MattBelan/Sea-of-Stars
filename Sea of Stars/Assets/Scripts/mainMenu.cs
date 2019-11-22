using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
	public string playerName = "";
    public GameObject StartBTN;
    public GameObject QuitBTN;
    public GameObject TitleText;
    public GameObject NameGrabber;
    public InputField nameField;
    public bool nameEntered = false;
    public Image uiImage;
    // Start is called before the first frame update
    public void Start()
    {
        if (GameObject.Find("inputName"))
        {
            nameField = GetComponent<InputField>(); //Only sets this if the gameobject is the input, so it doesn't cause issues with the other buttons
        }
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (NameGrabber.gameObject.activeSelf == true)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                playerName = nameField.text; //Sets the text in the input field to the player name string
                PlayerPrefs.SetString("name", playerName);
                //Debug.Log("Shitlord");
                //Debug.Log(playerName);
                Debug.Log(PlayerPrefs.GetString("name"));
                SceneManager.LoadScene(1);
            }
        }
    }

    public void GameQuit()
    {
    	Application.Quit();
    	Debug.Log("Quit Game");
    }

    public void StartGame(int sceneIndex)
    {
        
        StartBTN.gameObject.SetActive(false);
        QuitBTN.gameObject.SetActive(false);
        TitleText.gameObject.SetActive(false); //Disables all UI and enables the name input field
        NameGrabber.gameObject.SetActive(true);

        Debug.Log(playerName);

        //Resetting room health on fresh game
        PlayerPrefs.SetFloat("EngineRoom", 4);
        PlayerPrefs.SetFloat("Bridge", 4);
        PlayerPrefs.SetFloat("Galley", 4);
        PlayerPrefs.SetFloat("Magazine", 4);
        PlayerPrefs.SetFloat("WeaponStation", 4);

        //Resetting ship/enemy health and game progression
        PlayerPrefs.SetFloat("ShipHealth", 20);
        PlayerPrefs.SetFloat("EnemyHealth", 10);
        PlayerPrefs.SetFloat("CurrLevel", 1);
        PlayerPrefs.SetFloat("CurrNode", 0);
        PlayerPrefs.SetFloat("InCombat", 1);

        Debug.Log(PlayerPrefs.GetFloat("ShipHealth"));

        if (nameEntered == true)
        {

            SceneManager.LoadScene(sceneIndex);
        }
    }
}

//Marie's script
