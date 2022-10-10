using System.Collections;
using System.Linq;
using UI;
using UnityEngine;

namespace Core
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging;
        [SerializeField] GameObject obj;

        [SerializeField] private UIManager uiManager;

        private IEnumerator Start()
        {
            BoxManager.Init(sceneManagers, isLogging);

            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            var localManager = BoxManager.GetManager<LocalizationManager>();
            yield return new WaitForEndOfFrame();
            localManager.OnStart(obj);
        }
    }
}
