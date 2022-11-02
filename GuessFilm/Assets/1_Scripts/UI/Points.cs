using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private Text textPoints;
        [SerializeField] private GameObject starsParent;
        [SerializeField] private GameObject[] stars;

        private Animator animator;

        private float startAnimTime;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            AnimationClip[] animations = animator.runtimeAnimatorController.animationClips;

            foreach (var anim in animations)
            {
                if (anim.name == "StarFly")
                {
                    startAnimTime = anim.length;
                }
            }
        }

        public void SetPoints(int points)
        {
            textPoints.text = points.ToString();
        }

        public void ShowUpPoints(int points, int countStars)
        {
            StartCoroutine(CoShowUpPoints(points, countStars));
        }

        public void ShowDownPoints(int points)
        {
            animator.SetTrigger("UpPoints");
            textPoints.text = points.ToString();
        }

        private IEnumerator CoShowUpPoints(int points, int countStars)
        {
            foreach (var star in stars)
            {
                star.gameObject.SetActive(false);
            }

            for (int i = 0; i < countStars; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            starsParent.gameObject.SetActive(true);
            animator.SetTrigger("StarFly");

            yield return new WaitForSeconds(startAnimTime);

            starsParent.gameObject.SetActive(false);
            animator.SetTrigger("UpPoints");
            textPoints.text = points.ToString();
        }
    }
}