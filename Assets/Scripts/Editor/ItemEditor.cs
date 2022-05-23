using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item), true)]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (Item)target;

        if (GUILayout.Button("Generate ID", GUILayout.Height(30)))
        {
            //script.GenerateID();
            Undo.RecordObject(target, "Changed ID");
            script.GenerateID();
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();

        }
    }


}
