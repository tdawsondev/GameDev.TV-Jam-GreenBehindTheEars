using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Dialog/Character")]
public class DialogCharacter : ScriptableObject
{
    public string characterName;
    public Sprite characterImage;
}
