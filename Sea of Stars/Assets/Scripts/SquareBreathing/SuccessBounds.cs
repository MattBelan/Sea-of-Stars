using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessBounds : MonoBehaviour
{
    public bool isMouseOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }
}
