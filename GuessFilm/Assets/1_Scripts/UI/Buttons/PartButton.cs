using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PartButton : MyButton
    {
        [SerializeField] private Image imagePart, substrateImage, closeImage;
        [SerializeField] private Text namePartText, priceText, countGuess, labelBuyText;
        [SerializeField] private Slider sliderGuess;
        [SerializeField] private Color defaultColor, selectedColor;

        private PartsWindow partsWindow;
        private int numberPart;
        private bool isOpen;

        protected override void AfterAwake()
        {
            partsWindow = GetComponentInParent<PartsWindow>();
        }

        public void SetData(PartData data)
        {
            namePartText.text = data.NamePart;
            imagePart.sprite = data.SpritePart;
            numberPart = data.Id;
            priceText.text = data.PricePart.ToString();
            countGuess.text = $"{data.GuessPuzzle.Length}/{data.PuzzlesData.Length}";
            isOpen = data.IsOpen;

            closeImage.gameObject.SetActive(!isOpen);
            sliderGuess.gameObject.SetActive(isOpen);
        }

        public void SelectButton()
        {
            substrateImage.color = selectedColor;
        }

        public void CancelSelectButton()
        {
            substrateImage.color = defaultColor;
        }

        protected override void OnClickButton()
        {
            if (isOpen)
            {
                partsWindow.SelectPart(this, numberPart);
            }
            else
            {
                BoxManager.GetManager<StorageManager>().TryOpenPart(numberPart);
            }
        }
    }
}