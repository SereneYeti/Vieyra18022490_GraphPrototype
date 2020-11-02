using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public bool WasVisited
    {
        get { return wasVisisted; }
        set { value = wasVisisted; }
        
    }
    private bool wasVisisted;

    public string Label
    {
        get { return label; }
        set { value = label; }
    }
    private string label;

    public Vertex(string lbl)
    {
        this.Label = lbl;
        WasVisited = false;
    }
}
