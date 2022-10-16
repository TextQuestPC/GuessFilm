using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VariantsWindow : Window
    {
        [SerializeField] private VariantButton[] buttons;
        [SerializeField] private Image image;

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
        }

        public void SelectVariant(string text)
        {
            BoxManager.GetManager<GameManager>().SelectVariantPart(text);
        }
    }
}