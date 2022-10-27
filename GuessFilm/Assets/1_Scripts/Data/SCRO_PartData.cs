using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PartData", menuName = "Data/PartData")]
    public class SCRO_PartData : ScriptableObject
    {
        public int ID;
        public bool IsOpen;
        public int PricePart;
        public string NamePart;
        public Sprite SpritePart;

        public PuzzleData[] PuzzlesData;
    }
}