using System.Collections;
using UnityEngine;

public class MaterialEffects : MonoBehaviour, IDamageEffect
{
    public Renderer bodyMaterial;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    [SerializeField] private bool isDamaged = false;
    [SerializeField] private float effectDuration = 1.2f;
    private float t;

    private void Start()
    {
        bodyMaterial.material.EnableKeyword("_EMISSION");
    }

    private void Update()
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

    private IEnumerator EffectDuration(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        t = 0f;
        isDamaged = false;
    }
}
