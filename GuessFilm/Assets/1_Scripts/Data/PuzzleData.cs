using NaughtyAttributes;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SCRO_PuzzleManager", menuName = "Data/PazzleData")]
    public class PuzzleData : ScriptableObject
    {
        [BoxGroup("Russian variants")]
        public string[] RussianVariants;
        [BoxGroup("English variants")]
        public string[] EnglishVariants;
        [BoxGroup("Sprite")]
        public Sprite Sprite;
    }
}