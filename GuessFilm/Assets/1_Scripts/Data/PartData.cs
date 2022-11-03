using SaveSystem;
using UnityEngine;

namespace Data
{
    public class PartData
    {
        public int Id { get; private set; }
        public bool IsOpen { get; private set; }
        public int PricePart { get; private set; }
        public string NamePart { get; private set; }
        public Sprite SpritePart { get; private set; }
        public PuzzleData[] PuzzlesData { get; private set; }
        public bool[] GuessPuzzle { get; private set; }

        public PartData(SCRO_PartData partData)
        {
            Id = partData.ID;
            IsOpen = partData.IsOpen;
            PricePart = partData.PricePart;
            NamePart = partData.name;
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
    }
}