using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerCombat : MonoBehaviour
{
    [SerializeField] private float boltDamage;
    [SerializeField] private float boltSpeed = 180;
    //public Image furyBar;
    public GameObject[] weaponListActive;
    public Transform crossbowBarrel;

    //private float currentFuryMeter = 0f;
    //private float furyMaxMeter = 100f;
    private AdventurerState state;
    private Animator anim;
    private int comboMeter = 0;
    private bool nexAttack = true;
    public ParticleSystem weaponTrail;
    public ParticleSystem furryEffect;
    private bool canUseFury;
    private bool isUsingFury;
    private SoundManager sound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        state = GetComponent<AdventurerState>();
        sound = GetComponent<SoundManager>();
        state.isMelee = true;
        weaponListActive[1].SetActive(false);
    }

    private void Update()
    {
        //if (isUsingFury)
        //{
        //    currentFuryMeter = (currentFuryMeter - Time.deltaTime) - 0.161f;
        //    furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
        //}
    }

    public void SwitchWeapon()
    {
        state.isMelee = !state.isMelee;
        Debug.Log("Zmiana");
        if (nexAttack == true)
        {
            sound.ChangeSound();
            if (state.isMelee)
            {
                weaponListActive[0].SetActive(true);
                weaponListActive[1].SetActive(false);
            }
            else
            {
                weaponListActive[0].SetActive(false);
                weaponListActive[1].SetActive(true);
            }
        }
    }

    public void EndAttack()
    {
        weaponListActive[0].GetComponent<BoxCollider>().enabled = false;
        if (comboMeter == 2)
        {
            comboMeter = 0;
        }
        nexAttack = true;
    }

    public void Attack()
    {
        if (state.isMelee == true)
        {
            MeleeAttack();
        }
        else
        {
            sound.RangeSound();
            CrossbowAttack();
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Melee Attack");
        if (nexAttack == true)
        {
            weaponTrail.Play();
            weaponListActive[0].GetComponent<BoxCollider>().enabled = true;
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

    //public void FuryMeter()
    //{
    //    if(currentFuryMeter < furyMaxMeter  && isUsingFury == false)
    //    {
    //        currentFuryMeter += 4f;
    //        furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
    //    }
    //    else
    //    {
    //        canUseFury = true;
    //    }
    //}

    //public void ActivateFury()
    //{
    //    if(canUseFury == true && isUsingFury == false)
    //    {
    //        StartCoroutine("Fury", 8f);
    //    }
    //}

    //private IEnumerator Fury(float time)
    //{
    //    furryEffect.Play();
    //    anim.SetTrigger("IsPowerUp");
    //    yield return new WaitForSeconds(2.35f);
    //    isUsingFury = true;
    //    yield return new WaitForSeconds(time);
    //    furryEffect.Stop();
    //    canUseFury = false;
    //    Debug.Log("Koniec Furri");
    //    isUsingFury = false;
    //}

}
