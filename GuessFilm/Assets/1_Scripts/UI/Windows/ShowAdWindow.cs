using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowAdWindow : Window
    {
        [SerializeField] private Button showAdButton;
        [SerializeField] private Text labelUp, labelCenter, countCoinsText;

        public override void ChangeLanguage(TypeLanguage language)
        {
            showAdButton.GetComponentInChildren<Text>().text = Localizator.Instance.GetTextUI("Watch");
            labelUp.text = Localizator.Instance.GetTextUI("Watch");
            labelCenter.text = Localizator.Instance.GetTextUI("ViewAdsFor");
        }

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