using Save;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        public SaveMainData MainData;
        public SavePartData[] PartsData;
    }
}
