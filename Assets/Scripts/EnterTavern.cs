using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTavern : InteractableItem
{
    private const string _tavern = "Tavern";
    private string _interactText;

    private void Start()
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
        SceneManager.LoadScene(_tavern);
    }
}
