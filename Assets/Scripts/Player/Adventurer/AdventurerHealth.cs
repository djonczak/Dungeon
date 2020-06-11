using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Adventurer.Player
{
    public class AdventurerHealth : MonoBehaviour, IDamage
    {
        [SerializeField] private float _maxHP = 0f;
        [SerializeField] private float _currentHP = 0f;
        private Animator _anim;

        public Image HPBar;

        private bool _isDamaged = false;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentHP = _maxHP;
        }

        public void TakeDamage(float amount, Vector3 enemyPosition)
        {
            if (_isDamaged == false)
            {
                _currentHP -= amount;
                HPBar.fillAmount = _currentHP / _maxHP;
                StartCoroutine(DamageCooldown(1f));
                GetComponent<IDamageEffect>().DamageEffect();
                AdventurerEvent.PlayerHit();
                if (CheckIfAlive())
                {
                    StopCoroutine("DamageEffect");
                    Die();
                }
            }
        }

        private bool CheckIfAlive()
        {
            return _currentHP <= 0;
        }

        private void Die()
        {
            _anim.SetTrigger("Dead");
            GetComponent<AdventurerController>().enabled = false;
        }

        private IEnumerator DamageCooldown(float time)
        {
            _isDamaged = true;
            yield return new WaitForSeconds(time);
            _isDamaged = false;
        }
    }
}
