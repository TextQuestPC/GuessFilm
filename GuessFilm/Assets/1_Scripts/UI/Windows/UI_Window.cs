using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_Window : Window
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private Text pointsText;

        protected override void AfterInitialization()
        {
            settingsButton.onClick.AddListener(ClickSettingsButton);
        }

        public void ShowPoints(int points)
        {
            pointsText.text = points.ToString();
        }

        private void ClickSettingsButton()
        {
            BoxManager.GetManager<GameManager>().ClickSettingsButton();
        }
    }
}