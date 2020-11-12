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

    //#region CharacterNodes
    //MyNode<dialogueData> sFin = new MyNode<dialogueData>();
    //MyNode<dialogueData> bFin = new MyNode<dialogueData>();

    //MyNode<dialogueData> socialB = new MyNode<dialogueData>();
    //MyNode<dialogueData> sage = new MyNode<dialogueData>();

    //MyNode<dialogueData> Fin_SocialB = new MyNode<dialogueData>();
    //MyNode<dialogueData> Fin_Sage = new MyNode<dialogueData>();
    //#endregion

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

            //Fin_Sage = DialogueManager.Instance.Fin_SageList1.Head;
            ////Debug.Log(DialogueManager.Instance.Fin_SageList1.Head.Data.characterLine);
            //txtCharacterName.text = Fin_Sage.Data.characterNickname;
            //txtDisplay.text = Fin_Sage.Data.characterLine;            
        }
        else if (DialogueManager.Instance.currentInteraction == "b")
        {   //SocialBot Interaction
        //    Fin_SocialB = DialogueManager.Instance.Fin_BotList1.Head;
        //    //Futher Check To Determine starting character
        //    txtCharacterName.text = Fin_SocialB.Data.characterNickname;
        //    txtDisplay.text = Fin_SocialB.Data.characterLine;
        }

    }

    public void NextLine()
    {   //NOTE CURRENT ID WILL ALWAYS BE THE CURRENTLY DISPLAYING ID THIS MEANS IT NEEDS TO BE UPDATED ON CHANGE AND IF THE CURRENT ID IS SOCIAL BOT YOU WILL NEED TO LOAD FIND DIALOGUE
        if (interactingID == "s")
        {   //Sage2000 Interaction

            //if (Fin_Sage.Next != null)
            //{
            //    Fin_Sage = Fin_Sage.Next;
            //    txtCharacterName.text = Fin_Sage.Data.characterNickname;
            //    txtDisplay.text = Fin_Sage.Data.characterLine;
            //}
            //else
            //{
            //    EndDialogue();
            //}

        }
        else if (interactingID == "b")
        {   //SocialBot Interaction
            //if (Fin_SocialB.Next != null)
            //{
            //    Fin_SocialB = Fin_SocialB.Next;
            //    txtCharacterName.text = Fin_SocialB.Data.characterNickname;
            //    txtDisplay.text = Fin_SocialB.Data.characterLine;
            //}
            //else
            //{
            //    EndDialogue();
            //}
        }
    }

    public void PreviousLine()
    {
        //NOTE CURRENT ID WILL ALWAYS BE THE CURRENTLY DISPLAYING ID THIS MEANS IT NEEDS TO BE UPDATED ON CHANGE AND IF THE CURRENT ID IS SOCIAL BOT YOU WILL NEED TO LOAD FIND DIALOGUE
        if (interactingID == "s")
        {   //Sage2000 Interaction

        //    if(Fin_Sage.Previous != null)
        //    {
        //        Fin_Sage = Fin_Sage.Previous;
        //        txtCharacterName.text = Fin_Sage.Data.characterNickname;
        //        txtDisplay.text = Fin_Sage.Data.characterLine;
        //    }          
        //}
        //else if (DialogueManager.Instance.currentInteraction == "b")
        //{   //SocialBot Interaction
        //    if (Fin_SocialB.Previous != null)
        //    {
        //        Fin_SocialB = Fin_SocialB.Previous;
        //        txtCharacterName.text = Fin_SocialB.Data.characterNickname;
        //        txtDisplay.text = Fin_SocialB.Data.characterLine;
        //    }
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
       
    public void SetText(string characterName, string characterLine)
    {
        txtCharacterName.text = characterName;
        txtDisplay.text = characterLine;
    }
    
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
