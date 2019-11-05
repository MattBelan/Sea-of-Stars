using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCircle : MonoBehaviour
{
    public Material success;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMaterial()
    {
        GetComponent<Renderer>().material = success;
    }

    public void Hide()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Show()
    {
       GetComponent<MeshRenderer>().enabled = true;
    }
}
