using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerHUD : MonoBehaviour
{
    public GameObject itemMessagePanel;
    public Image bloodOverlay;

    // private List<string> names = new List<string>();
    private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    private Color defaultColor;
    private float t;
    private bool isDamaged = false;

    [SerializeField] private float effectDuration = 1.2f;

    private void OnEnable()
    {
        AdventurerEvent.OnPlayerHurt += GotHurt;
        HUDEvent.OnShowMessage += ShowMessage;
        HUDEvent.OnCloseMessage += CloseMessage;
    }

    public void Start()
    {
        CloseMessage();
        if (bloodOverlay != null)
        {
            defaultColor = bloodOverlay.color;
            bloodOverlay.color = alphaColor;
        }
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
        if (isDamaged)
        {
            t += Time.deltaTime / 1f;
            bloodOverlay.color = Color.Lerp(default, alphaColor, t);
        }
    }

    public void GotHurt()
    {
        StartCoroutine("DamageEffect", effectDuration);
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

    private IEnumerator DamageEffect(float time)
    {
        isDamaged = true;
        bloodOverlay.color = defaultColor;
        yield return new WaitForSeconds(time);
        t = 0f;
        isDamaged = false;

    }

    private void OnDestroy()
    {
        AdventurerEvent.OnPlayerHurt -= GotHurt;
        HUDEvent.OnShowMessage -= ShowMessage;
        HUDEvent.OnCloseMessage -= CloseMessage;
    }
}
