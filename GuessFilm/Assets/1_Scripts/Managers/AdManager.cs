using System.Collections;
using UI;
using UnityEngine;
using YG;

namespace Core
{
    [CreateAssetMenu(fileName = "AdManager", menuName = "Managers/AdManager")]
    public class AdManager : BaseManager
    {
        private const int TIME_WAIT_AD = 3;

        private YandexGame YG;
        public YandexGame SetYandexGame { set => YG = value; }

        private int timeBeforeAd;
        private bool isCanShowAd = true;

        public int GetTimeBeforeAd { get => timeBeforeAd; }
        public bool GetIsCanShowAd { get => isCanShowAd; }

        public override void OnInitialize()
        {
            YandexGame.CheaterVideoEvent += ErrorShowAd;
            YandexGame.CloseVideoEvent += EndShowRewardAd;
            YandexGame.CloseFullAdEvent += EndFullScreen;
        }

        public void ShowFullScreen()
        {
            if (isCanShowAd)
            {
                StartTimeBeforeAd();

                AudioManager.Instance.DisableVolume();

                YG._FullscreenShow();
            }
        }

        public void ShowRewardAd()
        {
            if (isCanShowAd)
            {
                StartTimeBeforeAd();
                AudioManager.Instance.DisableVolume();

                YG._RewardedShow(100);
            }
        }

        private void StartTimeBeforeAd()
        {
            isCanShowAd = false;
            timeBeforeAd = TIME_WAIT_AD;
        }

        private void EndShowRewardAd(int numberReward)
        {
            BoxManager.GetManager<PointsManager>().AddPoints(100);

            AudioManager.Instance.EnableVolume();
            Coroutines.StartRoutine(CoTime());
        }

        private void ErrorShowAd()
        {
            isCanShowAd = true;

            UIManager.Instance.ShowWindow<ErrorAdWindow>();

            AudioManager.Instance.EnableVolume();
        }

        private void EndFullScreen()
        {
            AudioManager.Instance.EnableVolume();

            Coroutines.StartRoutine(CoTime());
        }

        private IEnumerator CoTime()
        {
            while (timeBeforeAd > 0)
            {
                timeBeforeAd--;
                yield return new WaitForSeconds(1);
            }

            isCanShowAd = true;
        }
    }
}