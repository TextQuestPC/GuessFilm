using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PartData", menuName = "Data/PartData")]
    public class PartData : ScriptableObject
    {
        public bool IsOpen = false;
        public int PricePart;
        public int NumberPart;
        public string NamePart;
        public Sprite SpritePart;

        public PuzzleData[] PuzzlesData;
    }
}