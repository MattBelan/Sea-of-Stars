using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    //temporary collectible class for first iteration

    public int value;
    Collider col;
    public Ship player;
    public string type;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col.bounds.Intersects(player.GetComponent<Collider>().bounds))
        {
            switch (type)
            {
                case "food":
                    player.AddFood(value);
                    break;

                case "fuel":
                    player.AddFuel(value);
                    break;

                default:
                    break;
            }

            Destroy(gameObject);
        }
    }

    
}
