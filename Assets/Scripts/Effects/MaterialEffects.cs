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

    private const string Emission = "_EMISSION";
    private const string EmissionColor = "_EmissionColor";
    private void Start()
    {
        bodyMaterial.material.EnableKeyword(Emission);
    }

    private void Update()
    {
        ColorFlick();
    }

    private void ColorFlick()
    {
        if (_colorFlick)
        {
            var indicatorColor = Color.Lerp(Color.white, _alphaColor, Mathf.PingPong(Time.time, 1));
            bodyMaterial.material.SetColor(EmissionColor, indicatorColor);
        }
    }

    public void DamageEffect()
    {
        StartCoroutine(EffectDuration(_effectDuration));
    }

    public void FlickEffect()
    {
        _colorFlick = true;
    }

    private IEnumerator EffectDuration(float time)
    {
        _isDamaged = true;
        var timer = 0f;
        while(timer < time)
        {
            var colorChange = Color.Lerp(_damageColor, _alphaColor, timer / time);
            bodyMaterial.material.SetColor(EmissionColor, colorChange);
            timer += Time.deltaTime;
            yield return null;
        }
        _isDamaged = false;
    }
}
