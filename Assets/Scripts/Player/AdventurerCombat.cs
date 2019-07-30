using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerCombat : MonoBehaviour
{
    [SerializeField] private float boltDamage;
    [SerializeField] private float boltSpeed;
    public float cooldownSpin;
    public Image furyBar;
    public GameObject[] weaponList;
    public Transform crossbowBarrel;

    private float currentFuryMeter = 0f;
    private float furyMaxMeter = 100f;
    private AdventurerState state;
    private Animator anim;
    private int comboMeter = 0;
    private bool nexAttack = true;
    public ParticleSystem weaponTrail;
    public ParticleSystem furryEffect;
    private bool canUseFury;
    private bool isUsingFury;
    [SerializeField] private AudioSource sound;
    public AudioClip[] fightSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        state = GetComponent<AdventurerState>();
        state.isMelee = true;
        weaponList[1].SetActive(false);
    }

    private void Update()
    {
        if (isUsingFury)
        {
            currentFuryMeter = (currentFuryMeter - Time.deltaTime) - 0.161f;
            furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
        }
    }

    public void SwitchWeapon()
    {
        state.isMelee = !state.isMelee;
        Debug.Log("Zmiana");
        if (nexAttack == true)
        {
            if (state.isMelee)
            {
                weaponList[0].SetActive(true);
                weaponList[1].SetActive(false);
            }
            else
            {
                weaponList[0].SetActive(false);
                weaponList[1].SetActive(true);
            }
        }
    }

    public void EndAttack()
    {
        weaponList[0].GetComponent<BoxCollider>().enabled = false;
        if (comboMeter == 2)
        {
            comboMeter = 0;
        }
        nexAttack = true;
        Debug.Log("Może działa");
    }

    public void Attack()
    {
        if (state.isMelee == true)
        {
            MeleeAttack();
        }
        else
        {
            CrossbowAttack();
            Debug.Log("Crosbow Attack");
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Melee Attack");
        if (nexAttack == true)
        {
            weaponTrail.Play();
            weaponList[0].GetComponent<BoxCollider>().enabled = true;
            nexAttack = false;
            comboMeter++;
            anim.SetTrigger("Melee" + comboMeter);
        }
    }

    void CrossbowAttack()
    {
        GameObject bolt = ObjectPooler.instance.GetPooledObject("Bolt");
        if (bolt != null)
        {
            bolt.transform.position = crossbowBarrel.position;
            bolt.transform.rotation = crossbowBarrel.rotation;
            bolt.SetActive(true);
            bolt.GetComponent<Rigidbody>().AddForce(transform.forward * boltSpeed);
            bolt.GetComponent<CrossbowBolt>().damage = boltDamage;
        }
    }

    public void SpinAttackCooldown()
    {
         StartCoroutine("SpinAttack");
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

    private IEnumerator SpinAttack()
    {
        anim.SetTrigger("SpinAttack");
        yield return new WaitForSeconds(1.10f);
    }

    private IEnumerator Fury(float time)
    {
        furryEffect.Play();
        anim.SetTrigger("IsPowerUp");
        yield return new WaitForSeconds(2.35f);
        isUsingFury = true;
        yield return new WaitForSeconds(time);
        furryEffect.Stop();
        canUseFury = false;
        Debug.Log("Koniec Furri");
        isUsingFury = false;
    }

}
