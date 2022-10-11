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
        private TextKeeper[] textKeepers;

        [SerializeField] private UIManager uiManager;

        private IEnumerator Start()
        {
            BoxManager.Init(sceneManagers, isLogging);

            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            var localManager = BoxManager.GetManager<LocalizationManager>();
            yield return new WaitForEndOfFrame();
            GetAllTextKeepers();
            localManager.OnStart(textKeepers);
        }

        private void GetAllTextKeepers()
        {
            textKeepers = FindObjectsOfType<TextKeeper>();
        }
    }
}
