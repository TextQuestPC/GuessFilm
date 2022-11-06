using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowAdWindow : Window
    {
        [SerializeField] private Button showAdButton;
        [SerializeField] private Text labelUp, labelCenter, countCoinsText;

        protected override void AfterInitialization()
        {
            showAdButton.onClick.AddListener(ClickShowAd);
        }

        private void ClickShowAd()
        {
            BoxManager.GetManager<AdManager>().ShowRewardAd();
            Hide();
        }
    }
}