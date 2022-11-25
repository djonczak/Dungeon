using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Tavern.UI {
    public class TavernUI : MonoBehaviour
    {
        //public enum Controller
        //{
        //    KEYBOARD,
        //    DUALSHOCK,
        //    XBOX,
        //    PROCONTROLLER,
        //};

        public GameObject itemMessagePanel;
        public GameObject fillCirclePanel;
        public Image fillCircle;
        public bool canFill;
        private float timeToFill = 3.1f;
        private float time = 0;
        // private List<string> names = new List<string>();

        private void OnEnable()
        {
            GameUI.HUDEvent.OnShowMessage += ShowMessage;
            GameUI.HUDEvent.OnCloseMessage += CloseMessage;
        }

        public void Start()
        {
            CloseMessage();
            CloseFillCircle();

            //foreach(string con in Input.GetJoystickNames())
            //{
            //    names.Add(con);
            //}

            //if(names.Contains("Wireless Controller"))
            //{
            //    Debug.Log("Dualshock");

            //}
        }

        public void ShowMessage(string text)
        {
            itemMessagePanel.SetActive(true);
            itemMessagePanel.GetComponentInChildren<Text>().text = text;
        }

        public void CloseMessage()
        {
            itemMessagePanel.SetActive(false);
        }

        public void ShowFillCircle()
        {
            if (canFill)
            {
                fillCirclePanel.SetActive(true);
            }
        }

        public void CloseFillCircle()
        {
            time = 0;
            fillCirclePanel.SetActive(false);
            canFill = false;
        }

        private void Update()
        {
            if (canFill)
            {
                if (time < timeToFill)
                {
                    time += Time.deltaTime;
                    fillCircle.fillAmount = time / timeToFill;
                }
            }
        }

        private void OnDestroy()
        {
            GameUI.HUDEvent.OnShowMessage -= ShowMessage;
            GameUI.HUDEvent.OnCloseMessage -= CloseMessage;
        }
    }
}
