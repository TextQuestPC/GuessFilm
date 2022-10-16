using UI;
using UnityEngine;

namespace Core
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging;

        private void Start()
        {
            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            BoxManager.Init(sceneManagers);

            BoxManager.GetManager<LogManager>().SetIsNeedLog = isLogging;
        }
    }
}
