using UnityEngine;

namespace UI
{
    public class UI_Window : Window
    {
        [SerializeField] private SettingsButton settingsButton;
        [SerializeField] private PointsController points;

        public void SetPoints(int value)
        {
            points.SetPoints(value);
        }

        public void ShowUpPoints(int value, int countCoins)
        {
            points.ShowUpPoints(value, countCoins);
        }

        public void ShowDownPoints(int value)
        {
            points.ShowChangePoints(value);
        }

        public override void ChangeLanguage()
        {
        }
    }
}