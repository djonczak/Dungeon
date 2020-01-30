using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class OgreHealth : LivingCreature, IDamage
{
    public enum HPState
    {
        Full,
        Half,
    };

    private Animator anim;
    public HPState phase;
    private bool doneRoar;

    public Image HPBar;
    public GameObject HPDisplay;

    private bool isInvincible;
    private bool isDamaged;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

        currentHP = maxHP;
        HPDisplay.transform.rotation = Camera.main.transform.rotation;
    }

    void LateUpdate()
    {
        HPDisplay.transform.rotation = Quaternion.identity;
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isInvincible == false)
        {
            if (isDamaged == false)
            {
                currentHP -= amount;
                ShowDamageText(amount);
                HPBar.fillAmount = currentHP / maxHP;
                if (currentHP <= 0)
                {
                    Die();
                }

                if (phase == HPState.Full)
                {
                    CheckHPState();
                }
                StartCoroutine("Damaged");
            }
        }
    }

    private void Die()
    {
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("IsDead");
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        HPDisplay.SetActive(false);
        this.enabled = false;
    }

    private IEnumerator Damaged()
    {
        isDamaged = true;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }

    public void EndRoar()
    {
        anim.SetBool("IsRun",true);
        isInvincible = false;
        doneRoar = true;
    }

    private void CheckHPState()
    {
        var hpPercent = (100f / maxHP) * currentHP;
        if(hpPercent > 51)
        {
            phase = HPState.Full;
        }
        else
        {
            phase = HPState.Half;
            if(doneRoar == false)
            {
                isInvincible = true;
                anim.SetTrigger("IsSecondPhase");
                anim.SetBool("IsFollow", false);
                anim.SetBool("IsCombat", false);
            }
        }
    }

    private void ShowDamageText(float amount)
    {
        GameObject damageText = ObjectPooler.instance.GetPooledObject("DamageText");
        damageText.transform.position = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
        damageText.transform.rotation = Camera.main.transform.rotation;
        damageText.SetActive(true);
        damageText.GetComponent<TextMesh>().text = "-" + amount.ToString();
    }
}
