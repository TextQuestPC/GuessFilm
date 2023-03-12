using System;

namespace SaveSystem
{
    [Serializable]
    public class SaveData
    {
        public SavePartData[] PartsData;
        public int Points = 0;
        public bool FirstStart = false;
    }
}