using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogDatabase), true)]
public class DialogDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (DialogDatabase)target;

        if (GUILayout.Button("Refresh List", GUILayout.Height(30)))
        {
            //script.GenerateID();
            Undo.RecordObject(target, "Refreshed List");
            script.RefreshList();
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();

        }
    }
}
