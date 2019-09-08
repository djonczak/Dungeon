using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SkeletonHealth : LivingCreature, IDamage
{
    private Animator anim;
    private bool isAlive = true;
    private Rigidbody body;

    private Color normal;
    private Color damageColor = Color.red;
    private Renderer meshRenderer;
    private bool isDamaged = false;
    private bool canColor;
    float t = 0f;
    public Image HPBar;
    public GameObject HPDisplay;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody>();
        meshRenderer = GetComponentInChildren<Renderer>();
        normal = meshRenderer.material.color;

        currentHP = maxHP;
        HPDisplay.transform.rotation = Camera.main.transform.rotation;
        anim.GetBehaviour<SkeletonCombat>().isAlive = true;
        anim.GetBehaviour<AIFollow>().isAlive = true;
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
        if (isDamaged == false)
        {
            currentHP -= amount;
            HPBar.fillAmount = currentHP / maxHP;
            ShowDamageText(amount);
            if (currentHP <= 0)
            {
                anim.GetBehaviour<SkeletonCombat>().isAlive = false;
                anim.GetBehaviour<AIFollow>().isAlive = false;
                Die();
            }
            else
            {
                StartCoroutine("Damaged");
                KnockBack(position);
            }
        }
    }

    void Die()
    {
        DeathEvent.EnemyDied(id);
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("IsDead");
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        HPDisplay.SetActive(false);
        this.enabled = false;
    }

    private void ShowDamageText(float amount)
    {
        GameObject damageText = ObjectPooler.instance.GetPooledObject("DamageText");
        damageText.transform.position = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
        damageText.transform.rotation = Camera.main.transform.rotation;
        damageText.SetActive(true);
        damageText.GetComponent<TextMesh>().text = "-" + amount.ToString();
    }

    private void KnockBack(Vector3 position)
    {
        var direction = (transform.position - position).normalized;

        body.AddForce(body.velocity + direction * 22f, ForceMode.Impulse);
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
}
