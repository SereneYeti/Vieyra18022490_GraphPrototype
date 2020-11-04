using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNode<T>
{
    //Base node 
    public MyNode<T> Next
    {
        get;
        set;
    } = null;
    //Stores previous node
    public MyNode<T> Previous
    {
        get;
        set;
    } = null;
    //Referenece to the data held in the list i.e in this case the dialogueData class
    public T Data
    {
        get;
        set;
    }
    
}
