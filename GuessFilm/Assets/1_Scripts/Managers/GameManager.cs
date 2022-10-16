using Data;
using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : BaseManager
    {
        private TypeLanguage language;
        private bool isGameNow;

        private PuzzleData[] currentPuzzles;
        private int counterPuzzle = 0;
        private string currentVariant;
        private int countPoints;

        public TypeLanguage Language { get => language; set => language = value; }

        public override void OnInitialize()
        {
            // TODO: check language on device

            language = TypeLanguage.Russian;
        }

        public override void OnStart()
        {
            UIManager.Instance.ShowWindow<PartsWindow>();
        }

        #region GAMEPLAY

        public void StartGame()
        {
            UIManager.Instance.HideWindow<PartsWindow>();

            NextPartPuzzles();
            NextVariant();

            isGameNow = true;
        }

        public void SelectVariantPart(string variant)
        {
            if (variant == currentVariant)
            {
                BoxManager.GetManager<PointsManager>().AddPoints(countPoints);
            }

            AfterSelectVariant();
        }

        private void NextPartPuzzles()
        {
            currentPuzzles = BoxManager.GetManager<StorageManager>().GetCurrentPart.PuzzlesData;
            counterPuzzle = 0;
        }

        private void NextVariant()
        {
            PuzzleData data = currentPuzzles[counterPuzzle];
            string[] texts = new string[4];
            countPoints = data.CountPoints;

            if (language == TypeLanguage.Russian)
            {
                currentVariant = data.RussianVariants[0];
                data.RussianVariants.CopyTo(texts, 0);
            }
            else if (language == TypeLanguage.English)
            {
                currentVariant = data.EnglishVariants[0];
                data.EnglishVariants.CopyTo(texts, 0);
            }

            if (texts == null)
            {
                BoxManager.GetManager<LogManager>().LogError($"Texts variants = null! Number puzzle = {counterPuzzle}");

            }
            else
            {
                texts = Shuffle(texts);
                UIManager.Instance.GetWindow<VariantsWindow>().SetData(texts, data.Sprite);
            }
        }

        private string[] Shuffle(string[] texts)
        {
            int n = texts.Length;
            var rand = new System.Random();

            while (n > 1)
            {
                n--;
                int r = rand.Next(n + 1);
                string value = texts[r];
                texts[r] = texts[n];
                texts[n] = value;
            }

            return texts;
        }

        private void AfterSelectVariant()
        {
            counterPuzzle++;

            if (counterPuzzle >= currentPuzzles.Length)
            {
                NextPartPuzzles();
            }
            else
            {
                NextVariant();
            }
        }

        #endregion GAMEPLAY

        public void ClickSettingsButton()
        {
            isGameNow = false;

            UIManager.Instance.ShowWindow<SettingsWindow>();
        }

        public void CloseSettingsWindow()
        {
            isGameNow = true;

            UIManager.Instance.HideWindow<SettingsWindow>();
        }
    }
}