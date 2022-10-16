using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "LogManager", menuName = "Managers/LogManager")]
    public class LogManager : BaseManager
    {
        private bool isNeedLog = false;

        public bool SetIsNeedLog
        {
            set 
            { 
                isNeedLog = value;

                if (value)
                {
                    UIManager.Instance.ShowWindow<LogWindow>();
                }
            }
        }

        public void Log(string message)
        {
            if (isNeedLog)
            {
                Debug.Log(message);

                UIManager.Instance.GetWindow<LogWindow>().Log(message);
            }
        }

        public void LogError(string error)
        {
            if (isNeedLog)
            {
                Debug.Log($"<color=red>{error}</color>");

                UIManager.Instance.GetWindow<LogWindow>().LogError(error);
            }
        }
    }
}