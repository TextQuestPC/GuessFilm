using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ErrorAdWindow : Window
    {
        [SerializeField] private Text errorText;

        public override void ChangeLanguage(TypeLanguage language)
        {
            errorText.text = Localizator.Instance.GetTextUI("ErrorAdText");
        }
    }
}