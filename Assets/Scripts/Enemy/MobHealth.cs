using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MobHealth : LivingCreature, IDamage
{
    public bool isAlive = true;

    private bool isDamaged = false;

    public Image HPBar;
    public GameObject HPDisplay;

    private void Start()
    {
        currentHP = maxHP;
        HPDisplay.transform.rotation = Camera.main.transform.rotation;
        GetComponentInChildren<IPassFloat>().PassFloat(attackDamage);
    }

    private void LateUpdate()
    {
        HPDisplay.transform.rotation = Quaternion.identity;
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isDamaged == false)
        {
            currentHP -= amount;
            HPBar.fillAmount = currentHP / maxHP;
            GetComponent<IDamageEffect>().DamageEffect();
            ShowDamageText(amount);
            if (currentHP <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine("Damaged");
                GetComponent<KnockBack>().KnockBackEffect(position);
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
        HPDisplay.SetActive(false);
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
