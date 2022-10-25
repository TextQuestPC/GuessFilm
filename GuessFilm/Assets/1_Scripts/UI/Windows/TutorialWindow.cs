using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TutorialWindow : Window
    {
        [SerializeField] private GameObject selectVariantObject;
        [SerializeField] private Text selectVariantText;

        public void ShowSelectVariantText()
        {
            selectVariantObject.gameObject.SetActive(true);
        }

        public void HideSelectVariantText()
        {
            selectVariantObject.gameObject.SetActive(false);
        }

    }
}