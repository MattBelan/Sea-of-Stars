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

        if (nameEntered == true)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

//Marie's script
