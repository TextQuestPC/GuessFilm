using Data;
using NaughtyAttributes;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StoragePuzzleManager", menuName = "Managers/StoragePuzzleManager")]
    public class StoragePuzzleManager : BaseManager
    {
        [BoxGroup("Part_1")]
        [SerializeField] private PuzzleData[] part_1;

        private PuzzleData[] currentPart;
        private int counterParts;

        public PuzzleData[] GetCurrentPart { get => currentPart; }

        public override void OnInitialize()
        {
            // TODO: Load on save current part

            currentPart = part_1;
        }
    }
}
