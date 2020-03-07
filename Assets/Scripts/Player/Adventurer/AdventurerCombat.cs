using UnityEngine;

public class AdventurerCombat : MonoBehaviour
{
    public Transform meleeWeaponSlot;
    public Transform rangeWeaponSlot;

    private GameObject _meleeWeapon;
    //private GameObject rangeWeapon;

    private int _comboMeter = 0;
    private bool _nexAttack = true;

    private AdventurerState _state;

    [SerializeField] private ParticleSystem _weaponTrail;

    private void Awake()
    {
        _state = GetComponent<AdventurerState>();
    }

    private void Start()
    {
        _state.SetWeaponState(true);

        SetWeapons(_state.playerData.meleeWeapon, _state.playerData.rangeWeapon);
    }

    private void SetWeapons(MeleeWeaponData meleeData,RangeWeaponData rangeData)
    {
        _meleeWeapon = Instantiate(meleeData.weaponModel);
        _meleeWeapon.transform.SetParent(meleeWeaponSlot, false);
        _meleeWeapon.GetComponent<ActivateMelee>().SetWeapon(meleeData);
        _weaponTrail = _meleeWeapon.transform.GetChild(1).GetComponent<ParticleSystem>();
        GetComponent<Animator>().SetFloat("MeleeAttackSpeed", meleeData.weaponAttackSpeed);
        var rangeWeapon = Instantiate(rangeData.weaponModel);
        rangeWeapon.transform.SetParent(rangeWeaponSlot, false);
        rangeWeaponSlot.GetComponent<ProjectileLauncher>().weaponData = rangeData;
        rangeWeaponSlot.gameObject.SetActive(false);
    }

    public void SwitchWeapon()
    {
        _state.SetWeaponState(!_state.ReturnWeponState());
        if (_nexAttack == true)
        {
            GetComponent<IPlaySound>().ChangeSound();
            if (_state.ReturnWeponState())
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
        if (_state.ReturnAimingState())
        {
            if (_state.ReturnWeponState() == true)
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
        if (_nexAttack == true)
        { 
            _weaponTrail.Play();
            _meleeWeapon.GetComponent<BoxCollider>().enabled = true;
            _nexAttack = false;
            _comboMeter++;
            GetComponent<AdventurerAnimation>().MeleeAttackAnimation(_comboMeter);
        }
    }

    private void CrossbowAttack()
    {
        GetComponent<IPlaySound>().RangeSound();
        GetComponentInChildren<ILauncher>().LaunchProjectile();
    }

    public void EndAttack()
    {
        _meleeWeapon.GetComponent<BoxCollider>().enabled = false;
        if (_comboMeter == 2)
        {
            _comboMeter = 0;
        }
        _nexAttack = true;
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
