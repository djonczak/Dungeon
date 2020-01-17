using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerCombat : MonoBehaviour
{
    [SerializeField] private float boltDamage = 1;
    [SerializeField] private float boltSpeed = 180;
    [SerializeField] private string boltName = "Bolt";

    public GameObject[] weaponListActive;
    public Transform crossbowBarrel;

    private int comboMeter = 0;
    private bool nexAttack = true;

    private SoundManager sound;
    private AdventurerState state;

    [Header("Weapon effects")]
    public ParticleSystem weaponTrail;

    //public Image furyBar;
    //private bool canUseFury;
    //private bool isUsingFury;
    //private float currentFuryMeter = 0f;
    //private float furyMaxMeter = 100f;
    // public ParticleSystem furryEffect;

    private void Awake()
    {
        state = GetComponent<AdventurerState>();
        sound = GetComponent<SoundManager>();
    }

    private void Start()
    {
        state.isMelee = true;
        weaponListActive[1].SetActive(false);
    }

    //private void Update()
    //{
    //    //if (isUsingFury)
    //    //{
    //    //    currentFuryMeter = (currentFuryMeter - Time.deltaTime) - 0.161f;
    //    //    furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
    //    //}
    //}

    public void SwitchWeapon()
    {
        state.isMelee = !state.isMelee;
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

    public void Attack()
    {
        if (state.isAiming)
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
    }

    private void MeleeAttack()
    {
        if (nexAttack == true)
        {
            weaponTrail.Play();
            weaponListActive[0].GetComponent<BoxCollider>().enabled = true;
            nexAttack = false;
            comboMeter++;
            GetComponent<AdventurerAnimation>().MeleeAttackAnimation(comboMeter);
        }
    }

    private void CrossbowAttack()
    {
        GetComponentInChildren<ILauncher>().LaunchProjectile(boltName, boltSpeed, boltDamage);
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
