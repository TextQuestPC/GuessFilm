using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndPartWindow : Window
    {
        [SerializeField] private Text endPartText, labelGuessText, countGuessText, labelCurrentPointsText, currentPointsText, buttonNextText;

        public override void ChangeLanguage()
        {
            endPartText.text = Localizator.Instance.GetTextUI("Part") + BoxManager.GetManager<StorageManager>().GetCurrentPart.NameUi + Localizator.Instance.GetTextUI("End");
            labelGuessText.text = Localizator.Instance.GetTextUI("Guessed");
            labelCurrentPointsText.text = Localizator.Instance.GetTextUI("Received");
            buttonNextText.text = Localizator.Instance.GetTextUI("Next");
        }

        protected override void BeforeShow()
        {
            PartData partData = BoxManager.GetManager<StorageManager>().GetCurrentPart;
            int countGuess = 0;

            foreach (var guess in partData.GuessPuzzle)
            {
                if (guess)
                {
                    countGuess++;
                }
            }

            countGuessText.text = $"{countGuess}/{partData.GuessPuzzle.Length}";
            currentPointsText.text = $"{ BoxManager.GetManager<PointsManager>().CurrentPoints}";

            ChangeLanguage();
        }

        protected override void AfterHide()
        {
            BoxManager.GetManager<GameManager>().CloseEndPartWindow();
        }
    }
}