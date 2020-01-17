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
    private NavMeshAgent ogr;
    private bool isAlive = true;
    public HPState phase;
    private bool doneRoar;

    public Image HPBar;
    public GameObject HPDisplay;

    //Changing color on damage
    private Color normal;
    private Color damageColor = Color.red;
    public Renderer meshRenderer;
    private bool isDamaged;
    private bool canColor;
    float t = 0f;
    private bool isInvincible;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ogr = GetComponent<NavMeshAgent>();
        normal = meshRenderer.material.color;

        anim.GetBehaviour<OgreCombat>().isAlive = true;
        currentHP = maxHP;
        HPDisplay.transform.rotation = Camera.main.transform.rotation;
    }

    void LateUpdate()
    {
        HPDisplay.transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        if (isAlive == true)
        {
            DamageColor();
        }
    }

    private void DamageColor()
    {
        if (canColor == true)
        {
            t += Time.deltaTime / 0.5f;
            if (isDamaged == true)
            {
                meshRenderer.material.color = Color.Lerp(damageColor, normal, t);
            }
        }
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
                    anim.GetBehaviour<OgreCombat>().isAlive = false;
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
        canColor = true;
        isDamaged = true;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        t = 0f;
        canColor = false;
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
                ogr.speed = 0f;
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
