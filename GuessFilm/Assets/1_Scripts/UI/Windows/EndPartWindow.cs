using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndPartWindow : Window
    {
        [SerializeField] private Text winText, labelGuessText, countGuessText;
        [SerializeField] private Button closeButton;

        protected override void AfterInitialization()
        {
            closeButton.onClick.AddListener(ClickCloseButton);
        }

        private void ClickCloseButton()
        {
            BoxManager.GetManager<GameManager>().CloseEndPartWindow();
        }
    }
}