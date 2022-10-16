using UnityEngine;
using YG;

namespace Core
{
    [CreateAssetMenu(fileName = "SaveLoadManager", menuName = "Managers/SaveLoadManager")]
    public class SaveLoadManager : BaseManager
    {
        private int points;
        private bool[] openParts;

        public int GetPoints { get => points; }
        public bool[] GetOpenParts { get => openParts; }

        public void LoadData()
        {
            points = YandexGame.savesData.points;
            openParts = YandexGame.savesData.openParts;
        }

        public void SaveData(int points, bool[] openParts)
        {
            YandexGame.savesData.points = points;
            YandexGame.savesData.openParts = openParts;

            YandexGame.SaveProgress();
        }
    }
}