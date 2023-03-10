using System.IO;
using Data;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace EditorTools
{
    public class MenuTools
    {
        private const string SAVE_NAME = "Save.json";
        [MenuItem("Tools/Delete Save")]
        private static void DeleteSave()
        {
            if (File.Exists(Application.persistentDataPath + SAVE_NAME))
            {
                File.Delete(Application.persistentDataPath + SAVE_NAME);
            }

            if (File.Exists(Application.persistentDataPath + SAVE_NAME))
            {
                File.Delete(Application.persistentDataPath + SAVE_NAME);
            }
        }
    }
}

#endif