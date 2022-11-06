using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private Text textPoints;
        [SerializeField] private GameObject starsParent;
        [SerializeField] private GameObject starPrefab;

        private List<GameObject> stars = new List<GameObject>();

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

        public void ShowChangePoints(int newValue)
        {
            animator.SetTrigger("UpPoints");
            textPoints.text = newValue.ToString();
        }

        private IEnumerator CoShowUpPoints(int points, int countStars)
        {
            for (int i = 0; i < countStars; i++)
            {
                GameObject star = Instantiate(starPrefab, starsParent.transform);
                stars.Add(star);
            }


            yield return new WaitForSeconds(startAnimTime);

            textPoints.text = points.ToString();
        }
    }
}