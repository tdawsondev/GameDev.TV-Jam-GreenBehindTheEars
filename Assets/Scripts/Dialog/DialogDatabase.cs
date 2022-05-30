using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogDatabase", menuName = "Dialog/Database")]
public class DialogDatabase : ScriptableObject
{

    public List<DialogObject> dialogObjects = new List<DialogObject>();
    public void Awake()
    {
      RefreshList();
    }
    public DialogObject GetObjectById(string id)
    {
        foreach(DialogObject obj in dialogObjects)
        {
            if(obj.id == id)
                return obj;
        }
        return null;
    }
    public void RefreshList()
    {
        dialogObjects = new List<DialogObject>(GetAllInstances<DialogObject>());
        foreach(DialogObject obj in dialogObjects)
        {
            obj.GenerateID();
        }
    }

    public static T[] GetAllInstances<T>() where T: ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;
    }
}
