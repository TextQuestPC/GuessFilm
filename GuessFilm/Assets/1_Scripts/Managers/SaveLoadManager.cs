using Data;
using Save;
using UnityEngine;
using YG;

namespace Core
{
    [CreateAssetMenu(fileName = "SaveLoadManager", menuName = "Managers/SaveLoadManager")]
    public class SaveLoadManager : BaseManager
    {
        private int points;
        private bool firstStart = false;
        private SavePartData[] partsData;

        public int GetPoints { get => points; }
        public bool GetFirstStart { get => firstStart; }
        public SavePartData[] GetPartsData { get => partsData; }

        public void LoadData()
        {
            points = YandexGame.savesData.MainData.Points;
            partsData = YandexGame.savesData.PartsData;
            firstStart = YandexGame.savesData.MainData.FirstStart;
        }

        public void SavePoints(int points)
        {
            YandexGame.savesData.MainData.Points = points;

            YandexGame.SaveProgress();
        }


        public void SaveOpenPart(SCRO_PartData[] partsData)
        {
            SavePartData[] savePartData = new SavePartData[partsData.Length];

            for (int i = 0; i < partsData.Length; i++)
            {
                savePartData[i] = new SavePartData();
                savePartData[i].ID = partsData[i].ID;
                savePartData[i].IsOpen = partsData[i].IsOpen;
            }

            YandexGame.savesData.PartsData = partsData;

            YandexGame.SaveProgress();
        }

        public void SaveFirstStart()
        {
            YandexGame.savesData.MainData.FirstStart = true;

            YandexGame.SaveProgress();
        }
    }
}