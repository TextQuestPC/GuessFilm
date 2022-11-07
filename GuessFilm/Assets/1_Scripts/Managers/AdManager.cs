using System.Collections;
using UI;
using UnityEngine;
using YG;

namespace Core
{
    [CreateAssetMenu(fileName = "AdManager", menuName = "Managers/AdManager")]
    public class AdManager : BaseManager
    {
        private const float TIME_WAIT_AD = 50f;

        private YandexGame YG;
        public YandexGame SetYandexGame { set => YG = value; }

        private bool isCanShowAd = true;

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
                isCanShowAd = false;

#if UNITY_EDITOR
                AudioManager.Instance.DisableVolume();
#endif

                YG._FullscreenShow();
            }
        }

        public void ShowRewardAd()
        {
            if (isCanShowAd)
            {
                isCanShowAd = false;
                AudioManager.Instance.DisableVolume();

                YG._RewardedShow(100);
            }
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
            yield return new WaitForSeconds(TIME_WAIT_AD);
            isCanShowAd = true;
        }
    }
}