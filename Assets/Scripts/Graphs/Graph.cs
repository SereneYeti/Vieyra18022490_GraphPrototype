using UnityEngine;
using UnityEngineInternal;

public class Graph
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
        for (int j = 0; j < NUM_VERTICES; j++)
            for (int k = 0; k < NUM_VERTICES - 1; k++)
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
    public int NoSuccessors()
    {
        bool isEdge;
        for(int row = 0; row < numVerts - 1;row++)
        {
            isEdge = false;
            for(int col = 0; col <= numVerts - 1;col++)
            {
                if(adjMatrix[row,col] > 0)
                {
                    isEdge = true;
                    break;
                }
            }
            if (!(isEdge))
            { return row; }
        }
        return -1;
    }
    public void DelVertex(int vert)
    {
        if(vert != numVerts-1)
        {
            for (int j = vert; j <= numVerts - 1; j++)
                vertices[j] = vertices[j + 1];
            for (int row = vert; row <= numVerts - 1; row++)
                MoveRow(row, numVerts);
            for (int col = vert; col <= numVerts - 1; col++)
                MoveCol(col, numVerts - 1);
        }
    }
    private void MoveRow(int row, int length)
    {
        for (int col = 0; col <= length - 1; col++)
            adjMatrix[row, col] = adjMatrix[row + 1, col];
    }
    private void MoveCol(int col, int length)
    {
        for (int row = 0; row <= length - 1; row++)
            adjMatrix[row, col] = adjMatrix[row, col + 1];
    }
    public void TopSort()
    {
        GenericStack gStack = new GenericStack();
        int origVerts = numVerts;
        while (numVerts > 0)
        {
            int currVertex = NoSuccessors();
            if (currVertex == -1)
            {
                Debug.LogError("Graph has cycles.");
                return;
            }
            gStack.Push(vertices[currVertex].Label);
            DelVertex(currVertex);
        }
        while (gStack.Count > 0)
        {
            Debug.Log(gStack.Pop() + " ");
        }
    }

}
