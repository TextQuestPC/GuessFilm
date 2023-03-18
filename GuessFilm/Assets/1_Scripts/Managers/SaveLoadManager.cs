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

        public int GetPoints()
        {
            return YandexGame.savesData.Points;
        }

        public bool GetFirstStart()
        {
            return YandexGame.savesData.FirstStart;
        }

        public SavePartData[] GetPartsData()
        {
            return YandexGame.savesData.PartsData;            
        }

        public void LoadData()
        {
            if (YandexGame.savesData != null)
            {
                Debug.Log($"points = {YandexGame.savesData.Points}");
                Debug.Log($"partsData = {YandexGame.savesData.PartsData}");
                Debug.Log($"firstStart = {YandexGame.savesData.FirstStart}");
            }
            else
            {
                Debug.Log($"save data = null");
            }

            OnLoad?.Invoke();
        }

        public void Save()
        {
            int points = BoxManager.GetManager<PointsManager>().Points;
            bool firstStart = true;

            YandexGame.savesData.PartsData = GeneratePartsData();
            YandexGame.savesData.Points = points;
            YandexGame.savesData.FirstStart = firstStart;

            YandexGame.SaveProgress();
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