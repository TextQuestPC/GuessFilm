using UI;

namespace Core
{
    public class TutorialManager : BaseManager
    {
        public void StartSelectVariantTutor()
        {
            UIManager.Instance.GetWindow<TutorialWindow>().ShowSelectVariantText();
            UIManager.Instance.GetWindow<VariantsWindow>().OnSelectVariant.AddListener(SelectVariant);
        }

        private void SelectVariant()
        {
            UIManager.Instance.GetWindow<VariantsWindow>().OnSelectVariant.RemoveListener(SelectVariant);
            UIManager.Instance.GetWindow<TutorialWindow>().HideSelectVariantText();
        }
    }
}