using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FileNames
{
    FinThePhone_Sage2000Dialogue,
    FinThePhone_SocialBotDialogue    
};
public enum CharacterIDs
{
    //Sage2000
    s,
    //FinThePhone
    f,
    //SocialBot
    b
}
public class DialogueManager : MonoBehaviour
{
    #region Singleton Setup
    private static DialogueManager instance;

    public static DialogueManager Instance
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
    public DataManager dataManager;
    //public playerData playerData;

    public MyLinkedList<dialogueData> Sage2000List = new MyLinkedList<dialogueData>();
    public MyLinkedList<dialogueData> FinThePhoneList = new MyLinkedList<dialogueData>();
    public MyLinkedList<dialogueData> SocialBotList = new MyLinkedList<dialogueData>();

    public MyLinkedList<dialogueData> Fin_SageList1 = new MyLinkedList<dialogueData>();
    public MyLinkedList<dialogueData> Fin_BotList1 = new MyLinkedList<dialogueData>();

    public string currentInteraction;

    public bool clicked = false;
    public int playerChoice = -1;
    public bool playerChosen = false;
    public string fileExtention = ".json";
    public void ReadDataOutOfArray(dialogueData[] dialogues, string dialogueSequence)
    {
        //Debug.Log("I");
        foreach (dialogueData d in dialogues)
        {
           if(dialogueSequence == "fs1")
            {
                Fin_SageList1.Add(d);
                //Debug.Log(d.characterNickname + ": " + d.characterLine);
            }
           else if (dialogueSequence == "fb1")
            {
                Fin_BotList1.Add(d);
                //Debug.Log(d.characterNickname + ": " + d.characterLine);
            }
        }

    }

    public void LoadAllLists()
    {
        //Load Sage2000 json
        dataManager.file = FileNames.FinThePhone_Sage2000Dialogue + DialogueManager.Instance.fileExtention;
        //Debug.Log(dataManager.file);
        dataManager.LoadFS();
        //Debug.Log(DialogueManager.Instance.Fin_SageList1.Head.Data.characterLine);
        //Load FinThePhone json
        dataManager.file = FileNames.FinThePhone_SocialBotDialogue + DialogueManager.Instance.fileExtention;
        dataManager.LoadFB();
        //Debug.Log(DialogueManager.Instance.Fin_BotList1.Head.Data.characterLine);
        //Load SocialBot json
        //dataManager.file = FileNames.socialBot + DialogueManager.Instance.fileExtention;
        //dataManager.Load(CharacterIDs.b.ToString());

    }
}


