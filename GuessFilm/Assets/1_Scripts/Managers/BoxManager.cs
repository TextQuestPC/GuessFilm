using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class BoxManager : MonoBehaviour
    {
        [HideInInspector]
        public delegate void Initialize();
        public static Initialize OnInit;

        private static Dictionary<Type, object> data = new Dictionary<Type, object>();

        private static SCRO_SceneManagers sceneManagers;

        public static object GetMan { get; internal set; }

        #region INIT

        public static void Init(SCRO_SceneManagers sceneManagers)
        {
            BoxManager.sceneManagers = sceneManagers;

            Coroutines.StartRoutine(InitGameRoutine());
        }

        private static IEnumerator InitGameRoutine()
        {
            CreateManagers();
            yield return null;

            InitManagers();
            yield return null;

            StartManagers();
            yield return null;

            OnInit?.Invoke();
        }

        private static void CreateManagers()
        {
            Debug.Log($"START CreateManagers");

            foreach (var manager in sceneManagers.GetManagers)
            {
                var add = Instantiate(manager);

                data.Add(add.GetType(), add);
            }

            Debug.Log($"END CreateManagers");

        }

        private static void InitManagers()
        {
            foreach (var manager in data.Values)
            {
                (manager as BaseManager).OnInitialize();
            }
        }

        private static void StartManagers()
        {
            foreach (var manager in data.Values)
            {
                (manager as BaseManager).OnStart();
            }
        }

        #endregion

        public static T GetManager<T>()
        {
            object manager;
            data.TryGetValue(typeof(T), out manager);
            return (T)manager;
        }
    }
}
