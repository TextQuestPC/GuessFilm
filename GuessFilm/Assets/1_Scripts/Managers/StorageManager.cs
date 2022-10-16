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
            currentPart = parts[0];
        }

        public void SetDataOpenParts(bool[] openParts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].PricePart == 0)
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

        public void TryOpenPart(int numberPart)
        {
            PartData part = null;
            int points = BoxManager.GetManager<PointsManager>().GetPoints;

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].NumberPart == numberPart)
                {
                    part = parts[i];
                }
            }

            if (part != null)
            {
                if (part.PricePart <= points)
                {
                    BoxManager.GetManager<PointsManager>().SubtractPoints(part.PricePart);

                    part.IsOpen = true;
                    bool[] openParts = new bool[parts.Length];

                    for (int i = 0; i < parts.Length; i++)
                    {
                        openParts[i] = parts[i].IsOpen;
                    }

                    BoxManager.GetManager<SaveLoadManager>().SaveOpenPart(openParts);
                }
            }
            else
            {
                BoxManager.GetManager<LogManager>().LogError($"Not have part with number {numberPart}");
            }
        }
    }
}
