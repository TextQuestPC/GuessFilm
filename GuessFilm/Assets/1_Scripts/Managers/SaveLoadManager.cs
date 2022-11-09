using Core;
using Data;
using SaveSystem;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using YG;

namespace SaveSystem
{
    public class SaveLoadManager : Singleton<SaveLoadManager>
    {
        private const string SAVE_NAME = "Save.json"; // C:\Users\unity\AppData\LocalLow\DefaultCompany

        [HideInInspector]
        public UnityEvent OnLoad;

        private bool saveInYandex;

        private SaveData saveData;

        public int GetPoints()
        {
            if (saveInYandex)
            {
                return YandexGame.savesData.SaveData.Points;
            }
            else
            {
                return saveData.Points;
            }
        }

        public bool GetFirstStart()
        {
            if (saveInYandex)
            {
                return YandexGame.savesData.SaveData.FirstStart;
            }
            else
            {
                return saveData.FirstStart;
            }
        }

        public SavePartData[] GetPartsData()
        {
            if (saveInYandex)
            {
                return YandexGame.savesData.SaveData.PartsData;
            }
            else
            {
                return saveData.PartsData;
            }
        }

        public bool SetSaveInYandex { set => saveInYandex = value; }

        public void LoadData()
        {
            if (saveInYandex)
            {
                if (YandexGame.savesData.SaveData != null)
                {
                    SaveData saveData = YandexGame.savesData.SaveData;

                    Debug.Log("ПРоверяем какая дата пришла из сохранения");
                    Debug.Log($"points = {saveData.Points}");
                    Debug.Log($"partsData = {saveData.PartsData}");
                    Debug.Log($"firstStart = {saveData.FirstStart}");
                }
            }
            else
            {
                // Local load data

                if (File.Exists(Application.persistentDataPath + SAVE_NAME))
                {
                    string strLoadJson = File.ReadAllText(Application.persistentDataPath + SAVE_NAME);
                    saveData = JsonUtility.FromJson<SaveData>(strLoadJson);
                }
            }

            OnLoad?.Invoke();
        }

        public void Save()
        {
            int points = BoxManager.GetManager<PointsManager>().GetPoints;
            bool firstStart = true;

            if (saveInYandex)
            {
                YandexGame.savesData.SaveData.PartsData = GeneratePartsData();
                YandexGame.savesData.SaveData.Points = points;
                YandexGame.savesData.SaveData.FirstStart = firstStart;

                YandexGame.SaveProgress();
            }
            else
            {
                SaveData saveData = new SaveData();
                saveData.PartsData = GeneratePartsData();
                saveData.Points = points;
                saveData.FirstStart = firstStart;

                string jsonString = JsonUtility.ToJson(saveData);

                try
                {
                    File.WriteAllText(Application.persistentDataPath + SAVE_NAME, jsonString);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogError($"Error save SaveOpenPart - {ex}");
                }
            }
        }

        private SavePartData[] GeneratePartsData()
        {
            PartData[] partsData = BoxManager.GetManager<StorageManager>().GetAllParts;

            SavePartData[] savePartData = new SavePartData[partsData.Length];

            for (int i = 0; i < partsData.Length; i++)
            {
                savePartData[i] = new SavePartData();
                savePartData[i].Id = partsData[i].Id;
                savePartData[i].IsOpen = partsData[i].IsOpen;
                savePartData[i].GuessPuzzle = partsData[i].GuessPuzzle;
            }

            return savePartData;
        }
    }
}