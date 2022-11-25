using UnityEngine.SceneManagement;

namespace Tavern.Interactable
{
    public class ExitTavern : InteractableItem
    {
        private string _interactText;

        private const string CityHub = "CityHUB";
        public override void ShowInfo()
        {
            GameUI.HUDEvent.ShowMessage(_interactText);
        }

        public override void OnInteractPress()
        {
            SceneManager.LoadScene(CityHub);
        }
    }
}
