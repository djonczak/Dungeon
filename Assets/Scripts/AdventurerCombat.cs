using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerCombat : MonoBehaviour
{
    public float attackSpeed;
    public float cooldownSpin;
    public Image furyBar;

    private float spinAttackCooldown = 0f;
    private float currentFuryMeter = 0f;
    private float furyMaxMeter = 100f;

    private AdventurerState state;
    private Animator anim;
    private float attackCooldown;
    private int comboMeter = 0;
    private bool nexAttack = true;
    public ParticleSystem weaponTrail;
    public ParticleSystem furryEffect;
    private float oldAttackDamge;
    private bool canUseFury;
    private bool isUsingFury;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        state = GetComponent<AdventurerState>();
        oldAttackDamge = state.attackDamage;
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (isUsingFury)
        {
            currentFuryMeter = (currentFuryMeter - Time.deltaTime) - 0.161f;
            furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
        }
    }

    public void LightAttack()
    {
        if (attackCooldown <= 0 && nexAttack == true)
        {
            StartCoroutine("Attack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void SpinAttackCooldown()
    {
        if(Time.time > spinAttackCooldown)
        {
            spinAttackCooldown = Time.time + cooldownSpin;
            StartCoroutine("SpinAttack");
        }
    }

    public void FuryMeter()
    {
        if(currentFuryMeter < furyMaxMeter  && isUsingFury == false)
        {
            currentFuryMeter += 4f;
            furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
        }
        else
        {
            canUseFury = true;
        }
    }

    public void ActivateFury()
    {
        if(canUseFury == true && isUsingFury == false)
        {
            StartCoroutine("Fury", 8f);
        }
    }

    private IEnumerator Attack()
    {
        weaponTrail.Play();
        nexAttack = false;
        StopCoroutine("ComboBreaker");
        state.isAttacking = true;
        comboMeter++;
        anim.SetTrigger("IsAttack" + comboMeter);
        if(comboMeter == 4)
        {
            state.attackDamage = state.attackDamage * 2f;
            Debug.Log("DMG " + state.attackDamage);
        }
        yield return new WaitForSeconds(0.7f);
        nexAttack = true;
        StartCoroutine("ComboBreaker");
        if (comboMeter == 4)
        {
            comboMeter = 0;
            state.attackDamage = oldAttackDamge;
            anim.SetBool("IsStance", false);
            state.isAttacking = false;
        }
    }

    private IEnumerator SpinAttack()
    {
        anim.SetTrigger("SpinAttack");
        state.isAttacking = true;
        yield return new WaitForSeconds(1.10f);
        state.isAttacking = false;
    }

    private IEnumerator Fury(float time)
    {
        furryEffect.Play();
        state.isAttacking = true;
        anim.SetTrigger("IsPowerUp");
        state.attackDamage = state.attackDamage * 3f;
        yield return new WaitForSeconds(2.35f);
        isUsingFury = true;
        state.isAttacking = false;
        yield return new WaitForSeconds(time);
        furryEffect.Stop();
        canUseFury = false;
        Debug.Log("Koniec Furri");
        state.attackDamage = oldAttackDamge;
        isUsingFury = false;
    }

    private IEnumerator ComboBreaker()
    {
        anim.SetBool("IsStance", true);
        anim.SetBool("IsRun", false);
        anim.SetBool("IsIdle", false);
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("IsStance", false);
        anim.SetBool("IsIdle", true);
        state.isAttacking = false;
        state.attackDamage = oldAttackDamge;
        comboMeter = 0;
    }
}
