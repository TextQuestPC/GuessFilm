using Data;
using UI;
using UnityEngine;
using YG;

namespace Core
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] YandexGame YG;

        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging;
        [SerializeField] private bool skipTutorial;

        private void Start()
        {
            AuthorizationPlayer();
        }

        private void AuthorizationPlayer()
        {
            YG.ResolvedAuthorization.AddListener(ResolvedAuthorization);
            YG.RejectedAuthorization.AddListener(RejectedAuthorization);

            //YG._AuthorizationCheck();
        }

        private void ResolvedAuthorization()
        {
            BoxManager.GetManager<LogManager>().Log("End Authorization");

            AfterAuthorization();
        }

        private void RejectedAuthorization()
        {
            BoxManager.GetManager<LogManager>().Log("ERROR Authorization");

            AfterAuthorization();
        }

        private void AfterAuthorization()
        {
            YandexGame.SwitchLangEvent += SwitchLanguage;

            TypeLanguage typeLanguage = TypeLanguage.English;
            string language = YandexGame.savesData.language;

            if(language == "ru")
            {
                typeLanguage = TypeLanguage.Russian;
            }

            // TODO: change language in UI

            BoxManager.GetManager<GameManager>().Language = typeLanguage;
            BoxManager.GetManager<SaveLoadManager>().LoadData();

            BoxManager.GetManager<AdManager>().ShowFullScreen();

            InitControllers();
        }

        private void InitControllers()
        {
            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            BoxManager.OnInit.AddListener( AfterInitControllers);
            BoxManager.Init(sceneManagers);            
        }

        private void AfterInitControllers()
        {
            BoxManager.OnInit.RemoveListener(AfterInitControllers);

            BoxManager.GetManager<LogManager>().SetIsNeedLog = isLogging;
            BoxManager.GetManager<AdManager>().SetYandexGame = YG;

            BoxManager.GetManager<GameManager>().SkipTutorial = skipTutorial;

            BoxManager.GetManager<GameManager>().StartGame();
        }

        private void SwitchLanguage(string lang)
        {
            TypeLanguage typeLanguage = TypeLanguage.English;

            if (lang == "ru")
            {
                typeLanguage = TypeLanguage.Russian;
            }

            BoxManager.GetManager<GameManager>().Language = typeLanguage;
        }
    }
}
