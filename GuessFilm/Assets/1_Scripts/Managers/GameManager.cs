using Data;
using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : BaseManager
    {
        private TypeLanguage language;

        private PuzzleData[] currentPuzzles;
        private int counterPuzzle = 0;
        private string currentVariant;

        public override void OnInitialize()
        {
            // TODO: check language on device

            language = TypeLanguage.Russian;
        }

        public void StartGame()
        {
            NextPartPuzzles();
            NextVariant();
        }

        public void SelectVariantPart(string variant)
        {
            if(variant == currentVariant)
            {
                Debug.Log("Óדאהאכ");
            }
            else
            {
                Debug.Log("ÍÅ Óדאהאכ");
            }

            AfterSelectVariant();
        }

        private void NextPartPuzzles()
        {
            currentPuzzles = BoxManager.GetManager<StoragePuzzleManager>().GetCurrentPart;
            counterPuzzle = 0;
        }

        private void NextVariant()
        {
            PuzzleData data = currentPuzzles[counterPuzzle];
            string[] texts = null;

            if (language == TypeLanguage.Russian)
            {
                currentVariant = data.RussianVariants[0];
                texts = data.RussianVariants;
            }
            else if (language == TypeLanguage.English)
            {
                currentVariant = data.EnglishVariants[0];
                texts = data.EnglishVariants;
            }

            if (texts == null)
            {
                BoxManager.GetManager<LogManager>().LogError($"Texts variants = null! Number puzzle = {counterPuzzle}");

            }
            else
            {
                UIManager.Instance.GetWindow<VariantsWindow>().SetData(texts, data.Sprite);
            }
        }

        private void AfterSelectVariant()
        {
            counterPuzzle++;

            if(counterPuzzle >= currentPuzzles.Length)
            {
                NextPartPuzzles();
            }
            else
            {
                NextVariant();
            }
        }
    }
}