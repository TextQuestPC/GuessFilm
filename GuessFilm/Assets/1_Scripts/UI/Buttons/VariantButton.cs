using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class VariantButton : MyButton
    {
        [SerializeField] private Sprite defaultSprite, greenSprite, redSprite;

        private VariantsWindow variantsWindow;
        private Text variantText;

        protected override void AfterAwake()
        {
            variantText = GetComponentInChildren<Text>();
            variantsWindow = GetComponentInParent<VariantsWindow>();
        }

        public void SetData(string variant)
        {
            variantText.text = variant;
        }

        protected override void OnClickButton()
        {
            variantsWindow.SelectVariant(variantText.text);
        }
    }
}