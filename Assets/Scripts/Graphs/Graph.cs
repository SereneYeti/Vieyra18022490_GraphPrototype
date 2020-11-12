using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Graph
{    
    //Book
    //private const int NUM_VERTICES = 20;
    //private Vertex[] vertices;
    //private int[,] adjMatrix;
    //public int[,] AdjMatrix { get => adjMatrix; set => adjMatrix = value; }
    //int numVerts;
    //GenericStack gStack = new GenericStack();

    //public Graph()
    //{
    //    vertices = new Vertex[NUM_VERTICES];
    //    AdjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
    //    numVerts = 0;
    //    for (int j = 0; j < NUM_VERTICES; j++)
    //    {
    //        for (int k = 0; k <= NUM_VERTICES - 1; k++)
    //        {
    //            AdjMatrix[j, k] = 0;
    //            //Debug.Log("k" + k + "\nj" + j + "\n" + AdjMatrix[j, k]);                                
    //        }
    //    }
    //}

    //public void AddVertex(string label)
    //{
    //    Debug.Log(numVerts);
    //    vertices[numVerts] = new Vertex(label);        
    //    numVerts++;

    //}
    //public void AddEdge(int start, int eend)
    //{
    //    AdjMatrix[start, eend] = 1;
    //    AdjMatrix[eend, start] = 1;
    //}
    //public string ReturnVertex(int v)
    //{
    //    try
    //    {
    //        return vertices[v].Label + " ";
    //    }
    //    catch(System.Exception ex)
    //    {
    //        Debug.LogError(ex);
    //        return "Not found";
    //    }

    //}

    //public string DisplayVertexData(int v)
    //{
    //    return vertices[v].DialogueData + " ";
    //}
    //public void DisplayMatrix()
    //{
    //    string output = "";

    //    for (int j = 0; j < NUM_VERTICES; j++)
    //    {
    //        output += "Line: " + j + ";";
    //        for (int k = 0; k < NUM_VERTICES - 1; k++)
    //        {               
    //           output += " " + AdjMatrix[j, k] + ",";               
    //        }
    //        output += "\n";
    //        Debug.Log(output);
    //    }

    //}
    //public int NoSuccessors()
    //{
    //    bool isEdge;
    //    for(int row = 0; row <= numVerts - 1;row++)
    //    {
    //        isEdge = false;
    //        for(int col = 0; col <= numVerts - 1;col++)
    //        {
    //            if(AdjMatrix[row,col] > 0)
    //            {
    //                isEdge = true;
    //                break;
    //            }
    //        }
    //        if (!isEdge)
    //        { return row; }
    //    }
    //    return -1;
    //}
    //public void DelVertex(int vert)
    //{
    //    if(vert != numVerts-1)
    //    {
    //        for (int j = vert; j <= numVerts - 1; j++)
    //            vertices[j] = vertices[j + 1];
    //        for (int row = vert; row <= numVerts - 1; row++)
    //            MoveRow(row, numVerts);
    //        for (int col = vert; col <= numVerts - 1; col++)
    //            MoveCol(col, numVerts - 1);
    //    }
    //}
    //private void MoveRow(int row, int length)
    //{
    //    for (int col = 0; col <= length - 1; col++)
    //        AdjMatrix[row, col] = AdjMatrix[row + 1, col];
    //}
    //private void MoveCol(int col, int length)
    //{
    //    for (int row = 0; row <= length - 1; row++)
    //        AdjMatrix[row, col] = AdjMatrix[row, col + 1];
    //}
    //public void TopSort()
    //{

    //    int origVerts = numVerts;
    //    while (numVerts > 0)
    //    {
    //        int currVertex = NoSuccessors();
    //        if (currVertex == -1)
    //        {
    //            Debug.LogError("Graph has cycles.");
    //            return;
    //        }
    //        gStack.Push(vertices[currVertex].Label);
    //        DelVertex(currVertex);
    //    }
    //    while (gStack.Count > 0)
    //    {
    //        Debug.Log(gStack.Pop() + " ");
    //    }
    //}

    #region AdjacencyList

    //current Dialogue Length
    
    public LinkedList<int>[] adjList;
    public Vertex[] vertices = new Vertex[20];
    public int vert = 0;

    public static void addEdge(LinkedList<int>[] adj, int u, int v)
    {
        try
        {
            adj[u].AddLast(v);
            adj[v].AddLast(u);
        }
        catch(System.Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    public void SetupEdges()
    {
        //int[] possibleRespones = new int[3];
        //int arrPos;
        for (int i = 0; i < adjList.Length; i++)
        {
            //First get the possible responses            

            //possibleRespones = graph.vertices[i].DialogueData.possibleResponses;
            #region DebugLogs            
            //if (graph.vertices[i].DialogueData.possibleResponses.Length != 0)
            //    Debug.Log("LINEID: " + graph.vertices[i].LineID + "----" + graph.vertices[i].DialogueData.possibleResponses[0]);
            ////Debug.Log("1: " + possibleRespones[0]);
            //if (graph.vertices[i].DialogueData.possibleResponses.Length == 2)
            //    Debug.Log("LINEID: " + graph.vertices[i].LineID + "----" + graph.vertices[i].DialogueData.possibleResponses[1]);
            ////Debug.Log("2: " + possibleRespones[1]);
            //if (graph.vertices[i].DialogueData.possibleResponses.Length == 3)
            //    Debug.Log("LINEID: " + graph.vertices[i].LineID + "----" + graph.vertices[i].DialogueData.possibleResponses[2]);
            //Debug.Log("3: " + possibleRespones[2]);
            #endregion
            if (vertices[i] == null)
            {
                Debug.LogError("No EnemyHealth component found.");
            }
            if (vertices[i].PossibleResponses != null)
            {
                Debug.Log("I: " + vertices[i].PossibleResponses.Length);
                for (int j = 0; j < vertices[i].PossibleResponses.Length; j++)
                {   //Then search for the possible respones & get the Array pos
                    //arrPos = GetArrayPos(graph.vertices,j);                
                    if (j != -1)
                    {
                        if (vertices[i].PossibleResponses[j] - 1 == 19)
                        {
                            Graph.addEdge(adjList, i, 18);
                            //Debug.Log(vertices[i].DialogueData.possibleResponses[j] - 1);
                        }
                        else if (vertices[i].PossibleResponses[j] != -1)
                        {
                            Graph.addEdge(adjList, i, vertices[i].DialogueData.possibleResponses[j] - 1);
                            //Debug.Log(vertices[i].DialogueData.possibleResponses[j] - 1);
                        }

                    }
                }
            
                //Add the current pos as the 1st edge & found pos as the second edge

            }

        }
    }

    public void AddVertex(dialogueData _dialogueData)
    {        
        vertices[vert] = new Vertex(_dialogueData.characterID + "_" + _dialogueData.lineID, _dialogueData.possibleResponses.Length
            , _dialogueData);
        vert++;
    }

    public string ShowVertexID_Pos()
    {
        string output = "";

        for(int i = 0; i < vertices.Length; i++)
        {
            if(vertices[i] != null)
                output += "LABEL: " + vertices[i].Label + "|||| POSITION: " + i + "\n";
        }

        return output;
    }


    // A utility function to print the adjacency list  
    // representation of graph  
    public void printAdjGraph()
    {
        for (int i = 0; i < adjList.Length; i++)
        {
            Debug.Log("\nAdjacency list of vertex " + i);
            Debug.Log("head");

            foreach (var item in adjList[i])
            {
                Debug.Log(" -> " + item);
            }
        }
    }


    #endregion
}
