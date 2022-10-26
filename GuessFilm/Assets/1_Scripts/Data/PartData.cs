using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PartData", menuName = "Data/PartData")]
    public class PartData : ScriptableObject
    {
        [HideInInspector]
        public bool IsOpen;
        public int PricePart;
        public int NumberPart;
        public string NamePart;
        public Sprite SpritePart;

        public PuzzleData[] PuzzlesData;
    }
}