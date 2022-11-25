using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tavern.Interactable
{
    public class Mug : InteractableItem
    {
        public float amountToFill;
        public bool isDirty;
        public bool isFull;

        public Canvas canvas;
        public Transform emptyMug;
        public Transform fullMug;

        private Transform parent;
        private string _interactText;

        private void Awake()
        {
            SetTexts();
        }

        private void Start()
        {
            parent = transform.parent;
            emptyMug.gameObject.SetActive(true);
            fullMug.gameObject.SetActive(false);
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

        private void LateUpdate()
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }

        public void FillMug(BeerKeg keg)
        {
            if (isFull == false)
            {
                keg.FillMug(amountToFill);
                isFull = true;
                fullMug.gameObject.SetActive(true);
                emptyMug.gameObject.SetActive(false);
            }
        }

        public void DirtyMug()
        {
            transform.parent = parent;
            isFull = false;
            isDirty = true;
            fullMug.gameObject.SetActive(false);
            emptyMug.gameObject.SetActive(true);
        }
    }
}
