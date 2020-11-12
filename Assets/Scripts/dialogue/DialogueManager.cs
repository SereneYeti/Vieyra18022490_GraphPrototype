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

    //public MyLinkedList<dialogueData> Sage2000List = new MyLinkedList<dialogueData>();
    //public MyLinkedList<dialogueData> FinThePhoneList = new MyLinkedList<dialogueData>();
    //public MyLinkedList<dialogueData> SocialBotList = new MyLinkedList<dialogueData>();

    //public MyLinkedList<dialogueData> Fin_SageList1 = new MyLinkedList<dialogueData>();
    //public MyLinkedList<dialogueData> Fin_BotList1 = new MyLinkedList<dialogueData>();    

    public string currentInteraction;

    public bool clicked = false;
    public int playerChoice = -1;
    public bool playerChosen = false;
    public string fileExtention = ".json";
    public void ReadDataOutOfArray(dialogueData[] dialogues, string dialogueSequence)
    {
        //Debug.Log("I");
        //for(int i = 0; i < dialogues.Length; i++)
        //{
        //    string lbl = dialogues[i].characterID + "_" + dialogues[i].lineID;
        //    graphFin_Sage.AddVertex(lbl, dialogues[i]);
           
        //    //Debug.Log("test");
        //    for (int j = 0; i <= 20; i++)
        //    {
        //        //Debug.Log(graphFin_Sage.ReturnVertex(j));
        //       // Debug.Log(graphFin_Sage.DisplayVertexData(j));

        //    }
        //}

        foreach (dialogueData d in dialogues)
        {
            if (dialogueSequence == "sf_1")
            {
                //Fin_SageList1.Add(d);
                string lbl = d.characterID + "_" + d.lineID;
                int cnt = 0;
                //GraphManager.Instance.graphFin_Sage.AddVertex(lbl);
                //Debug.Log("GRAPH_LABEL: " + GraphManager.Instance.graphFin_Sage.ReturnVertex(cnt));
                //Debug.Log("GRAPH:" + GraphManager.Instance.graphFin_Sage.DisplayVertexData(cnt));
                cnt++;
                Debug.Log("Other:" + d);
                Debug.Log("Other:" + lbl);
                //Debug.Log(d.characterNickname + ": " + d.characterLine);
            }
            else if (dialogueSequence == "fb1")
            {
                //Fin_BotList1.Add(d);
                //Debug.Log(d.characterNickname + ": " + d.characterLine);
            }
        }

    }

    public void ReturnDataFromArray(dialogueData[] dialogues, string dialogueSequence, Graph graph)
    {      
        foreach (dialogueData d in dialogues)
        {
            if (dialogueSequence == "sf_1")
            {
                //Fin_SageList1.Add(d);
                //Debug.Log(d.characterNickname + ": " + d.characterLine);
                graph.AddVertex(d);
                //graphFin_Sage.AddVertex(lbl, d);
               
                
            }
            else if (dialogueSequence == "fb1")
            {
                graph.AddVertex(d);
                //Fin_BotList1.Add(d);
                //Debug.Log(d.characterNickname + ": " + d.characterLine);
            }            
        }        
    }

    public void SetSageFile()
    {
        dataManager.file = FileNames.FinThePhone_Sage2000Dialogue + fileExtention;
        //Debug.Log(dataManager.file);
        
    }

    public void SetSocialFile()
    {
        dataManager.file = FileNames.FinThePhone_SocialBotDialogue + fileExtention;
        
    }

    public void LoadGraphs()
    {
        //Load Sage2000 json
        dataManager.LoadFS();

        //Debug.Log(GraphManager.Instance.graphFin_Sage.ReturnVertex(0));
       
        //Load SocialBot json
        dataManager.LoadFB();        
    }
}


