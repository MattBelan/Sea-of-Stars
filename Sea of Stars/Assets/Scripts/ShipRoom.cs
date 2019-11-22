using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoom : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float roomModifier;
    public string id;

    // Start is called before the first frame update
    void Start()
    {
        health = PlayerPrefs.GetFloat(id);
    }

    // Update is called once per frame
    void Update()
    {
        roomModifier = health / maxHealth;
        PlayerPrefs.SetFloat(id, health);
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            health += 1;
        }
    }
}
