
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        // Ваши сохранения
        public int points = 0;
        public bool[] openParts = new bool[3];
        public bool FirstStart = false;
    }
}
