using Data;
using NaughtyAttributes;
using SaveSystem;
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
            SavePartData[] saveParts = SaveLoadManager.Instance.GetPartsData();
            parts = new PartData[scro_parts.Length];

            // Load data parts from save
            if (saveParts != null && saveParts.Length > 0)
            {
                for (int i = 0; i < saveParts.Length; i++)
                {
                    SCRO_PartData needPart = null;

                    foreach (var scro_part in scro_parts)
                    {
                        if (scro_part.ID == saveParts[i].Id)
                        {
                            needPart = scro_part;
                        }
                    }

                    if (needPart == null)
                    {
                        LogManager.Instance.LogError($"Error. Not have SCRO_PartData with id {saveParts[i].Id}. ID from SavePartData");
                    }
                    else
                    {
                        parts[i] = new PartData(saveParts[i], needPart.PricePart, needPart.NamePart, needPart.SpritePart, needPart.PuzzlesData);
                    }
                }

                foreach (var part in parts)
                {
                    if (part.IsOpen)
                    {
                        if (currentPart == null)
                        {
                            currentPart = part;
                        }
                        else
                        {
                            if (currentPart.Id < part.Id)
                            {
                                currentPart = part;
                            }
                        }
                    }
                }
            }
            else // Create data parts from SCRO_PartData
            {
                for (int i = 0; i < scro_parts.Length; i++)
                {
                    parts[i] = new PartData(scro_parts[i]);
                }

                currentPart = parts[0];
            }
        }

        public void SelectNewPart(int numberPart)
        {
            foreach (var part in parts)
            {
                if (part.Id == numberPart)
                {
                    currentPart = part;
                    return;
                }
            }

            LogManager.Instance.LogError($"Not have part with number {numberPart}");
        }

        public void TryOpenPart(int numberPart)
        {
            PartData part = null;
            int points = BoxManager.GetManager<PointsManager>().GetPoints;

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Id == numberPart)
                {
                    part = parts[i];
                }
            }

            if (part != null)
            {
                if (part.PricePart <= points)
                {
                    BoxManager.GetManager<PointsManager>().SubtractPoints(part.PricePart);

                    part.SetIsOpen(true);
                    bool[] openParts = new bool[parts.Length];

                    for (int i = 0; i < parts.Length; i++)
                    {
                        openParts[i] = parts[i].IsOpen;
                    }

                    SaveParts();
                    UIManager.Instance.GetWindow<PartsWindow>().ChangeData();
                }
                else
                {
                    UIManager.Instance.ShowWindow<ShowAdWindow>();
                }
            }
            else
            {
                LogManager.Instance.LogError($"Not have part with number {numberPart}");
            }
        }

        private void SaveParts()
        {
            BoxManager.GetManager<SaveLoadManager>().Save();
        }
    }
}
