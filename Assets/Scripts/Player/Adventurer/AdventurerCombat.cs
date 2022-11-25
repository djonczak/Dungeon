using UnityEngine;

namespace Adventurer.Player
{
    public class AdventurerCombat : MonoBehaviour
    {
        public Transform meleeWeaponSlot;
        public Transform rangeWeaponSlot;

        private GameObject _meleeWeapon;

        private int _comboMeter = 0;
        private bool _nexAttack = true;

        private AdventurerState _state;

        private const string AttackSpeed = "MeleeAttackSpeed";

        [SerializeField] private ParticleSystem _weaponTrail;

        private void Awake()
        {
            _state = GetComponent<AdventurerState>();
        }

        private void Start()
        {
            _state.MeleeState = true;

            SetWeapons(_state.playerData.MeleeWeapon, _state.playerData.RangeWeapon);
        }

        private void SetWeapons(Weapon.MeleeWeaponData meleeData, Weapon.RangeWeaponData rangeData)
        {
            _meleeWeapon = Instantiate(meleeData.WeaponModel);
            _meleeWeapon.transform.SetParent(meleeWeaponSlot, false);
            _meleeWeapon.GetComponent<ActivateMelee>().SetWeapon(meleeData);
            _weaponTrail = _meleeWeapon.transform.GetChild(1).GetComponent<ParticleSystem>();

            GetComponent<Animator>().SetFloat(AttackSpeed, meleeData.WeaponAttackSpeed);
            var rangeWeapon = Instantiate(rangeData.WeaponModel);
            rangeWeapon.transform.SetParent(rangeWeaponSlot, false);
            rangeWeaponSlot.GetComponent<ProjectileLauncher>().WeaponData = rangeData;
            rangeWeaponSlot.gameObject.SetActive(false);
        }

        public void SwitchWeapon()
        {
            _state.MeleeState = !_state.MeleeState;
            if (_nexAttack == true)
            {
                GetComponent<IPlaySound>().ChangeSound();
                if (_state.MeleeState)
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
            if (_state.Aiming)
            {
                if (_state.MeleeState)
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
    }
}
