using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    Graph theGraph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        theGraph.AddVertex("A");
        theGraph.AddVertex("B");
        theGraph.AddVertex("C");
        theGraph.AddVertex("D");
        theGraph.AddEdge(0, 1);
        theGraph.AddEdge(1, 2);
        theGraph.AddEdge(2, 3);
        theGraph.AddEdge(3, 3);
        theGraph.DisplayMatrix();
        Debug.Log(theGraph.ReturnVertex(0));
        Debug.Log(theGraph.ReturnVertex(1));
        Debug.Log(theGraph.ReturnVertex(2));
        Debug.Log(theGraph.ReturnVertex(3));
        //theGraph.TopSort();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
