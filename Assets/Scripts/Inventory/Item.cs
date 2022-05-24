using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    [TextArea(3, 8)]
    public string description = "Item Description...";
    public Sprite icon = null;
    public string ID;
    public GameObject prefab;

    public static string currentID = "000000";

    private void Awake()
    {
        GenerateID();
    }


    //Generates and ID and saves it to a file so we can make sure generated IDs dont overlap
    public void GenerateID()
    {
        string path = "Assets/Scripts/Inventory/currentItemID.txt";
        StreamReader streamReader = new StreamReader(path);
        currentID = streamReader.ReadToEnd();
        streamReader.Close();

        ID = currentID.TrimEnd('\r', '\n');

        int count = int.Parse(currentID);
        count++;
        string temp = "" + count;
        while (temp.Length < 6)
        {
            temp = "0" + temp;
        }
        currentID = temp;
       
        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(currentID);
        writer.Close();
    }

}
