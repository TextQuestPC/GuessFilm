using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowAdWindow : Window
    {
        [SerializeField] private Button showAdButton;
        [SerializeField] private Text labelUp, labelCenter, countCoinsText, timeBeforeAdText, timeText;

        protected override void AfterInitialization()
        {
            showAdButton.onClick.AddListener(ClickShowAd);
            ChangeLanguage();
        }

        public override void ChangeLanguage()
        {
            showAdButton.GetComponentInChildren<Text>().text = Localizator.Instance.GetTextUI("Watch");
            labelUp.text = Localizator.Instance.GetTextUI("Watch");
            labelCenter.text = Localizator.Instance.GetTextUI("ViewAdsFor");
            timeBeforeAdText.text = Localizator.Instance.GetTextUI("TimeBeforeAd");
        }

        protected override void BeforeShow()
        {  
            if (BoxManager.GetManager<AdManager>().GetIsCanShowAd)
            {
                showAdButton.gameObject.SetActive(true);
                timeBeforeAdText.gameObject.SetActive(false);
            }
            else
            {
                showAdButton.gameObject.SetActive(false);
                timeBeforeAdText.gameObject.SetActive(true);

                StartCoroutine(CoWaitAd());
            }
        }

        protected override void AfterHide()
        {
            StopCoroutine(CoWaitAd());
        }

        private void ClickShowAd()
        {
            BoxManager.GetManager<AdManager>().ShowRewardAd();
            Hide();
        }

        private IEnumerator CoWaitAd()
        {
            while(BoxManager.GetManager<AdManager>().GetTimeBeforeAd > 0)
            {
                timeText.text = BoxManager.GetManager<AdManager>().GetTimeBeforeAd.ToString();
                yield return new WaitForSeconds(1f);
            }

            showAdButton.gameObject.SetActive(true);
            timeBeforeAdText.gameObject.SetActive(false);
        }
    }
}