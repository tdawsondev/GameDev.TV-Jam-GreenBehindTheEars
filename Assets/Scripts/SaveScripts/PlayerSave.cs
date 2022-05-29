using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    private Player player;
    private const string saveString_PlayerPosition = "/playerPosition";

    [SerializeField] private const float dockPositionX = -42.75f;
    [SerializeField] private const float dockPositionY = 0f;
    [SerializeField] private const float dockPositionZ = -7f;

    private Vector3 dockPosition = new Vector3(dockPositionX, dockPositionY, dockPositionZ);

    private void Start()
    {
        player = Player.instance;
    }

    private class SaveData
    {
        public Vector3 playerPosition = new Vector3();
    }

    private SaveData GetSaveData()
    {
        SaveData saveData = new SaveData();

        if(player == null) { return saveData; }

        saveData.playerPosition = player.transform.position;

        return saveData;
    }

    public void OnSave()
    {
        SavePlayerPositionTemp();
    }

    private void SavePlayerPositionTemp()
    {
        SaveData saveData = new SaveData();
        saveData = GetSaveData();

        string json = JsonUtility.ToJson(saveData);
        SaveSystem.TempSave(json, saveString_PlayerPosition);

    }

    public Vector3 GetPlayerLastPosition()
    {
        SaveData loadedData = new SaveData();

        loadedData = GetPlayerPositionTemp();

        return loadedData.playerPosition;
    }

    private SaveData GetPlayerPositionTemp()
    {
        SaveData loadedData = new SaveData();

        string loadedString = SaveSystem.LoadTemp(saveString_PlayerPosition);

        if (loadedString != null)
            loadedData = JsonUtility.FromJson<SaveData>(loadedString);
        else
        {
            loadedData.playerPosition = dockPosition;
            Debug.Log($"No save file, default to dock.");
        }

        return loadedData;
    }



}
