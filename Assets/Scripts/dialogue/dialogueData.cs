using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class dialogueData 
{
    public dialogueData()
    { }

    public string characterID;

    public string startCharacterID;

    public string characterNickname;

    public string dialogueSequence;    

    public string reqInv;

    public int lineID;   

    public int numRespones;

    public int endTalkPos;    

    public string characterLine;

    public int[] possibleResponses;
   
    public override string ToString()
    {
        return characterNickname + ": " + characterLine;
    }
}

public class fs_DialogueALines : dialogueData
{   //class used to read out the individual json dialogue data classes from the base json array used to store them
    public dialogueData[] fsDialogueALines;
}

public class fb_DialogueALines : dialogueData
{   //class used to read out the individual json dialogue data classes from the base json array used to store them
    public dialogueData[] fbDialogueALines;
}
