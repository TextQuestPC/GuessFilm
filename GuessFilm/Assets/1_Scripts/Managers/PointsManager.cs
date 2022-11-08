using SaveSystem;
using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "PointsManager", menuName = "Managers/PointsManager")]
    public class PointsManager : BaseManager
    {
        private int points = 0, currentPoints;

        public int GetPoints { get => points; }

        public int CurrentPoints { get => currentPoints; set => currentPoints = value; }

        public override void OnInitialize()
        {
            points = SaveLoadManager.Instance.GetPoints();
        }

        public void AddPoints(int value)
        {
            points += value;
            currentPoints += value;

            int countCoins = value / 5;

            UIManager.Instance.GetWindow<UI_Window>().ShowUpPoints(points, countCoins);
            SaveLoadManager.Instance.Save();
        }

        public void SubtractPoints(int value)
        {
            points -= value;

            UIManager.Instance.GetWindow<UI_Window>().ShowDownPoints(points);
            SaveLoadManager.Instance.Save();
        }
    }
}