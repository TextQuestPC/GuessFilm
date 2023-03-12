using SaveSystem;
using UnityEngine;

namespace Data
{
    public class PartData
    {
        public int Id { get; private set; }
        public bool IsOpen { get; private set; }
        public int PricePart { get; private set; }
        private string NamePart;
        public string NameUi { get; private set; }
        public Sprite SpritePart { get; private set; }
        public PuzzleData[] PuzzlesData { get; private set; }
        public bool[] GuessPuzzle { get; private set; }

        public PartData(SCRO_PartData partData)
        {
            Id = partData.ID;
            IsOpen = partData.IsOpen;
            PricePart = partData.PricePart;
            NamePart = partData.NamePart;
            NameUi = Localizator.Instance.GetTextUI(NamePart);
            SpritePart = partData.SpritePart;
            PuzzlesData = partData.PuzzlesData;
            GuessPuzzle = new bool[PuzzlesData.Length];

            for (int i = 0; i < GuessPuzzle.Length; i++)
            {
                GuessPuzzle[i] = false;
            }
        }

        public PartData(SavePartData saveData, int pricePart, string namePart, Sprite spritePart, PuzzleData[] puzzleData)
        {
            Id = saveData.Id;
            IsOpen = saveData.IsOpen;
            GuessPuzzle = saveData.GuessPuzzle;
            PricePart = pricePart;
            NamePart = namePart;
            NameUi = Localizator.Instance.GetTextUI(NamePart);
            SpritePart = spritePart;
            PuzzlesData = puzzleData;
        }

        public void AddGuessPuzzle(int number)
        {
            GuessPuzzle[number] = true;
        }

        public void SetIsOpen(bool value)
        {
            IsOpen = value;
        }

        public void ChangeLanguage()
        {
            NameUi = Localizator.Instance.GetTextUI(NamePart); 
        }

        //public void SaveScore(int score)
        //{
        //    PlayerPrefs.SetInt("Score", score);
        //}
        //public int LoadScore()
        //{
        //    if (PlayerPrefs.HasKey("Score"))
        //    {
        //        return PlayerPrefs.GetInt("Score");
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}