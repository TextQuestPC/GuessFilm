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

        public override void OnInitialize()
        {
            if(YandexGame.savesData.MainData != null)
            {
                points = YandexGame.savesData.MainData.Points;
                partsData = YandexGame.savesData.PartsData;
                firstStart = YandexGame.savesData.MainData.FirstStart;

                Debug.Log("ПРоверяем какая дата пришла из сохранения");
                Debug.Log($"points = {points}");
                Debug.Log($"partsData = {partsData}");
                Debug.Log($"firstStart = {firstStart}");
            }
        }

        public void SavePoints(int points)
        {
            YandexGame.savesData.MainData.Points = points;

            YandexGame.SaveProgress();
        }

        public void SaveOpenPart(PartData[] partsData)
        {
            SavePartData[] savePartData = new SavePartData[partsData.Length];

            for (int i = 0; i < partsData.Length; i++)
            {
                savePartData[i] = new SavePartData();
                savePartData[i].Id = partsData[i].Id;
                savePartData[i].IsOpen = partsData[i].IsOpen;
                savePartData[i].GuessPuzzle = partsData[i].GuessPuzzle;
            }

            YandexGame.savesData.PartsData = savePartData;
            YandexGame.SaveProgress();
        }

        public void SaveFirstStart()
        {
            YandexGame.savesData.MainData.FirstStart = true;
            YandexGame.SaveProgress();
        }

        сделать сохранение на yandex и локальное для ПК
    }
}