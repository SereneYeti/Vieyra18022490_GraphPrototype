using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class DialogueController : MonoBehaviour
{
    #region DisplayObjects
    Image pnlDisplayMaterial;
    public GameObject pnlDisplay;
    public GameObject pnlCharacterName;
    public TextMeshProUGUI txtDisplay;
    public TextMeshProUGUI txtCharacterName;
    public Button btnNext;
    public Button btnPrevious;
    public Button btnCloseChat;
    public TextMeshProUGUI txtNext;
    public TextMeshProUGUI txtPrevious;
    #endregion

    #region CharacterNodes
    MyNode<dialogueData> sFin = new MyNode<dialogueData>();
    MyNode<dialogueData> bFin = new MyNode<dialogueData>();

    MyNode<dialogueData> socialB = new MyNode<dialogueData>();
    MyNode<dialogueData> sage = new MyNode<dialogueData>();

    MyNode<dialogueData> Fin_SocialB = new MyNode<dialogueData>();
    MyNode<dialogueData> Fin_Sage = new MyNode<dialogueData>();
    #endregion

    public string interactingID;
    private string currentID;
    //int countSage;
    //int countSocial;
    public int countFin;
    //int speaker;
    public bool ReadLine = false;
    private void Start()
    {
        //countSage = 0;
        //countFin = 0;
        //countSocial = 0;
        //speaker = -1;
        interactingID = "";

        DialogueManager.Instance.LoadAllLists();

        //Debug.Log(DialogueManager.Instance.SocialBotList.Head.Data.characterNickname);
        pnlDisplayMaterial = pnlDisplay.GetComponent<Image>();
        EventManager.Instance.AddListener(EVENT_TYPE.NPC_Click, EnterDialogue);
    }

    public void EnterDialogue(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        

        #region Set GameObjects Active
            pnlDisplay.SetActive(true);
            pnlCharacterName.SetActive(true);
            txtDisplay.gameObject.SetActive(true);
            txtCharacterName.gameObject.SetActive(true);
            btnNext.gameObject.SetActive(true);
            btnPrevious.gameObject.SetActive(true);
            txtNext.gameObject.SetActive(true);
            txtPrevious.gameObject.SetActive(true);
            btnCloseChat.gameObject.SetActive(true);
        #endregion
        //Dialogue Handled Beneath       
        if (interactingID == "s")
        {   //Sage2000 Interaction

            Fin_Sage = DialogueManager.Instance.Fin_SageList1.Head;
            //Debug.Log(DialogueManager.Instance.Fin_SageList1.Head.Data.characterLine);
            txtCharacterName.text = Fin_Sage.Data.characterNickname;
            txtDisplay.text = Fin_Sage.Data.characterLine;            
        }
        else if (DialogueManager.Instance.currentInteraction == "b")
        {   //SocialBot Interaction
            Fin_SocialB = DialogueManager.Instance.Fin_BotList1.Head;
            //Futher Check To Determine starting character
            txtCharacterName.text = Fin_SocialB.Data.characterNickname;
            txtDisplay.text = Fin_SocialB.Data.characterLine;
        }

    }

    public void NextLine()
    {   //NOTE CURRENT ID WILL ALWAYS BE THE CURRENTLY DISPLAYING ID THIS MEANS IT NEEDS TO BE UPDATED ON CHANGE AND IF THE CURRENT ID IS SOCIAL BOT YOU WILL NEED TO LOAD FIND DIALOGUE
        if (interactingID == "s")
        {   //Sage2000 Interaction

            if (Fin_Sage.Next != null)
            {
                Fin_Sage = Fin_Sage.Next;
                txtCharacterName.text = Fin_Sage.Data.characterNickname;
                txtDisplay.text = Fin_Sage.Data.characterLine;
            }
            else
            {
                EndDialogue();
            }

        }
        else if (interactingID == "b")
        {   //SocialBot Interaction
            if (Fin_SocialB.Next != null)
            {
                Fin_SocialB = Fin_SocialB.Next;
                txtCharacterName.text = Fin_SocialB.Data.characterNickname;
                txtDisplay.text = Fin_SocialB.Data.characterLine;
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void PreviousLine()
    {
        //NOTE CURRENT ID WILL ALWAYS BE THE CURRENTLY DISPLAYING ID THIS MEANS IT NEEDS TO BE UPDATED ON CHANGE AND IF THE CURRENT ID IS SOCIAL BOT YOU WILL NEED TO LOAD FIND DIALOGUE
        if (interactingID == "s")
        {   //Sage2000 Interaction

            if(Fin_Sage.Previous != null)
            {
                Fin_Sage = Fin_Sage.Previous;
                txtCharacterName.text = Fin_Sage.Data.characterNickname;
                txtDisplay.text = Fin_Sage.Data.characterLine;
            }          
        }
        else if (DialogueManager.Instance.currentInteraction == "b")
        {   //SocialBot Interaction
            if (Fin_SocialB.Previous != null)
            {
                Fin_SocialB = Fin_SocialB.Previous;
                txtCharacterName.text = Fin_SocialB.Data.characterNickname;
                txtDisplay.text = Fin_SocialB.Data.characterLine;
            }
        }
    }

    public void EndDialogue()
    {
        DialogueManager.Instance.clicked = false;
        #region Set GameObjects Active - False
        pnlDisplay.SetActive(false);
        pnlCharacterName.SetActive(false);
        txtDisplay.gameObject.SetActive(false);
        txtCharacterName.gameObject.SetActive(false);
        btnNext.gameObject.SetActive(false);
        btnPrevious.gameObject.SetActive(false);
        txtNext.gameObject.SetActive(false);
        txtPrevious.gameObject.SetActive(false);
        btnCloseChat.gameObject.SetActive(false);
        #endregion
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    //public void NextDialogue(int lineID, int[] posResponeses)
    //{
    //    tempData = DialogueManager.Instance.Sage2000List.Retrive(posResponeses[DialogueManager.Instance.playerChoice]);
    //    lineID = tempData.lineID;
    //    response = DialogueManager.Instance.FinThePhoneList.FindNode(DialogueManager.Instance.FinThePhoneList, lineID,interactingID);
    //    ReadLine = false;
    //}

    //public void DoDialogue()
    //{
    //    #region FromTestProgram
    //    dialogueData tempData = new dialogueData();
    //    bool finished = false;
    //    if(DialogueManager.Instance.currentInteraction == "s")
    //    {
    //        //The speaker variable will be used to determine & switch the speaker. 0 = SAGE & 1 = FIN          
    //        if (speaker == -1)
    //        {
    //            speaker = 0;
    //            if (countSage == DialogueManager.Instance.Sage2000List.Length) { Debug.Log("this2"); finished = true; speaker = -2; }
    //        }
    //        else if (speaker == 0 && !finished)
    //        {
    //            pnlDisplayMaterial.color = Color.yellow;
    //            tempData = DialogueManager.Instance.Sage2000List.Retrive(countSage);
    //            SetText(tempData.characterNickname, tempData.characterLine);
    //            NextLine();
    //            if (ReadLine) { speaker = 1; ReadLine = false; countSage++; }
    //        }
    //        else if (speaker == 1 && !finished)
    //        {
    //            pnlDisplayMaterial.color = Color.green;
    //            tempData = DialogueManager.Instance.FinThePhoneList.Retrive(countFin);
    //            SetText(tempData.characterNickname, tempData.characterLine);
    //            NextLine();
    //            if (ReadLine) { speaker = -1; ReadLine = false; countFin++; }
    //        }
    //        if (speaker == -2 && finished == true)
    //        {
    //            countFin = 0;
    //            countSage = 0;
    //            speaker = 0;
    //            Debug.Log("here");
    //            pnlDisplay.SetActive(false);
    //            pnlCharacterName.SetActive(false);
    //            txtDisplay.gameObject.SetActive(false);
    //            txtCharacterName.gameObject.SetActive(false);
    //            DialogueManager.Instance.clicked = false;
    //        }
    //    }
    //    else if (DialogueManager.Instance.currentInteraction == "b")
    //    {
    //        //Debug.Log(countFin);
    //        //The speaker variable will be used to determine & switch the speaker. 0 = SocialBot & 1 = FIN          
    //        if (speaker == -1)
    //        {
    //            speaker = 0;
    //            //Debug.Log(countSocial);
    //            //Debug.Log(DialogueManager.Instance.SocialBotList.Length);
    //            if (countSocial == DialogueManager.Instance.SocialBotList.Length-1) { Debug.Log("this2"); finished = true; speaker = -2; }
    //        }
    //        else if (speaker == 0 && !finished)
    //        {
    //            pnlDisplayMaterial.color = Color.red;
    //            tempData = DialogueManager.Instance.SocialBotList.Retrive(countSocial);
    //            SetText(tempData.characterNickname, tempData.characterLine);
    //            NextLine();
    //            if (ReadLine) { speaker = 1; ReadLine = false; countSocial++; }
    //        }
    //        else if (speaker == 1 && !finished)
    //        {
    //            pnlDisplayMaterial.color = Color.green;
    //            tempData = DialogueManager.Instance.FinThePhoneList.Retrive(countFin);
    //            SetText(tempData.characterNickname, tempData.characterLine);
    //            NextLine();
    //            if (ReadLine) { speaker = -1; ReadLine = false; countFin++; }
    //        }
    //        if (speaker == -2 && finished == true)
    //        {
    //            countFin = 0;
    //            countSage = 0;
    //            countSocial = 0;
    //            speaker = 0;
    //            Debug.Log("here");
    //            pnlDisplay.SetActive(false);
    //            pnlCharacterName.SetActive(false);
    //            txtDisplay.gameObject.SetActive(false);
    //            txtCharacterName.gameObject.SetActive(false);
    //            DialogueManager.Instance.clicked = false;
    //        }
    //    }
    //    #endregion

    //     #region working on implementing dialogue using all the fields available       

    //        //interactingID = DialogueManager.Instance.currentInteraction;

    //        //if(interactingID == "s")
    //        //{
    //        //    if(tempData.lineID == 0)
    //        //    {
    //        //        tempData = DialogueManager.Instance.Sage2000List.Retrive(_lineID);
    //        //        _lineID = tempData.lineID;
    //        //        response = DialogueManager.Instance.FinThePhoneList.FindNode(DialogueManager.Instance.FinThePhoneList, _lineID, interactingID);
    //        //        SetText(tempData.characterNickname, tempData.characterLine);
    //        //        ChangeBtnVis(2, true);
    //        //        (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, _lineID, interactingID);
    //        //        (txtCharacterName.text, txtOption3.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, -1, interactingID);
    //        //        int[] tempPosChoice = tempData.possibleResponses;
    //        //        tempData = DialogueManager.Instance.Sage2000List.FindNode(DialogueManager.Instance.Sage2000List, response.possibleResponses[DialogueManager.Instance.playerChoice], interactingID);
    //        //        response = DialogueManager.Instance.FinThePhoneList.FindNode(DialogueManager.Instance.FinThePhoneList, tempPosChoice[DialogueManager.Instance.playerChoice], interactingID);
    //        //    }
    //        //    else
    //        //    {
    //        //        if(!ReadLine)
    //        //        {
    //        //            SetText(tempData.characterNickname, tempData.characterLine);
    //        //            ChangeBtnVis(tempData.possibleResponses.Length, true);
    //        //            if (tempData.possibleResponses.Length == 1)
    //        //            {
    //        //                (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[0], interactingID);
    //        //                //lineID++;

    //        //            }
    //        //            else if (tempData.possibleResponses.Length == 2)
    //        //            {
    //        //                (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[0], interactingID);
    //        //                (txtCharacterName.text, txtOption3.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[1], interactingID);
    //        //                //lineID++;
    //        //            }
    //        //            else if (tempData.possibleResponses.Length == 3)
    //        //            {
    //        //                (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[0], interactingID);
    //        //                (txtCharacterName.text, txtOption2.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[2], interactingID);
    //        //                (txtCharacterName.text, txtOption3.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[1], interactingID);
    //        //                //lineID++;
    //        //            }

    //        //            if (Input.GetKeyDown(KeyCode.Mouse0))
    //        //            {
    //        //                NextLine();
    //        //            }

    //        //            if (ReadLine == true)
    //        //            {
    //        //                //txtOption1.text = "";
    //        //                //txtOption2.text = "";
    //        //                //txtOption3.text = "";
    //        //                //Debug.Log(tempData.possibleResponses[0]);
    //        //                //StartCoroutine(waiter());
    //        //                NextDialogue(_lineID, tempData.possibleResponses);
    //        //            }
    //        //        }

    //        //    }
    //        //}
    //        //else if (interactingID == "b")
    //        //{
    //        //    if (tempData == null)
    //        //    {
    //        //        tempData = DialogueManager.Instance.SocialBotList.Retrive(_lineID);
    //        //        _lineID = tempData.lineID;
    //        //    }


    //        //}

    //        #endregion
    //}

    //public void BeginDiaglogue()
    //{

    //}

    public void SetText(string characterName, string characterLine)
    {
        txtCharacterName.text = characterName;
        txtDisplay.text = characterLine;
    }

    //public void NextLine()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        //Debug.Log("hi");
    //        //if (speaker == 0) speaker = 1; else speaker = 0;
    //        if (ReadLine) { ReadLine = false; }
    //        else if (!ReadLine) { ReadLine = true; ; }
           
    //    }
    //}
    // Update is called once per frame

    void Update()
    {
        if (DialogueManager.Instance.clicked)
        {
            #region Set GameObjects Active
            pnlDisplay.SetActive(true);
            pnlCharacterName.SetActive(true);
            txtDisplay.gameObject.SetActive(true);
            txtCharacterName.gameObject.SetActive(true);
            btnNext.gameObject.SetActive(true);
            btnPrevious.gameObject.SetActive(true);
            txtNext.gameObject.SetActive(true);
            txtPrevious.gameObject.SetActive(true);
            btnCloseChat.gameObject.SetActive(true);
            #endregion

        }
        else if (!DialogueManager.Instance.clicked)
        {
            #region Set GameObjects False
            pnlDisplay.SetActive(false);
            pnlCharacterName.SetActive(false);
            txtDisplay.gameObject.SetActive(false);
            txtCharacterName.gameObject.SetActive(false);
            btnNext.gameObject.SetActive(false);
            btnPrevious.gameObject.SetActive(false);
            txtNext.gameObject.SetActive(false);
            txtPrevious.gameObject.SetActive(false);
            btnCloseChat.gameObject.SetActive(false);
            #endregion

        }
    }
}
