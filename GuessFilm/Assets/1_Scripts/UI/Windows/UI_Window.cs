using SaveSystem;
using UnityEngine;

namespace UI
{
    public class UI_Window : Window
    {
        [SerializeField] private SettingsButton settingsButton;
        [SerializeField] private Points points;

        protected override void AfterInitialization()
        {
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
    }
}