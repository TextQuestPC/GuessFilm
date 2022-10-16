using UnityEngine;
using YG;

namespace Core
{
    [CreateAssetMenu(fileName = "AdManager", menuName = "Managers/AdManager")]
    public class AdManager : BaseManager
    {
        private YandexGame YG;
        public YandexGame SetYandexGame { set => YG = value; }

        public void ShowFullScreen()
        {
            YG._FullscreenShow();
        }

        public void ShowRewardAd()
        {
            YG._RewardedShow(0);
        }
    }
}