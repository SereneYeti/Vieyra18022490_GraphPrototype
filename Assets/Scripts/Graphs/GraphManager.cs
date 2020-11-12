using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    #region Singleton Setup
    private static GraphManager instance;

    public static GraphManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public Graph graphFin_Sage = new Graph();
    public Graph graphFin_Social = new Graph();
    //18 will ensure there are no null positions but will need to be made bigger if the dialogue is added to
    public int Sage_NumVerts = 18;
    public int Social_NumVerts = 20;

    public void InitializeGraphs()
    {
        graphFin_Sage.vertices = new Vertex[Sage_NumVerts];
        graphFin_Social.vertices = new Vertex[Social_NumVerts];

        graphFin_Sage.adjList = new LinkedList<int>[Sage_NumVerts];
        graphFin_Social.adjList = new LinkedList<int>[Social_NumVerts];

        for (int i = 0; i < Sage_NumVerts; i++)
            graphFin_Sage.adjList[i] = new LinkedList<int>();
        for (int i = 0; i < Social_NumVerts; i++)
            graphFin_Social.adjList[i] = new LinkedList<int>();
    }

    

    int GetArrayPos(Vertex[] vertices, int SearchID)
    {
        //Default is -1 because its outside the array
        int pos = -1;

        for(int i = 0; i < vertices.Length; i++)
        {
            if (SearchID == vertices[i].LineID)
                return pos;
        }

        return pos;
    }

    public void Start()
    {
        InitializeGraphs();
        DialogueManager.Instance.LoadGraphs();
        //Debug.Log(graphFin_Sage.ShowVertexID_Pos());
        graphFin_Sage.SetupEdges();
        graphFin_Sage.printAdjGraph();
        
    }

}
