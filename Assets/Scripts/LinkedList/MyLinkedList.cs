using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MyLinkedList<T>
{
    public MyNode<T> Current
    {
        get;
        set;
    }

    public MyNode<T> Head
    {
        get;
        set;
    }

    public MyNode<T> Tail
    {
        get;
        set;
    }

    public int Length = 0;

    //Constructor
    public MyLinkedList()
    {
        Head = null;
        Tail = null;
        Current = null;
    }

    //This will be the add method to add a new node to the linked list
    public void Add(T content)
    {
        MyNode<T> node = new MyNode<T>();

        node.Data = content;
        Length++;

        //If Head is null, that means that there are no nodes in the linked list
        if (Head == null)
        {
            Head = node;
            Head.Previous = null;
        }
        //At least 1 note in the list already
        else
        {
            //Take the Tail Node, which is the last one in the list, and set it's Next property which was null, to the new node we just created.
            Tail.Next = node;
            //Set the new Tail i.e node's previous to the old tail
            node.Previous = Tail;
        }

        Tail = node;
    }

    public void AddToFront(T content)
    {
        MyNode<T> oldFirst = Head;
        Head = new MyNode<T>();
        //Set the data on the node
        Head.Data = content;
        //Make Head's Next point to the old First
        Head.Next = oldFirst;
        //Set the old firsts previous to the new first
        oldFirst.Previous = Head;
        Length++;
    }

    public void AddToEnd(T data)
    {
        MyNode<T> temp = new MyNode<T>();
        temp.Data = data;

        MyNode<T> p = Head;
        while (p.Next != null)
            p = p.Next;

        p.Next = temp;
        temp.Previous = p;
        Length++;
    }

    public T Retrive(int position)
    {
        MyNode<T> tempNode = Head;

        MyNode<T> returnNode = null;

        int count = 0;

        while (tempNode != null)
        {
            //If the count and the position match. This means that it will be zero based. If we want it to be 1 based, we would need to subtract 1 from the position.
            if (count == position)
            {
                //Set the returnNode var to the tempNode, which is the one we were looking for
                returnNode = tempNode;
            }
            //logs another item
            count++;
            //moves us to the next item
            tempNode = tempNode.Next;
        }
        return (returnNode != null) ? returnNode.Data : default(T);
    }

    public bool Delete(int position)
    {
        bool returnBool = false;

        Current = Head;


        if (position == 0)
        {


            Head = Current.Next;

            Current.Next = null;

            //Set the current (which was the old Head) to null. Now that node no longer exists, and can be garbage collected
            Current = null;
            //Check to see if the Head is null, if so, the Tail must become null as well because it means we just deleted the last node in the list
            if (Head == null)
            {
                Tail = null;
            }

            returnBool = true;
        }
        else
        {
            MyNode<T> tempNode = Head;
            //Declare a previous temp that will get a value after the tempNode moves
            MyNode<T> previousTempNode = null;
            int count = 0;

            //Loop until the tmpNode is null, which means we are at the end
            while (tempNode != null)
            {
                //If we match the position and the count we are on, we find the one we need to delete

                if (count == position)
                {
                    //Set the previous nodes next to the tempNode's next jumping over the tempNode. The previous node's next will now point to the node AFTER the tempNode.
                    previousTempNode.Next = tempNode.Next;

                    //Check to see if we are deleting the very last node in the list if so we need to move the Tail pointer.
                    if (tempNode.Next == null)
                    {
                        //Set Tail to the previousTempNode, which is the new end of the list
                        Tail = previousTempNode;
                    }

                    returnBool = true;
                }

                count++;

                //Set the previous tempNode to the current tempNode. This way when we move the tempNode forward, we will still have a pointer to where 
                //the tempNode was before it moved.
                previousTempNode = tempNode;

                tempNode = tempNode.Next;
            }
        }

        return returnBool;
    }

    public void DeleteFirstNode()
    {
        // if list is empty
        if (Head == null)
            return;

        // if list has only one node
        if (Head.Next == null)
        {
            // delete node
            Head = null;
            return;
        }

        // delete first node
        Head = Head.Next;
        Head.Previous = null;
    }

    public void DeleteLastNode()
    {
        // list is empty
        if (Head == null)
            return;

        // if list has only one node
        if (Head.Next == null)
        {
            // delete node
            Head = null;
            return;
        }

        // find reference to the last node 
        MyNode<T> p = Head;
        while (p.Next != null)
            p = p.Next;
        // delete last node
        p.Previous.Next = null;
    }

    public void ReverseList()
    {
        if (Head == null)
            return;

        MyNode<T> p1 = Head;
        MyNode<T> p2 = p1.Next;
        p1.Next = null;
        p1.Previous = p2;
        while (p2 != null)
        {
            p2.Previous = p2.Next;
            p2.Next = p1;
            p1 = p2;
            p2 = p2.Previous;
        }
        Head = p1;
    }

    ////Old Methods No Longer In Use
    //public dialogueData FindNode(MyLinkedList<dialogueData> list, int LineID, string listnerID)
    //{
    //    MyNode<dialogueData> tempNode = list.Head;
    //    MyNode<dialogueData> returnNode = null;

    //    while (tempNode != null)
    //    {
    //        if (tempNode.Data.lineID == LineID && tempNode.Data.interactingID == listnerID)
    //        {
    //            returnNode = tempNode;
    //            break;
    //        }
    //        //all needed working must be done before tempNode = tempNode.Next
    //        //goes to next element
    //        tempNode = tempNode.Next;
    //    }

    //    return (returnNode != null) ? returnNode.Data : default(dialogueData);
    //}


    //public (string nickname, string line) FindLine(MyLinkedList<dialogueData> list, int LineID, string listnerID)
    //{
    //    MyNode<dialogueData> tempNode = list.Head;
    //    MyNode<dialogueData> returnNode = null;

    //    while (tempNode != null)
    //    {
    //        if (tempNode.Data.lineID == LineID && tempNode.Data.interactingID == listnerID)
    //        {
    //            returnNode = tempNode;
    //            break;
    //        }
    //        //all needed working must be done before tempNode = tempNode.Next
    //        //goes to next element
    //        tempNode = tempNode.Next;
    //    }

    //    return (returnNode.Data.characterNickname, returnNode.Data.characterLine);
    //}
}
