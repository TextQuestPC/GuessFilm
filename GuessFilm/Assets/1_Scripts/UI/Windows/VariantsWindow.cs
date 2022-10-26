using Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class VariantsWindow : Window
    {
        public UnityEvent OnSelectVariant;

        [SerializeField] private VariantButton[] buttons;
        [SerializeField] private Image image;

        private bool canClick = true;

        public void SetData(string[] texts, Sprite sprite)
        {
            Show();

            if(texts.Length < 4)
            {
                BoxManager.GetManager<LogManager>().LogError($"Count texts < 4!");
            }

            for (int i = 0; i < texts.Length; i++)
            {
                buttons[i].SetData(texts[i]);
            }

            image.sprite = sprite;

            canClick = true;
        }

        public void SelectVariant(string text)
        {
            canClick = false;

            BoxManager.GetManager<GameManager>().SelectVariantPart(text);

            OnSelectVariant?.Invoke();
        }
    }
}