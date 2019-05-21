using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerState : LivingCreature, IDamage
{
    public float currentHP;
    public bool isAttacking;
    public bool isAlive = true;
    private Animator anim;
    public Image bloodOverlay;
    public Image HPBar;

    private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    private Color normalColor;
    private bool isDamaged;
    private float t;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = amountHP;
        normalColor = bloodOverlay.color;
        bloodOverlay.color = alphaColor;
    }

    void Update()
    {
        if (isDamaged)
        {
            t += Time.deltaTime / 1f;
            bloodOverlay.color = Color.Lerp(normalColor, alphaColor, t);
        }
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        currentHP -= amount;
        HPBar.fillAmount = currentHP / amountHP;
        StartCoroutine("DamageEffect");
        AdventurerCameraController.instance.StartCoroutine("CameraShake");
       if(currentHP <= 0)
        {
            StopCoroutine("DamageEffect");
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Umarł");
        isAlive = false;
        anim.SetTrigger("IsDead");
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
