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
        [SerializeField] private Text priceText, buyText;

        private PartsWindow partsWindow;
        private Text namePartText;
        private int numberPart;
        private bool isOpen;

        protected override void AfterAwake()
        {
            partsWindow = GetComponentInParent<PartsWindow>();
            namePartText = GetComponentInChildren<Text>();
        }

        public void SetData(PartData data)
        {
            namePartText.text = data.NamePart;
            imagePart.sprite = data.SpritePart;
            numberPart = data.NumberPart;
            isOpen = data.IsOpen;
            priceText.text = data.PricePart.ToString();

            closeObject.SetActive(!isOpen);

            if (!data.IsOpen)
            {
                GetComponent<Button>().interactable = false;
            }
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