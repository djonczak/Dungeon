
public class ShowMapTrigger: InteractableItem
{
    private string _interactText;
    private void Start()
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
        WorlMapEvent.ShowMap();
    }
}
