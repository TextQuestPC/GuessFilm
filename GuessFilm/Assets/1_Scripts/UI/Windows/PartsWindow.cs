using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PartsWindow : Window
    {
        [SerializeField]private PartButton[] partButtons;
        [SerializeField] private Button startGameButton;

        private PartButton currentButton;

        protected override void AfterInitialization()
        {
            startGameButton.onClick.AddListener(ClickStartGame);
        }

        protected override void AfterShow()
        {
            ChangeData();

            currentButton = partButtons[0];
            currentButton.SelectButton();
        }

        public void ChangeData()
        {
            PartData[] parts = BoxManager.GetManager<StorageManager>().GetAllParts;

            for (int i = 0; i < partButtons.Length; i++)
            {
                if (i < parts.Length)
                {
                    partButtons[i].SetData(parts[i]);
                }
                else
                {
                    partButtons[i].gameObject.SetActive(false);
                }
            }
        }

        public void SelectPart(PartButton button, int numberButton)
        {
            currentButton.CancelSelectButton();
            currentButton = button;
            currentButton.SelectButton();

            BoxManager.GetManager<StorageManager>().SelectNewPart(numberButton);
        }

        private void ClickStartGame()
        {
            BoxManager.GetManager<GameManager>().StartGame();
        }
    }
}