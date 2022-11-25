using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tavern.Interactable 
{
    public class TavernDoor : InteractableItem
    {
        [SerializeField] private bool _isOpen;

        private string _interactText;
        private const string LevelToLoad = "CityHUB";

        private void Awake()
        {
            SetTexts();
        }

        public override void SetTexts()
        {
            if (GameManager.Language.Polish == GameManager.Instance.ReturnLanguage())
            {
                _interactText = LanguageText.Polish;
            }
            else
            {
                _interactText = LanguageText.English;
            }
        }

        public override void ShowInfo()
        {
            GameUI.HUDEvent.ShowMessage(_interactText);
        }

        public override void OnInteractPress()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z), Time.deltaTime * 50f);
            Tavern.Guests.GuestHandler.instance.OpenTavern();
            _isOpen = true;
        }

        public override void OnInteractHold()
        {
            if (_isOpen == false)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }
}
