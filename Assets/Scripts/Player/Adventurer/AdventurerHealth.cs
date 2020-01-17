using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerHealth : MonoBehaviour, IDamage
{
    public float maxHP;
    private float currentHP;
    public bool isAlive = true;
    private Animator anim;
    public Image HPBar;

    private bool isDamaged = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isDamaged == false)
        {
            currentHP -= amount;
            HPBar.fillAmount = currentHP / maxHP;
            StartCoroutine("DamageCooldown",1f);
            GetComponent<IDamageEffect>().DamageEffect();
            AdventurerEvent.PlayerHit();
            CheckIfAlive();
        }
    }

    private void CheckIfAlive()
    {
        if (currentHP <= 0)
        {
            StopCoroutine("DamageEffect");
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        anim.SetTrigger("Dead");
        GetComponent<AdventurerController>().enabled = false;
    }

    private IEnumerator DamageCooldown(float time)
    {
        isDamaged = true;
        yield return new WaitForSeconds(time);
        isDamaged = false;
    }
}
