using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private static readonly string TEMP_SAVE_FOLDER = Application.dataPath + "/TempSaves/";


    public static void Init()
    {
        //Make sure directories exist
        if (!Directory.Exists(SAVE_FOLDER))
            Directory.CreateDirectory(SAVE_FOLDER);

        if (!Directory.Exists(TEMP_SAVE_FOLDER))
            Directory.CreateDirectory(TEMP_SAVE_FOLDER);
    }

    public static void Save(string saveString, string saveFileName)
    {
        File.WriteAllText(SAVE_FOLDER + saveFileName + ".txt", saveString);
    }

    public static void TempSave(string saveString, string saveFileName)
    {
        File.WriteAllText(TEMP_SAVE_FOLDER + saveFileName + ".txt", saveString);
    }

    public static string Load(string saveFileName)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.txt");

        if (File.Exists(SAVE_FOLDER + saveFileName + ".txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + saveFileName + ".txt");
            return saveString;
        }
        else
        {
            Debug.Log($"No save file found.");
            return null;
        }

    }

    public static string LoadTemp(string saveFileName)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(TEMP_SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.txt");

        if (File.Exists(TEMP_SAVE_FOLDER + saveFileName + ".txt"))
        {
            string saveString = File.ReadAllText(TEMP_SAVE_FOLDER + saveFileName + ".txt");
            return saveString;
        }
        else
        {
            Debug.Log($"No save file found.");
            return null;
        }

    }

    /// <summary>
    /// Deletes all files in the Temp save folder. This function should be called in the main menu to ensure temp data wont carry into the game.\
    /// Should also be called on application quit or return to main menu.
    /// </summary>
    public static void DeleteAllTemps()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(TEMP_SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles();
        foreach(FileInfo file in saveFiles)
        {
            file.Delete();
        }
    }

}
