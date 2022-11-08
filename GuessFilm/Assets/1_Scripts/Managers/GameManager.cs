using Data;
using SaveSystem;
using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : BaseManager
    {
        private TypeLanguage language;
        private bool isGameNow;

        private PartData currentPart;
        private int counterPuzzle = 0;
        private string currentVariant;

        public TypeLanguage Language { get => language; set => language = value; }
        public bool SkipTutorial { get; set; }

        public void ChangeLanguage(TypeLanguage language)
        {
            this.language = language;

            Localizator.Instance.SetLanguage = language;
            BoxManager.GetManager<StorageManager>().ChangeLanguageParts();
            UIManager.Instance.ChangeLanguage();
        }

        #region GAMEPLAY

        public void StartGame()
        {
            if (SaveLoadManager.Instance.GetFirstStart())
            {
                UIManager.Instance.ShowWindow<PartsWindow>();
            }
            else
            {
                BoxManager.GetManager<StorageManager>().SelectNewPart(0);
                ClickPartGame();
            }

            AudioManager.Instance.PlayMusic();
        }

        public void ClickPartGame()
        {
            UIManager.Instance.GetWindow<UI_Window>().SetPoints(SaveLoadManager.Instance.GetPoints());
            UIManager.Instance.HideWindow<PartsWindow>();

            NextPartData();
            NextVariant();

            isGameNow = true;
        }

        public void SelectVariantPart(string variant)
        {
            if (variant == currentVariant)
            {
                AudioManager.Instance.PlayUISound(TypeUISound.WinSound);

                currentPart.AddGuessPuzzle(counterPuzzle);
                BoxManager.GetManager<PointsManager>().AddPoints(currentPart.PuzzlesData[counterPuzzle].CountPoints);
            }
            else
            {
                AudioManager.Instance.PlayUISound(TypeUISound.LoseSound);
            }

            UIManager.Instance.GetWindow<VariantsWindow>().ShowWinVariant(currentVariant);
        }

        public void AfterShowWinVariant()
        {
            AfterSelectVariant();
        }

        private void NextPartData()
        {
            currentPart = BoxManager.GetManager<StorageManager>().GetCurrentPart;
            BoxManager.GetManager<PointsManager>().CurrentPoints = 0;
            counterPuzzle = 0;
        }

        private void NextVariant()
        {
            PuzzleData data = currentPart.PuzzlesData[counterPuzzle];
            string[] texts = new string[4];

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
                LogManager.Instance.LogError($"Texts variants = null! Number puzzle = {counterPuzzle}");
            }
            else
            {
                texts = Shuffle(texts);
                UIManager.Instance.GetWindow<VariantsWindow>().SetData(texts, data.Sprite, counterPuzzle > 0);
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

            if (counterPuzzle >= currentPart.PuzzlesData.Length)
            {
                UIManager.Instance.GetWindow<VariantsWindow>().EndHide.AddListener((Window window) =>
                {
                    UIManager.Instance.ShowWindow<EndPartWindow>();
                    window.EndHide.RemoveAllListeners();
                });

                UIManager.Instance.HideWindow<VariantsWindow>();
            }
            else
            {
                NextVariant();
            }
        }

        #endregion GAMEPLAY

        public void CloseEndPartWindow()
        {
            UIManager.Instance.GetWindow<EndPartWindow>().EndHide.AddListener((Window window) =>
            {
                UIManager.Instance.ShowWindow<PartsWindow>();
                window.EndHide.RemoveAllListeners();
            });

            UIManager.Instance.HideWindow<EndPartWindow>();
            BoxManager.GetManager<AdManager>().ShowFullScreen();
        }

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