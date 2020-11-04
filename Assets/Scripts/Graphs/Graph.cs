using UnityEngine;
using UnityEngineInternal;

public class Graph
{
    private const int NUM_VERTICES = 4;
    private Vertex[] vertices;
    private int[,] adjMatrix;
    public int[,] AdjMatrix { get => adjMatrix; set => adjMatrix = value; }
    int numVerts;
    GenericStack gStack = new GenericStack();

    public Graph()
    {
        vertices = new Vertex[NUM_VERTICES];
        AdjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
        numVerts = 0;
        for (int j = 0; j < NUM_VERTICES; j++)
        {
            for (int k = 0; k <= NUM_VERTICES - 1; k++)
            {
                AdjMatrix[j, k] = 0;
                //Debug.Log("k" + k + "\nj" + j + "\n" + AdjMatrix[j, k]);                                
            }
        }
    }
    public void AddVertex(string label)
    {
        vertices[numVerts] = new Vertex(label);
        numVerts++;
    }
    public void AddEdge(int start, int eend)
    {
        AdjMatrix[start, eend] = 1;
        AdjMatrix[eend, start] = 1;
    }
    public string ReturnVertex(int v)
    {
        return vertices[v].Label + " ";
    }
    public void DisplayMatrix()
    {
        string output = "";

        for (int j = 0; j < NUM_VERTICES; j++)
        {
            output += "Line: " + j + ";";
            for (int k = 0; k < NUM_VERTICES - 1; k++)
            {               
               output += " " + AdjMatrix[j, k] + ",";               
            }
            output += "\n";
            Debug.Log(output);
        }
       
    }
    public int NoSuccessors()
    {
        bool isEdge;
        for(int row = 0; row <= numVerts - 1;row++)
        {
            isEdge = false;
            for(int col = 0; col <= numVerts - 1;col++)
            {
                if(AdjMatrix[row,col] > 0)
                {
                    isEdge = true;
                    break;
                }
            }
            if (!isEdge)
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
            AdjMatrix[row, col] = AdjMatrix[row + 1, col];
    }
    private void MoveCol(int col, int length)
    {
        for (int row = 0; row <= length - 1; row++)
            AdjMatrix[row, col] = AdjMatrix[row, col + 1];
    }
    public void TopSort()
    {
        
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
