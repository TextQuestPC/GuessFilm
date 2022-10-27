using UI;
using UnityEngine;

namespace Core
{
    public class LogManager : Singleton<LogManager>
    {
        private bool isNeedLog = false;

        [SerializeField] private LogWindow logWindow;

        protected override void AfterAwaik()
        {
            logWindow.OnInitialize();
            logWindow.OnStart();
        }

        public bool SetIsNeedLog
        {
            set 
            { 
                isNeedLog = value;
            }
        }

        public void Log(string message)
        {
            if (isNeedLog)
            {
                Debug.Log(message);

                logWindow.Log(message);
            }
        }

        public void LogError(string error)
        {
            if (isNeedLog)
            {
                Debug.Log($"<color=red>{error}</color>");

                logWindow.LogError(error);
            }
        }
    }
}