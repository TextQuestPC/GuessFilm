using System;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SaveLoadManager", menuName = "Managers/SaveLoadManager")]
    public class SaveLoadManager : BaseManager
    {
        public void Save(string key, object obj)
        { 
            var json = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
        public T Load<T>(string key, T fallback)
        {
            var json = PlayerPrefs.GetString(key, null);
            if(json == null)
            {
                return fallback;
            }
            
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        public T Load<T>(string key)
        {
            var json = PlayerPrefs.GetString(key);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
    }
    // For save mark [Serializable]
}
