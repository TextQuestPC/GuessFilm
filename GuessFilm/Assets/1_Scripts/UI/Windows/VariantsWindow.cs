using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class VariantsWindow : Window
    {
        public UnityEvent OnSelectVariant;

        [SerializeField] private VariantButton[] buttons;
        [SerializeField] private Image image, image2;
        [SerializeField] private Animator imagesAnimator;

        private bool canClick = true;

        public void SetData(string[] texts, Sprite sprite, bool needLeaf)
        {
            Show();

            if(texts.Length < 4)
            {
                LogManager.Instance.LogError($"Count texts < 4!");
            }

            for (int i = 0; i < texts.Length; i++)
            {
                buttons[i].SetData(texts[i]);
            }

            image.sprite = sprite;

            if (needLeaf)
            {
                StartCoroutine(CoLeafImages(sprite));
            }
            else
            {
                image2.sprite = sprite;
            }

            canClick = true;
        }

        private IEnumerator CoLeafImages(Sprite sprite)
        {
            imagesAnimator.SetTrigger("Leaf");
            yield return new WaitForSeconds(1f);
            image2.sprite = sprite;
        }

        public void SelectVariant(string text)
        {
            canClick = false;

            BoxManager.GetManager<GameManager>().SelectVariantPart(text);

            OnSelectVariant?.Invoke();
        }

        public void ShowWinVariant(string winVariant)
        {
            StartCoroutine(CoShowWinVariant(winVariant));
        }

        private IEnumerator CoShowWinVariant(string winVariant)
        {
            VariantButton winButton = null;

            foreach (var button in buttons)
            {
                if(winVariant == button.GetVariantText)
                {
                    winButton = button;
                }
            }

            if(winButton != null)
            {
                winButton.WinVariant();
            }

            yield return new WaitForSeconds(1f);

            BoxManager.GetManager<GameManager>().AfterShowWinVariant();
        }
    }
}