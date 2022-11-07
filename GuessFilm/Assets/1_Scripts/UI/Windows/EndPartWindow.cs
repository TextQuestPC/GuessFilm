using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndPartWindow : Window
    {
        [SerializeField] private Text winText, labelGuessText, countGuessText, labelCurrentPointsText, currentPointsText;

        public override void ChangeLanguage(TypeLanguage language)
        {
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
        }

        protected override void AfterHide()
        {
            BoxManager.GetManager<GameManager>().CloseEndPartWindow();
        }
    }
}