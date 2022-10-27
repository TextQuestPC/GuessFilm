using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PartButton : MyButton
    {
        [SerializeField] private Image imagePart;
        [SerializeField] private GameObject selectObject, closeObject;
        [SerializeField] private Text namePartText, priceText, buyText, countGuess;

        private PartsWindow partsWindow;
        private int numberPart;
        private bool isOpen;

        protected override void AfterAwake()
        {
            partsWindow = GetComponentInParent<PartsWindow>();
        }

        public void SetData(SCRO_PartData data)
        {
            namePartText.text = data.NamePart;
            imagePart.sprite = data.SpritePart;
            numberPart = data.ID;
            priceText.text = data.PricePart.ToString();
            countGuess.text = "0/" + data.PuzzlesData.Length;
            isOpen = data.IsOpen;

            closeObject.SetActive(!isOpen);
        }

        public void SelectButton()
        {
            selectObject.SetActive(true);
        }

        public void CancelSelectButton()
        {
            selectObject.SetActive(false);
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