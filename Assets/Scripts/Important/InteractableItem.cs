using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public LanguageText LanguageText;

    public virtual void SetTexts() { }

    public virtual void OnInteractPress() { }

    public virtual void OnInteractHold() { }

    public virtual void ShowInfo() { }
}
