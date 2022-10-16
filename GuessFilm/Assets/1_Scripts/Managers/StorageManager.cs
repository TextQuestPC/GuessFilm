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

        public void SetDataOpenParts(bool[] openParts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                if(parts[i].PricePart == 0)
                {
                    parts[i].IsOpen = true;
                }
                else
                {
                    parts[i].IsOpen = openParts[i];
                }
            }
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
