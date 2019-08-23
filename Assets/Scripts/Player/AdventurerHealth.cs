using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerHealth : MonoBehaviour, IDamage
{
    public float maxHP;
    private float currentHP;
    public bool isAlive = true;
    private Animator anim;
    public Image bloodOverlay;
    public Image HPBar;
    public Renderer bodyColor;

    private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    private Color normalColor;
    private bool isDamaged;
    private float t;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = maxHP;
        normalColor = bloodOverlay.color;
        bloodOverlay.color = alphaColor;
        bodyColor.material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (isDamaged)
        {
            t += Time.deltaTime / 1f;
            bloodOverlay.color = Color.Lerp(normalColor, alphaColor, t);
            var damageColor = Color.Lerp(Color.white, alphaColor, t);
            bodyColor.material.SetColor("_EmissionColor", damageColor);
        }
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isDamaged == false)
        {
            currentHP -= amount;
            HPBar.fillAmount = currentHP / maxHP;
            StartCoroutine("DamageEffect");
            AdventurerCameraController.instance.StartCoroutine("CameraShake");
            if (currentHP <= 0)
            {
                StopCoroutine("DamageEffect");
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Umarł");
        isAlive = false;
        anim.SetTrigger("Dead");
        GetComponent<AdventurerController>().enabled = false;
    }

    IEnumerator DamageEffect()
    {
        bloodOverlay.color = normalColor;
        isDamaged = true;
        yield return new WaitForSeconds(1.2f);
        t = 0f;
        isDamaged = false;
    }
}
