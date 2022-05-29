using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CharacterPoint
{
    [System.Serializable]
    public enum CHARACTER
    {
        GraveKeeper = 0,
        Winter = 1,
        Soldier = 2,
        Amara = 3
    }
    public CHARACTER character;
    public int amount;
}
[System.Serializable]
public class Choice 
{
    public string text;
    public List<CharacterPoint> characterPoints = new List<CharacterPoint>();
    public DialogObject nextDialog;
    public List<DialogTask> tasks = new List<DialogTask>();
    public Item requiredItem;
    public List<DialogObject> requiredDialogs;
}


[CreateAssetMenu(fileName = "New DialogOption", menuName = "Dialog/Dialog")]
public class DialogObject : ScriptableObject
{
    public string id = "";
    public DialogCharacter Speaker = null;
    [TextArea(3, 8)]
    public string dialogText = "Words, words, words.";
    public bool italic, bold = false;
    public List<Choice> choices = new List<Choice>();

    private void Awake()
    {
        if(id == "")
        {
            GenerateID();
        }
    }

    public void GenerateID()
    {
        id = new Guid().ToString();
    }
}

