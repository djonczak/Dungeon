using System.Collections;
using UnityEngine;

public class MaterialEffects : MonoBehaviour, IDamageEffect
{
    public Renderer bodyMaterial;
    [SerializeField] private Color _damageColor = Color.red;
    private Color _alphaColor = new Color(0f, 0f, 0f, 0f);
    private bool _isDamaged = false;
    private bool _colorFlick = false;
    [SerializeField] private float _effectDuration = 1.2f;
    private float _t;

    private void Start()
    {
        bodyMaterial.material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        DamagedColorChange();
        ColorFlick();
    }

    private void ColorFlick()
    {
        if (_colorFlick)
        {
            var indicatorColor = Color.Lerp(Color.white, _alphaColor, Mathf.PingPong(Time.time, 1));
            bodyMaterial.material.SetColor("_EmissionColor", indicatorColor);
        }
    }

    private void DamagedColorChange()
    {
        if (_isDamaged)
        {
            _t += Time.deltaTime / _effectDuration;
            var colorChange = Color.Lerp(_damageColor, _alphaColor, _t);
            bodyMaterial.material.SetColor("_EmissionColor", colorChange);
        }
    }

    public void DamageEffect()
    {
        StartCoroutine("EffectDuration", _effectDuration);
    }

    public void FlickEffect()
    {
        _colorFlick = true;
    }

    private IEnumerator EffectDuration(float time)
    {
        _isDamaged = true;
        yield return new WaitForSeconds(time);
        _t = 0f;
        _isDamaged = false;
    }
}
