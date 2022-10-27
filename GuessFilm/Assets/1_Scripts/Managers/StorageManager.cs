using Data;
using NaughtyAttributes;
using Save;
using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StorageManager", menuName = "Managers/StorageManager")]
    public class StorageManager : BaseManager
    {
        [BoxGroup("Parts")]
        [SerializeField] private SCRO_PartData[] scro_parts;

        private PartData[] parts;
        private PartData currentPart;

        public PartData GetCurrentPart { get => currentPart; }
        public PartData[] GetAllParts { get => parts; }

        public override void OnInitialize()
        {
            SavePartData[] saveParts = BoxManager.GetManager<SaveLoadManager>().GetPartsData;

            // Load data parts from save
            if (saveParts.Length > 0)
            {
                for (int i = 0; i < saveParts.Length; i++)
                {
                    SCRO_PartData needPart = null;

                    foreach (var scro_part in scro_parts)
                    {
                        if(scro_part.ID == saveParts[i].ID)
                        {
                            needPart = scro_part;
                        }
                    }

                    if(needPart == null)
                    {
                        BoxManager.GetManager<LogManager>().LogError($"Error. Not have SCRO_PartData with id {saveParts[i].ID}. ID from SavePartData");
                    }
                    else
                    {
                        PartData partData = new PartData(saveParts[i], needPart.PricePart, needPart.NamePart, needPart.SpritePart, needPart.PuzzlesData);
                    }
                }
            }
            else // Create data parts from SCRO_PartData
            {
                parts = new PartData[scro_parts.Length];

                for (int i = 0; i < scro_parts.Length; i++)
                {
                    parts[i] = new PartData(scro_parts[i]);
                }

                currentPart = parts[0];
            }
        }

        public void SetDataOpenParts(SavePartData[] openParts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].PricePart == 0)
                {
                    parts[i].IsOpen = true;
                }
                else
                {
                    if (i < openParts.Length - 1)
                    {
                        parts[i].IsOpen = openParts[i].IsOpen;
                    }
                    else
                    {
                        parts[i].IsOpen = false;
                    }
                }
            }
        }

        public void SelectNewPart(int numberPart)
        {
            foreach (var part in parts)
            {
                if (part.ID == numberPart)
                {
                    currentPart = part;
                    return;
                }
            }

            BoxManager.GetManager<LogManager>().LogError($"Not have part with number {numberPart}");
        }

        public void TryOpenPart(int numberPart)
        {
            SCRO_PartData part = null;
            int points = BoxManager.GetManager<PointsManager>().GetPoints;

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].ID == numberPart)
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

                    SaveParts();
                    UIManager.Instance.GetWindow<PartsWindow>().ChangeData();
                }
            }
            else
            {
                BoxManager.GetManager<LogManager>().LogError($"Not have part with number {numberPart}");
            }
        }

        private void SaveParts()
        {
            BoxManager.GetManager<SaveLoadManager>().SaveOpenPart(parts);
        }
    }
}
