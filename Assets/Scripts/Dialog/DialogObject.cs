using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPoint
{
    [System.Serializable]
    public enum CHARACTER_POINTS
    {
        GraveKeeper = 0,
        Winter = 1,
        Soldier = 2,
        Amara = 3
    }
    public CHARACTER_POINTS character;
    public int amount;
}
[System.Serializable]
public class Choice 
{
    public string text;
    public List<CharacterPoint> characterPoints = new List<CharacterPoint>();
    public DialogObject nextDialog;
}


[CreateAssetMenu(fileName = "New DialogOption", menuName = "Dialog/Dialog")]
public class DialogObject : ScriptableObject
{
    public string Speaker = "Name";
    [TextArea(3, 8)]
    public string dialogText = "Words, words, words.";
    public List<Choice> choices = new List<Choice>();
    
}
