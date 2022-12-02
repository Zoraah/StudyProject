using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathProvider
{
    private const string FOLDER_NAME = "Bundles";

    public static string ContentStoragePath => 
        GetPath();

    public static string GetPath()
    {
        #if UNITY_ANDROID
            return Path.Combine(GetAndroidInternalFilesDir(), FOLDER_NAME);
        #elif UNITY_STANDALONE_WIN
            return FOLDER_NAME;
        #endif
    }

    public static string GetAndroidInternalFilesDir()
    {
        string[] potentialDirectories = new string[]
        {
            "/mnt/sdcard",
            "/sdcard/",
            "/storage/emulated/0",
            "/storage/sdcard0",
            "/storage/sdcard1"
        };

        if(Application.platform == RuntimePlatform.Android)
        {
            for(int i = 0; i < potentialDirectories.Length; i++)
            {
                if(Directory.Exists(potentialDirectories[i]))
                {
                    return potentialDirectories[i];
                }
            }
        }
        
        return "";
    }
}
