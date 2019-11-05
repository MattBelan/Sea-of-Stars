using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Movable M1;
    public StaticCircle S1;
    public Movable M2;
    public StaticCircle S2;

    public SuccessBounds Success1;
    public SuccessBounds Success2;

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
        m1X = M1.transform.position.x;
        m2X = M2.transform.position.x;
        M2.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newM1Pos = new Vector3(m1X, M1.transform.position.y, M1.transform.position.z);
        Vector3 newM2Pos = new Vector3(m2X, M2.transform.position.y, M2.transform.position.z);
        Vector3 newS1Pos;
        Vector3 newS2Pos;

        Vector3 mouse = Input.mousePosition;
        mouse.z = 10.0f;
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        //checking bounds and end conditions on movables
        if (newM1Pos.y > 4.0f)
        {
            newM1Pos.y = 4.0f;
        }
        else if (newM1Pos.y < -4.0f)
        {
            newM1Pos.y = -4.0f;
        }
        else
        {
            if (newM1Pos.y == -4.0f)
            {
                M1.canMove = false;
                M1.ChangeMaterial();
                m1Moved = true;
                M2.canMove = true;
            }
        }

        if (newM2Pos.y < -4.0f)
        {
            newM2Pos.y = -4.0f;
        }
        else if (newM2Pos.y > 4.0f)
        {
            newM2Pos.y = 4.0f;
        }
        else
        {
            if (newM2Pos.y == 4.0f)
            {
                M2.canMove = false;
                M2.ChangeMaterial();
                m2Moved = true;
            }
        }

        if (m1Moved)
        {
            newS1Pos = new Vector3(S1.transform.position.x - 0.05f, S1.transform.position.y, 1);
            if(newS1Pos.x <= -4.0f)
            {
                newS1Pos.x = -4.0f;
                S1.ChangeMaterial();
            }
        }
        else
        {
            newS1Pos = S1.transform.position;
        }


        if (m2Moved)
        {
            newS2Pos = new Vector3(S2.transform.position.x + 0.05f, S2.transform.position.y, 1);
            if (newS2Pos.x >= 4.0f)
            {
                newS2Pos.x = 4.0f;
                S2.ChangeMaterial();
            }
        }
        else
        {
            newS2Pos = S2.transform.position;
        }


        M1.transform.position = newM1Pos;
        S1.transform.position = newS1Pos;
        M2.transform.position = newM2Pos;
        S2.transform.position = newS2Pos;

    }
}
