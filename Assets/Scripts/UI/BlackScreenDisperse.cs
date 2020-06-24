using System.Collections;
using UnityEngine;

public class BlackScreenDisperse : MonoBehaviour
{
    public UnityEngine.UI.Image blackScreen;

    [SerializeField] private Color _fogMainColor;
    [SerializeField] private Color _alphaColor = new Color(0f, 0f, 0f, 0f);
    [SerializeField] private bool _canColor;
    [SerializeField] private float _disperseTime = 1f;
    private float _t;

    private void OnEnable()
    {
        BlackScreenEvent.OnDisperseBlackScreen += Disperse;
    }

    private void Start()
    {
        if (blackScreen != null)
        {
            _fogMainColor = blackScreen.color;
            blackScreen.enabled = false;
        }
    }

    private void Update()
    {
        if (_canColor)
        {
            _t += Time.deltaTime / 1f;
            blackScreen.color = Color.Lerp(_fogMainColor, _alphaColor, _t);
        }
    }

    public void Disperse()
    {
        StartCoroutine(DisperseTimer(_disperseTime));
    }

    private IEnumerator DisperseTimer(float time)
    {
        blackScreen.enabled = true;
        yield return new WaitForSeconds(time);
        _canColor = true;
        yield return new WaitForSeconds(time);
        _canColor = false;
        _t = 0f;
        blackScreen.enabled = false;
        blackScreen.color = _fogMainColor;
    }

    private void OnDestroy()
    {
        BlackScreenEvent.OnDisperseBlackScreen -= Disperse;
    }
}
