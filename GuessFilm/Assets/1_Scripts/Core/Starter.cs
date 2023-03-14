using Data;
using SaveSystem;
using UI;
using UnityEngine;
using YG;

namespace Core
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] YandexGame YG;

        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging, skipTutorial, saveInYandex;

        private bool isLoad;

        private void Start()
        {
            AuthorizationPlayer();
        }

        private void AuthorizationPlayer()
        {
            YG.ResolvedAuthorization.AddListener(ResolvedAuthorization);
            YG.RejectedAuthorization.AddListener(RejectedAuthorization);

            YG._AuthorizationCheck();
        }

        private void ResolvedAuthorization()
        {
            LogManager.Instance.Log("End Authorization");

            LoadData();
        }

        private void RejectedAuthorization()
        {
            LogManager.Instance.Log("ERROR Authorization");

            LoadData();
        }

        private void LoadData()
        {
            if (!isLoad)
            {
                isLoad = true;

                SaveLoadManager.Instance.OnLoad.AddListener(InitControllers);
                SaveLoadManager.Instance.SetSaveInYandex = saveInYandex;
                SaveLoadManager.Instance.LoadData();
            }
        }

        private void InitControllers()
        {
            SaveLoadManager.Instance.OnLoad.RemoveListener(InitControllers);

            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            BoxManager.OnInit += AfterInitControllers;
            BoxManager.Init(sceneManagers);
        }

        private void AfterInitControllers()
        {
            BoxManager.OnInit -= AfterInitControllers;

            LogManager.Instance.SetIsNeedLog = isLogging;
            BoxManager.GetManager<AdManager>().SetYandexGame = YG;

            TypeLanguage typeLanguage = TypeLanguage.English;
            string language = YandexGame.savesData.language;

            if (language == "ru")
            {
                typeLanguage = TypeLanguage.Russian;
            }
            else
            {
                typeLanguage = TypeLanguage.English;
            }

            // TODO: change language in UI

            BoxManager.GetManager<GameManager>().Language = typeLanguage;

            BoxManager.GetManager<GameManager>().SkipTutorial = skipTutorial;
            BoxManager.GetManager<GameManager>().StartGame();
        }
    }
}
