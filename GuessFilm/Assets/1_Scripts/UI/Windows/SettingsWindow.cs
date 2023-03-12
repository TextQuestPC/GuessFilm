using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsWindow : Window
    {
        [SerializeField] private Toggle englishToggle, russianToggle;
        [SerializeField] private Slider musicSlider;

        private AudioManager audioManager;

        protected override void AfterInitialization()
        {
            audioManager = AudioManager.Instance;

            englishToggle.onValueChanged.AddListener(delegate
            {
                SelectToggle(TypeLanguage.English, englishToggle.isOn);
            });

            russianToggle.onValueChanged.AddListener(delegate
            {
                SelectToggle(TypeLanguage.Russian, russianToggle.isOn);
            });

            musicSlider.onValueChanged.AddListener(delegate
            {
                audioManager.ChangeMusicVolume(musicSlider.value);
                audioManager.ChangeSoundVolume(musicSlider.value);
            });
        }

        protected override void BeforeShow()
        {
            TypeLanguage language = BoxManager.GetManager<GameManager>().Language;

            russianToggle.isOn = language == TypeLanguage.Russian;
            englishToggle.isOn = language == TypeLanguage.English;
        }

        protected override void AfterHide()
        {
            BoxManager.GetManager<GameManager>().CloseSettingsWindow();
        }

        private void SelectToggle(TypeLanguage language, bool isOn)
        {
            audioManager.PlayUISound(TypeUISound.ButtonClick);

            if (language == TypeLanguage.English)
            {
                if (isOn)
                {
                    russianToggle.isOn = false;

                    BoxManager.GetManager<GameManager>().ChangeLanguage(TypeLanguage.English);
                }
                else
                {
                    russianToggle.isOn = true;
                }
            }
            else if (language == TypeLanguage.Russian)
            {
                if (isOn)
                {
                    englishToggle.isOn = false;

                    BoxManager.GetManager<GameManager>().ChangeLanguage(TypeLanguage.Russian);
                }
                else
                {
                    englishToggle.isOn = true;
                }
            }
        }

        public override void ChangeLanguage()
        {
        }
    }
}