using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private const int NUM_VERTICES = 20;
    private Vertex[] vertices;
    private int[,] adjMatrix;
    int numVerts;

    public Graph()
    {
        vertices = new Vertex[NUM_VERTICES];
        adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
        numVerts = 0;
        for (int j = 0; j <= NUM_VERTICES; j++)
            for (int k = 0; k <= NUM_VERTICES - 1; k++)
                adjMatrix[j, k] = 0;
    }
    public void AddVertex(string label)
    {
        vertices[numVerts] = new Vertex(label);
        numVerts++;
    }
    public void AddEdge(int start, int eend)
    {
        adjMatrix[start, eend] = 1;
        adjMatrix[eend, start] = 1;
    }
    public string ReturnVertex(int v)
    {
        return vertices[v].Label + " ";
    }
}
