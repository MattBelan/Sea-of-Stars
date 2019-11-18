using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    public List<MapNode> connectedNodes;
    public int nodeNum;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool nodeIsConnected = false;

            foreach(MapNode node in connectedNodes)
            {
                if(manager.currNode == node.nodeNum)
                {
                    nodeIsConnected = true;
                }
            }

            if (nodeIsConnected)
            {
                //move to next combat
            }
        }
    }
}
