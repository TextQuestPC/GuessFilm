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
            BoxManager.Init(sceneManagers, isLogging);

            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();

            BoxManager.GetManager<GameManager>().StartGame();
        }
    }
}
