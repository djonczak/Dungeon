using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MobHealth : LivingCreature, IDamage
{
    private bool isDamaged = false;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isDamaged == false)
        {
            currentHP -= amount;
            GetComponent<IDamageEffect>().DamageEffect();
            ShowDamageText(amount);
            GetComponentInChildren<MobHealthBar>().ChangeHPBar(currentHP, maxHP);
            if (currentHP <= 0)
            {
                Die();
            }
            else
            {
                GetComponent<KnockBack>().KnockBackEffect(position);
                StartCoroutine("Damaged");
            }
        }
    }

    private void Die()
    {
        DeathEvent.EnemyDied(id);
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().SetTrigger("IsDead");
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        enabled = false;
    }

    private void ShowDamageText(float amount)
    {
        GameObject damageText = ObjectPooler.instance.GetPooledObject("DamageText");
        if (damageText != null)
        {
            damageText.transform.position = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
            damageText.transform.rotation = Camera.main.transform.rotation;
            damageText.SetActive(true);
            damageText.GetComponent<TextMesh>().text = "-" + amount.ToString();
        }
    }

    private IEnumerator Damaged()
    {
        isDamaged = true;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }
}
