using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Movable : MonoBehaviour
{
    public Material success;
    public bool canMove;

    private Vector3 point;
    private Vector3 offset;
    private Vector3 mouse;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        mouse.z = 10.0f;
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(mouse);
    }

    void OnMouseDrag()
    {
        if (canMove)
        {
            Vector3 currentPoint = new Vector3(mouse.x, mouse.y, mouse.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentPoint) + offset;
            transform.position = currentPosition;
        }
    }

    public void ChangeMaterial()
    {
        GetComponent<Renderer>().material = success;
    }
}
