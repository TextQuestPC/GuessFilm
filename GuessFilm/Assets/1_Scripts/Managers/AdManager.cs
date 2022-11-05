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
            YandexGame.CheaterVideoEvent += ErrorShowAd;
            YandexGame.CloseVideoEvent += AddReward;
        }

        private void OnDisable()
        {
            YandexGame.CheaterVideoEvent -= ErrorShowAd;
            YandexGame.CloseVideoEvent -= AddReward;
        }

        public void ShowFullScreen()
        {
            YG._FullscreenShow();
        }

        public void ShowRewardAd()
        {
            
            YG._RewardedShow(100);
        }

        private void AddReward(int numberReward)
        {
            BoxManager.GetManager<PointsManager>().AddPoints(100);
        }

        private void ErrorShowAd()
        {
            UIManager.Instance.ShowWindow<ErrorAdWindow>();
        }
    }
}