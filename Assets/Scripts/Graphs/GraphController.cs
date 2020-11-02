using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    Graph theGraph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        theGraph.AddVertex("CS1");
        theGraph.AddVertex("CS2");
        theGraph.AddVertex("DS");
        theGraph.AddVertex("OS");
        theGraph.AddVertex("ALG");
        theGraph.AddVertex("AL");
        theGraph.AddEdge(0, 1);
        theGraph.AddEdge(1, 2);
        theGraph.AddEdge(1, 5);
        theGraph.AddEdge(2, 3);
        theGraph.AddEdge(2, 4);
        theGraph.TopSort();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
