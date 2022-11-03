using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndPartWindow : Window
    {
        [SerializeField] private Text winText, labelGuessText, countGuessText, labelCurrentPointsText, currentPointsText;
        [SerializeField] private Button closeButton;

        protected override void AfterInitialization()
        {
            closeButton.onClick.AddListener(ClickCloseButton);
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

        private void ClickCloseButton()
        {
            BoxManager.GetManager<GameManager>().CloseEndPartWindow();
        }
    }
}