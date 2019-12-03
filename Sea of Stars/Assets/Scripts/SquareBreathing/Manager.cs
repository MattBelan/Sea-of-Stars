using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Movable M1;
    public Movable M2;
    public SliderBar Slider1;
    public SliderBar Slider2;

    public GameObject stateTextObj;
    public GameObject hintTextObj;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    public Material flash;
    public Material defaultMat;

    private int light1Flash;
    private int light2Flash;
    private int light3Flash;
    private int light4Flash;

    public StaticArrow H1;
    public StaticArrow H2;

    private bool m1Moved;
    private bool s1Moved;
    private bool m2Moved;
    private bool s2Moved;

    private float m1X;
    private float m2X;

    // Start is called before the first frame update
    void Start()
    {
        m1Moved = false;
        m2Moved = false;
        s1Moved = false;
        s2Moved = false;
        light1Flash = 2;
        light2Flash = 2;
        light3Flash = 2;
        light4Flash = 2;
        m1X = M1.transform.position.x;
        m2X = M2.transform.position.x;
        M2.canMove = false;
        H2.Hide();
        stateTextObj.GetComponent<Text>().text = "Inhale";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newM1Pos = new Vector3(m1X, M1.transform.position.y, M1.transform.position.z);
        Vector3 newM2Pos = new Vector3(m2X, M2.transform.position.y, M2.transform.position.z);
        Vector3 newH1Pos = H1.transform.position;
        Vector3 newH2Pos = H2.transform.position;

        //checking bounds and end conditions on movables
        if (newM1Pos.y > 3.0f)
        {
            newM1Pos.y = 3.0f;
        }
        else if (newM1Pos.y < -3.0f)
        {
            newM1Pos.y = -3.0f;
        }
        else
        {
            if (newM1Pos.y >= 2.75f)
            {
                //Success, change to in bounds rather than coords later
                newM1Pos.y = 3.0f;
                M1.canMove = false;
                light1Flash = 0;
                light1.GetComponent<Renderer>().material = defaultMat;
                m1Moved = true;
                stateTextObj.GetComponent<Text>().text = " Hold";
                hintTextObj.GetComponent<Text>().text = "";
            }
            else if (newM1Pos.y > H1.transform.position.y + 3.0f || newM1Pos.y < H1.transform.position.y - 3.0f)
            {
                newM1Pos.y = -3.0f;
            }
        }

        if (newM2Pos.y < -3.0f)
        {
            newM2Pos.y = -3.0f;
        }
        else if (newM2Pos.y > 3.0f)
        {
            newM2Pos.y = 3.0f;
        }
        else
        {
            if (newM2Pos.y <= -2.75f)
            {
                newM2Pos.y = -3.0f;
                M2.canMove = false;
                light3Flash = 0;
                light3.GetComponent<Renderer>().material = defaultMat;
                m2Moved = true;
                stateTextObj.GetComponent<Text>().text = " Hold";
                hintTextObj.GetComponent<Text>().text = "";
            }
            else if (newM2Pos.y > H2.transform.position.y + 3.0f || newM2Pos.y < H2.transform.position.y - 3.0f)
            {
                newM1Pos.y = 3.0f;
            }
        }

        //Handling the static circles not controlled by the player
        if (m1Moved && !m2Moved)
        {
            Slider1.Val += 0.0045f;
            if(Slider1.Val >= 1.0f)
            {
                Slider1.Val = 1.0f;
                light2Flash = 0;
                light2.GetComponent<Renderer>().material = defaultMat;
                s1Moved = true;
                M2.canMove = true;
                stateTextObj.GetComponent<Text>().text = "Exhale";
                hintTextObj.GetComponent<Text>().text = "Pull the lever, matching \n the arrow's speed";
            }
        }

        if (m2Moved)
        {
            Slider2.Val += 0.0045f;
            if (Slider2.Val >= 1.0f)
            {
                Slider2.Val = 1.0f;
                light4Flash = 0;
                light4.GetComponent<Renderer>().material = defaultMat;
                s2Moved = true;
            }
        }

        //handling hints circles
        if (!m1Moved)
        {
            newH1Pos = new Vector3(H1.transform.position.x, H1.transform.position.y + 0.0225f, 1);
            if (newH1Pos.y >= 3.0f)
            {
                newH1Pos.y = -2.0f;
            }
        }
        else
        {
            H1.Hide();
        }

        if (s1Moved)
        {
            H2.Show();

            if (!m2Moved)
            {
                newH2Pos = new Vector3(H2.transform.position.x, H2.transform.position.y - 0.0225f, 1);
                if (newH2Pos.y <= -3.0f)
                {
                    newH2Pos.y = 2.0f;
                }
            }
            else
            {
                H2.Hide();
            }
        }

        if (s2Moved)
        {
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
        }
        
        M1.transform.position = newM1Pos;
        M2.transform.position = newM2Pos;
        H1.transform.position = newH1Pos;
        H2.transform.position = newH2Pos;

        if (Time.frameCount % 30 == 0)
        {
            if (light1Flash != 0)
            {
                if (light1Flash == 2)
                {
                    light1.GetComponent<Renderer>().material = flash;
                    light1Flash = 1;
                }
                else
                {
                    light1.GetComponent<Renderer>().material = defaultMat;
                    light1Flash = 2;
                }
            }
            if (light2Flash != 0)
            {
                if (light2Flash == 2)
                {
                    light2.GetComponent<Renderer>().material = flash;
                    light2Flash = 1;
                }
                else
                {
                    light2.GetComponent<Renderer>().material = defaultMat;
                    light2Flash = 2;
                }
            }
            if (light3Flash != 0)
            {
                if (light3Flash == 2)
                {
                    light3.GetComponent<Renderer>().material = flash;
                    light3Flash = 1;
                }
                else
                {
                    light3.GetComponent<Renderer>().material = defaultMat;
                    light3Flash = 2;
                }
            }
            if (light4Flash != 0)
            {
                if (light4Flash == 2)
                {
                    light4.GetComponent<Renderer>().material = flash;
                    light4Flash = 1;
                }
                else
                {
                    light4.GetComponent<Renderer>().material = defaultMat;
                    light4Flash = 2;
                }
            }
        }

    }
}
