using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Movable : MonoBehaviour
{
    public Material success;
    public bool canMove;

    private Vector3 mLastPosition;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        speed = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        mLastPosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position += (Input.mousePosition - mLastPosition) * speed * Time.deltaTime;
            mLastPosition = Input.mousePosition;
        }
    }

    public void ChangeMaterial()
    {
        GetComponent<Renderer>().material = success;
    }
}
