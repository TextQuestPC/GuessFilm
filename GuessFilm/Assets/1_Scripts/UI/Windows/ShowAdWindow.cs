using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowAdWindow : Window
    {
        [SerializeField] private Button showAdButton, closeButton;
        [SerializeField] private Text labelUp, labelCenter, countCoinsText;

        protected override void AfterInitialization()
        {
            showAdButton.onClick.AddListener(ClickShowAd);
            closeButton.onClick.AddListener(ClickCloseButton);
        }

        private void ClickShowAd()
        {
            BoxManager.GetManager<AdManager>().ShowRewardAd();
            Hide();
        }

        private void ClickCloseButton()
        {
            Hide();
        }
    }
}