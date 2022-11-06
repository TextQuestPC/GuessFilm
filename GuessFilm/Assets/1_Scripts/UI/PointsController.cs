using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PointsController : MonoBehaviour
    {
        [SerializeField] private Text textPoints;
        [SerializeField] private GameObject coinsParent;
        [SerializeField] private GameObject[] coins;

        private float timeCoinAnimation;

        private Animator textAnimator;

        private void Awake()
        {
            textAnimator = textPoints.GetComponent<Animator>();
            AnimationClip[] animations = coinsParent.GetComponent<Animator>().runtimeAnimatorController.animationClips;

            foreach (var anim in animations)
            {
                if (anim.name == "Anim")
                {
                    timeCoinAnimation = anim.length;
                }
            }
        }

        public void SetPoints(int points)
        {
            textPoints.text = points.ToString();
        }

        public void ShowUpPoints(int points, int countCoins)
        {
            StartCoroutine(CoShowUpPoints(points, countCoins));
        }

        public void ShowChangePoints(int newValue)
        {
            StartCoroutine(CoShowChangePoints(newValue));
        }

        private IEnumerator CoShowChangePoints(int newValue)
        {
            textAnimator.SetTrigger("Change");
            yield return new WaitForSeconds(0.15f);
            textPoints.text = newValue.ToString();
        }

        private IEnumerator CoShowUpPoints(int points, int countCoins)
        {
            for (int i = 0; i < countCoins && i < coins.Length; i++)
            {
                coins[i].SetActive(true);
            }

            coinsParent.SetActive(true);
            yield return new WaitForSeconds(timeCoinAnimation);
            coinsParent.SetActive(false);

            foreach (var coin in coins)
            {
                coin.SetActive(false);
            }

            ShowChangePoints(points);
        }
    }
}