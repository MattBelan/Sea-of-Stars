using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public GameManager gm;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        //getting input based on axis, under project settings->input
        float vertAxis = Input.GetAxis("Vertical");
        float horiAxis = Input.GetAxis("Horizontal");

        Vector3 newPos = transform.position;

        //adjusting position
        if (vertAxis !=0)
        {
            newPos.y += vertAxis * speed;
        }
        if (horiAxis != 0)
        {
            newPos.x += horiAxis * speed;
        }

        //setting ship angle and changing posiiton
        direction = newPos - transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion newRot = Quaternion.Euler(direction);

        transform.position = newPos;
        transform.rotation = newRot;
    }

    //Temp resource gathering, to be removed/replaced later
    public void AddFuel(int amount)
    {
        gm.fuelCount += amount;
    }

    public void AddFood(int amount)
    {
        gm.foodCount += amount;
    }
}
