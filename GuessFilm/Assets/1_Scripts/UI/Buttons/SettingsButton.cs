using Core;

namespace UI
{
    public class SettingsButton : MyButton
    {
        protected override void OnClickButton()
        {
            BoxManager.GetManager<GameManager>().ClickSettingsButton();
        }
    }
}