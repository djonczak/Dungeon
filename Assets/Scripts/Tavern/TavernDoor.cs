using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernDoor : InteractableItem
{
    [SerializeField] private bool isOpen;

    private string _interactText;
    private const string _levelToLoad = "CityHUB";

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
        HUDEvent.ShowMessage(_interactText);  
    }

    public override void OnInteractPress()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z), Time.deltaTime * 50f);
        GuestHandler.instance.OpenTavern();
        isOpen = true;
    }

    public override void OnInteractHold()
    {
        if (isOpen == false)
        {
            SceneManager.LoadScene(_levelToLoad);
        }  
    }
}
