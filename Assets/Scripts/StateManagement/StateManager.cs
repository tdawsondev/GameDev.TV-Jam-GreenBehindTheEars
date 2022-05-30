using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region Singleton

    public static StateManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one StateManager Object");
        }
        instance = this;
    }
    #endregion

    public List<DialogObject> completedDialogs = new List<DialogObject>();
    public DialogDatabase database;

    public bool HasCompletedDialog(DialogObject dObj)
    {
        return completedDialogs.Contains(dObj);
    }

    public void AddCompletedDialog(DialogObject dObj)
    {
        if (!HasCompletedDialog(dObj))
        {
            completedDialogs.Add(dObj);
        }
    }

    public void SaveCompletedDialogs()
    {
        Debug.Log("Saving Dialog");
        string saveData = "";
        foreach (DialogObject dObj in completedDialogs)
        {
            saveData = saveData + dObj.id + '\n';
        }
        SaveSystem.TempSave(saveData, "dialogTempSave");
    }
    public void LoadCompletedDialogs()
    {
        if (database == null)
            return;
        completedDialogs = new List<DialogObject>();
        string saveData = SaveSystem.LoadTemp("dialogTempSave");
        if (saveData != null && saveData != "")
        {
            foreach (var str in saveData.Split('\n'))
            {
                if (str != "")
                {
                    DialogObject item = database.GetObjectById(str);
                    if (item != null)
                    {
                        completedDialogs.Add(item);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        LoadCompletedDialogs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
