using System.Collections;
using UnityEngine;

public class MaterialEffects : MonoBehaviour, IDamageEffect
{
    public Renderer bodyMaterial;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    [SerializeField] private bool isDamaged = false;
    [SerializeField] private bool colorFlick = false;
    [SerializeField] private float effectDuration = 1.2f;
    private float t;


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
        if (colorFlick)
        {
            var indicatorColor = Color.Lerp(Color.white, alphaColor, Mathf.PingPong(Time.time, 1));
            bodyMaterial.material.SetColor("_EmissionColor", indicatorColor);
        }
    }

    private void DamagedColorChange()
    {
        if (isDamaged)
        {
            t += Time.deltaTime / effectDuration;
            var colorChange = Color.Lerp(damageColor, alphaColor, t);
            bodyMaterial.material.SetColor("_EmissionColor", colorChange);
        }
    }

    public void DamageEffect()
    {
        StartCoroutine("EffectDuration", effectDuration);
    }

    public void FlickEffect()
    {
        colorFlick = true;
    }

    private IEnumerator EffectDuration(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        t = 0f;
        isDamaged = false;
    }
}
