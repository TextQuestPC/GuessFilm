using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class VariantButton : MyButton
    {
        private VariantsWindow variantsWindow;
        private Text variantText;

        public string GetVariantText { get => variantText.text; }

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

        public void WinVariant()
        {
            GetComponent<Animator>().SetTrigger("Win");
        }
    }
}