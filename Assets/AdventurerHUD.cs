using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerHUD : MonoBehaviour
{
    public GameObject itemMessagePanel;
    public Image fog;

    private bool canColor;

    private Color fogMainColor;
    private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    private float t;
    // private List<string> names = new List<string>();

    public void Start()
    {
        if (fog != null)
        {
            fogMainColor = fog.color;
            fog.enabled = false;
        }
        CloseMessage();

        //foreach(string con in Input.GetJoystickNames())
        //{
        //    names.Add(con);
        //}

        //if(names.Contains("Wireless Controller"))
        //{
        //    Debug.Log("Dualshock");

        //}
    }

    private void Update()
    {
        if (canColor)
        {
            t += Time.deltaTime / 1f;
            fog.color = Color.Lerp(fogMainColor, alphaColor, t);
        }
    }

    public void FogDisperse()
    {
        StartCoroutine("FogDisperseTimer");
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

    private IEnumerator FogDisperseTimer()
    {
        fog.enabled = true;
        yield return new WaitForSeconds(1f);
        canColor = true;
        yield return new WaitForSeconds(1.5f);
        canColor = false;
        t = 0f;
        fog.enabled = false;
        fog.color = fogMainColor;
    }

}
