using Data;
using NaughtyAttributes;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StorageManager", menuName = "Managers/StorageManager")]
    public class StorageManager : BaseManager
    {
        [BoxGroup("Parts")]
        [SerializeField] private PartData[] parts;

        private PartData currentPart;

        public PartData GetCurrentPart { get => currentPart; }
        public PartData[] GetAllParts { get => parts; }

        public override void OnInitialize()
        {
            // TODO: Load on save current part

            currentPart = parts[0];
        }

        public void SelectNewPart(int numberPart)
        {
            foreach (var part in parts)
            {
                if (part.NumberPart == numberPart)
                {
                    currentPart = part;
                    return;
                }
            }

            BoxManager.GetManager<LogManager>().LogError($"Not have part with number {numberPart}");
        }
    }
}
