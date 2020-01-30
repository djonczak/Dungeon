using UnityEngine;

public class AdventurerCombat : MonoBehaviour
{
    public Transform meleeWeaponSlot;
    public Transform rangeWeaponSlot;

    private GameObject meleeWeapon;
    //private GameObject rangeWeapon;

    private int comboMeter = 0;
    private bool nexAttack = true;

    private AdventurerState state;

    [SerializeField] private ParticleSystem weaponTrail;

    private void Awake()
    {
        state = GetComponent<AdventurerState>();
    }

    private void Start()
    {
        state.isMelee = true;

        SetWeapons(state.playerData.meleeWeapon, state.playerData.rangeWeapon);
    }

    private void SetWeapons(MeleeWeaponData meleeData,RangeWeaponData rangeData)
    {
        meleeWeapon = Instantiate(meleeData.weaponModel);
        meleeWeapon.transform.SetParent(meleeWeaponSlot, false);
        meleeWeapon.GetComponent<ActivateMelee>().weaponData = meleeData;
        weaponTrail = meleeWeapon.transform.GetChild(1).GetComponent<ParticleSystem>();
        GetComponent<Animator>().SetFloat("MeleeAttackSpeed", meleeData.weaponAttackSpeed);
        var rangeWeapon = Instantiate(rangeData.weaponModel);
        rangeWeapon.transform.SetParent(rangeWeaponSlot, false);
        rangeWeaponSlot.GetComponent<ProjectileLauncher>().weaponData = rangeData;
        rangeWeaponSlot.gameObject.SetActive(false);
    }

    public void SwitchWeapon()
    {
        state.isMelee = !state.isMelee;
        if (nexAttack == true)
        {
            GetComponent<IPlaySound>().ChangeSound();
            if (state.isMelee)
            {
                meleeWeaponSlot.gameObject.SetActive(true);
                rangeWeaponSlot.gameObject.SetActive(false);
            }
            else
            {
                meleeWeaponSlot.gameObject.SetActive(false);
                rangeWeaponSlot.gameObject.SetActive(true);
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
                CrossbowAttack();
            }
        }
    }

    private void MeleeAttack()
    {
        if (nexAttack == true)
        { 
            weaponTrail.Play();
            meleeWeapon.GetComponent<BoxCollider>().enabled = true;
            nexAttack = false;
            comboMeter++;
            GetComponent<AdventurerAnimation>().MeleeAttackAnimation(comboMeter);
        }
    }

    private void CrossbowAttack()
    {
        GetComponent<IPlaySound>().RangeSound();
        GetComponentInChildren<ILauncher>().LaunchProjectile();
    }

    public void EndAttack()
    {
        meleeWeapon.GetComponent<BoxCollider>().enabled = false;
        if (comboMeter == 2)
        {
            comboMeter = 0;
        }
        nexAttack = true;
    }

    //public Image furyBar;
    //private bool canUseFury;
    //private bool isUsingFury;
    //private float currentFuryMeter = 0f;
    //private float furyMaxMeter = 100f;
    // public ParticleSystem furryEffect;

    //private void Update()
    //{
    //    //if (isUsingFury)
    //    //{
    //    //    currentFuryMeter = (currentFuryMeter - Time.deltaTime) - 0.161f;
    //    //    furyBar.fillAmount = currentFuryMeter / furyMaxMeter;
    //    //}
    //}

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
    //    isUsingFury = false;
    //}

}
