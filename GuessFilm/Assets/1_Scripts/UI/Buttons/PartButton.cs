using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PartButton : MyButton
    {
        [SerializeField] private Image imagePart, selectImage;

        private PartsWindow partsWindow;
        private Text namePartText;
        private int numberPart;

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

            if (!data.IsOpen)
            {
                GetComponent<Button>().interactable = false;
            }
        }

        public void SelectButton()
        {
            selectImage.gameObject.SetActive(true);
        }

        public void CancelSelectButton()
        {
            selectImage.gameObject.SetActive(false);
        }

        protected override void OnClickButton()
        {
            partsWindow.SelectPart(this, numberPart);
        }
    }
}