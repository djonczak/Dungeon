using UnityEngine;

public class EnterBuilding : InteractableItem
{
    [SerializeField] private bool _inBuilding = false;
    [SerializeField] private Transform _outSidePoint;
    [SerializeField] private Transform _inSidesPoint;

    [SerializeField] private GameObject _outsideArea;
    [SerializeField] private GameObject _insideArea;

    private string _interactTextIn;
    private string _interactTextOut;
    private void Start()
    {
        _insideArea.SetActive(false);
        SetTexts();
    }

    public override void SetTexts()
    {
        if (GameManager.Language.Polish == GameManager.Instance.ReturnLanguage())
        {
            var language = StringExtension.CutString(LanguageText.Polish);
            _interactTextOut = language[0];
            _interactTextIn = language[1];
        }
        else
        {
            var language = StringExtension.CutString(LanguageText.English);
            _interactTextOut = language[0];
            _interactTextIn = language[1];
        }
    }

    public override void ShowInfo()
    {
        if (_inBuilding == false)
        {
            HUDEvent.ShowMessage(_interactTextIn);
        }
        else
        {
            HUDEvent.ShowMessage(_interactTextOut);
        }
    }

    public override void OnInteractPress()
    {
        if(_inBuilding == false)
        {
            GoInside();
        }
        else
        {
            GoOut();
        }
    }

    private void GoOut()
    {
        _inBuilding = false;
        _insideArea.SetActive(false);
        _outsideArea.SetActive(true);
        PlayerExtension.GetPlayerObject().transform.position = _outSidePoint.position;
        BlackScreenEvent.ShowBlackScreen();
        DayNightCycleEvent.SwitchLight(); 
    }

    private void GoInside()
    {
        _inBuilding = true;
        _insideArea.SetActive(true);
        _outsideArea.SetActive(false);
        PlayerExtension.GetPlayerObject().transform.position = _inSidesPoint.position;
        BlackScreenEvent.ShowBlackScreen();
        DayNightCycleEvent.SwitchLight();
    }
}
