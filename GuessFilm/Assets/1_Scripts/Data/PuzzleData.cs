using NaughtyAttributes;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PuzzleData", menuName = "Data/PazzleData")]
    public class PuzzleData : ScriptableObject
    {
        [BoxGroup("Russian variants")]
        public string[] RussianVariants;
        [BoxGroup("English variants")]
        public string[] EnglishVariants;
        [BoxGroup("Sprite")]
        public Sprite Sprite;
        [BoxGroup("Points")]
        public int CountPoints = 10;
    }
}