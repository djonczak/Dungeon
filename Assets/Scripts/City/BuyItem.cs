using System;
using UnityEngine;

public class BuyItem : InteractableItem
{
    [SerializeField] private Item _item;
    private string _interactText;

    private void Start()
    {
        SetTexts();
    }

    public override void SetTexts()
    {
        if (GameManager.Language.Polish == GameManager.Instance.ReturnLanguage())
        {
            _interactText = LanguageText.Polish + _item.ItemName;
        }
        else
        {
            _interactText = LanguageText.English + _item.ItemName;
        }
    }

    public override void ShowInfo()
    {
        HUDEvent.ShowMessage(_interactText);
    }

    public override void OnInteractPress()
    {
        
    }
}
