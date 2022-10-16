using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SceneManager", menuName = "Managers/SceneManagers")]
    public class SCRO_SceneManagers : ScriptableObject
    {
        [SerializeField, ClassReference(typeof(BaseManager))]
        private BaseManager[] managers;

        [HideInInspector]
        public BaseManager[] GetManagers { get => managers; }
    }
}
