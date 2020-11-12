using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    public dialogueData DialogueData = new dialogueData();

    #region arrayClasses
    public fs_DialogueALines fsdialogueA = new fs_DialogueALines();
    public fb_DialogueALines fbdialogueA = new fb_DialogueALines();
    #endregion

    public string file
    {
            get { return _file; }
            set { _file = value; }
        
    }
    private string _file = "sage2000.json";
    public void Save()
    {
        string json = JsonUtility.ToJson(DialogueData);
        WriteToFile(_file, json);
    }

    public void LoadFS()
    {
        DialogueManager.Instance.SetSageFile();
        string json = ReadFromFile(file);

        fsdialogueA = JsonUtility.FromJson<fs_DialogueALines>(json);
        //DialogueManager.Instance.ReadDataOutOfArray(fsdialogueA.fsDialogueALines, fsdialogueA.fsDialogueALines[0].dialogueSequence);
        //ABOVE: Read DATA all in DialogueManager (COMMENTED OUT)
        //BELLOW: Read Data into GraphManager
        DialogueManager.Instance.ReturnDataFromArray(fsdialogueA.fsDialogueALines,
            fsdialogueA.fsDialogueALines[0].dialogueSequence,GraphManager.Instance.graphFin_Sage);       

        //Debug.Log(tempLbl + "_" + tempData.ToString());
        //GraphManager.Instance.graphFin_Sage.AddVertex(tempLbl);

    }

    public void LoadFB()
    {
        DialogueManager.Instance.SetSocialFile();
        string json = ReadFromFile(file);
        //Debug.Log(json);

        fbdialogueA = JsonUtility.FromJson<fb_DialogueALines>(json);
        //Debug.Log(fbdialogueA.fbDialogueALines[0].dialogueSequence);
        //DialogueManager.Instance.ReadDataOutOfArray(fbdialogueA.fbDialogueALines, fbdialogueA.fbDialogueALines[0].dialogueSequence);
        //ABOVE: Read DATA all in DialogueManager (COMMENTED OUT)
        //BELLOW: Read Data into GraphManager
        DialogueManager.Instance.ReturnDataFromArray(fbdialogueA.fbDialogueALines,
             fbdialogueA.fbDialogueALines[0].dialogueSequence, GraphManager.Instance.graphFin_Social);

        //GraphManager.Instance.graphFin_Social.AddVertex(tempLbl);

    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);

        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

        using(StreamWriter streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(json);
        }
    }

    private string ReadFromFile(string fileName) 
    {
        string path = GetFilePath(fileName);
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {               
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found");

            return "";
        }
    }

    private string GetFilePath(string FileName)
    {
        return Path.Combine(Application.dataPath,"Files/Dialog", FileName);
    }    
}
