using System.Collections;
using UnityEngine;

public class BlackScreenDisperse : MonoBehaviour
{
    public UnityEngine.UI.Image blackScreen;

    [SerializeField] private Color fogMainColor;
    [SerializeField] private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    [SerializeField] private bool canColor;
    [SerializeField] private float disperseTime = 1f;
    private float t;

    private void OnEnable()
    {
        BlackScreenEvent.OnDisperseBlackScreen += Disperse;
    }

    private void Start()
    {
        if (blackScreen != null)
        {
            fogMainColor = blackScreen.color;
            blackScreen.enabled = false;
        }
    }

    private void Update()
    {
        if (canColor)
        {
            t += Time.deltaTime / 1f;
            blackScreen.color = Color.Lerp(fogMainColor, alphaColor, t);
        }
    }

    public void Disperse()
    {
        StartCoroutine("DisperseTimer", disperseTime);
    }

    private IEnumerator DisperseTimer(float time)
    {
        blackScreen.enabled = true;
        yield return new WaitForSeconds(time);
        canColor = true;
        yield return new WaitForSeconds(time);
        canColor = false;
        t = 0f;
        blackScreen.enabled = false;
        blackScreen.color = fogMainColor;
    }

    private void OnDestroy()
    {
        BlackScreenEvent.OnDisperseBlackScreen -= Disperse;
    }
}
