using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ErrorAdWindow : Window
    {
        [SerializeField] private Text errorText;

        protected override void AfterInitialization()
        {
            ChangeLanguage();
        }

        public override void ChangeLanguage()
        {
            errorText.text = Localizator.Instance.GetTextUI("ErrorAdText");
        }
    }
}