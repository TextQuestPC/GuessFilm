using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "PointsManager", menuName = "Managers/PointsManager")]
    public class PointsManager : BaseManager
    {
        private int points = 0;

        public int GetPoints { get => points; }

        public void AddPoints(int value)
        {
            points += value;

            UIManager.Instance.GetWindow<UI_Window>().ShowPoints(points);
            BoxManager.GetManager<SaveLoadManager>().SavePoints(points);
        }

        public void SubtractPoints(int value)
        {
            points -= value;

            UIManager.Instance.GetWindow<UI_Window>().ShowPoints(points);
            BoxManager.GetManager<SaveLoadManager>().SavePoints(points);
        }

        public bool CanOpenPart(int numberPart)
        {
            // int pricePart

            return true;
        }
    }
}