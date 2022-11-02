using Core;
using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_Window : Window
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private Points points;

        protected override void AfterInitialization()
        {
            settingsButton.onClick.AddListener(ClickSettingsButton);

            points.SetPoints(SaveLoadManager.Instance.GetPoints());
        }

        public void SetPoints(int value)
        {
            points.SetPoints(value);
        }

        public void ShowUpPoints(int value, int countStars)
        {
            points.ShowUpPoints(value, countStars);
        }

        public void ShowDownPoints(int value)
        {
            points.ShowDownPoints(value);
        }

        private void ClickSettingsButton()
        {
            BoxManager.GetManager<GameManager>().ClickSettingsButton();
        }
    }
}