using UI;
using UnityEngine;
using YG;

namespace Core
{
    [CreateAssetMenu(fileName = "AdManager", menuName = "Managers/AdManager")]
    public class AdManager : BaseManager
    {
        private YandexGame YG;
        public YandexGame SetYandexGame { set => YG = value; }

        private void OnEnable()
        {
            2 раза вызывается
            Debug.Log("OnEnable");

            YandexGame.CheaterVideoEvent += ErrorShowAd;
            YandexGame.CloseVideoEvent += AddReward;
            YandexGame.CloseFullAdEvent += EndFullScreen;
        }

        private void OnDisable()
        {
            YandexGame.CheaterVideoEvent -= ErrorShowAd;
            YandexGame.CloseVideoEvent -= AddReward;
        }

        public void ShowFullScreen()
        {
#if !UNITY_EDITOR
            AudioManager.Instance.DisableVolume();
#endif
            YG._FullscreenShow();
        }

        public void ShowRewardAd()
        {
#if !UNITY_EDITOR
            AudioManager.Instance.DisableVolume();
#endif

            YG._RewardedShow(100);
        }

        private void AddReward(int numberReward)
        {
            BoxManager.GetManager<PointsManager>().AddPoints(100);

            AudioManager.Instance.EnableVolume();
        }

        private void ErrorShowAd()
        {
            UIManager.Instance.ShowWindow<ErrorAdWindow>();

            AudioManager.Instance.EnableVolume();
        }

        private void EndFullScreen()
        {
            AudioManager.Instance.EnableVolume();
        }
    }
}