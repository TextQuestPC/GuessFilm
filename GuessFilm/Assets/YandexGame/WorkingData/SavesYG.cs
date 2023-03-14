using SaveSystem;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        public SaveData SaveData;

        public SavesYG()
        {
            SaveData = new SaveData();
        }
    }
}
